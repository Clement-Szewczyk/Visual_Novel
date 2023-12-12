using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using Unity.VisualScripting;

public class MainGame : MonoBehaviour
{
    public TMP_Text TextDialog;
    public TMP_Text TextCharacterName;
    public Image ImageCharacter;
    public DialogueSequence[] Dialog;
    public int s_sequenceNumber = 0;

    public GameObject choix1;
    public GameObject choix2;
    public GameObject buttonNext;
   // public GameObject buttonBefore;

   public GameObject Game;
   public GameObject End;

    private bool isTyping = false;

    private int choix = 0;

    private int Fin1 = 0;

    void Start()
    {   
        choix =0;
        Debug.Log("numéro de la séquence : " + s_sequenceNumber);
        HideButon();
        UpdateDialogSequence(Dialog[0]);
        choix1.GetComponent<Button>().onClick.AddListener(Bouton1);
        choix2.GetComponent<Button>().onClick.AddListener(Bouton2);
        buttonNext.GetComponent<Button>().onClick.AddListener(Next);
        Story();
        
    }

    void Bouton1(){
        choix = 1;
        Story();
    }
    
    void Bouton2(){
        choix = 2;
        Story();
    }

    void Next(){
        choix = 3;
        if(s_sequenceNumber == 7 ){
            Debug.Log("fin");
            fin1();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            affichage_text();
        }
        button();
        Debug.Log("numéro de la séquence : " + s_sequenceNumber);
        
        
    }

    void UpdateDialogSequence(DialogueSequence sequence)
    {
        //StartCoroutine(TypeText(sequence.TextDialog));
        TextDialog.text = sequence.TextDialog;
        TextCharacterName.text = sequence.TextNameCharacter;
        ImageCharacter.sprite = sequence.SpriteCharacter;
        choix1.GetComponentInChildren<TMP_Text>().text = sequence.Choix1;
        choix2.GetComponentInChildren<TMP_Text>().text = sequence.Choix2;
    }

    IEnumerator TypeText(string text)
    {
        isTyping = true;
        TextDialog.text = "";

        float typingSpeed = 0.05f; // Ajustez cette valeur pour contrôler la vitesse de dactylographie

        foreach (char letter in text)
        {
            TextDialog.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;
    }

    public void affichage_text(){
        // Si le texte est encore en train de s'afficher, affiche immédiatement tout le texte.
        //StopAllCoroutines();
        TextDialog.text = Dialog[s_sequenceNumber].TextDialog;
        //isTyping = false;
    }

    public void OnClickNextDialog()
    {   
        Story();
        //affichage_text();
        if (isTyping)
        {
            affichage_text();
        }
        else
        {
            s_sequenceNumber++;
            if (s_sequenceNumber >= Dialog.Length)
            {
                s_sequenceNumber = Dialog.Length - 1;
            }
            HideButon();
            UpdateDialogSequence(Dialog[s_sequenceNumber]);
        }

    }

   
    public void HideButon()
    {
        if (s_sequenceNumber == Dialog.Length - 1)
        {
            buttonNext.SetActive(false);
        }
        else
        {
            buttonNext.SetActive(true);
        }
        /*if (s_sequenceNumber == 0)
        {
            buttonBefore.SetActive(false);
        }
        else
        {
            buttonBefore.SetActive(true);
        }*/
    }

    public void button(){
        if(Dialog[s_sequenceNumber].affiche_choix == true){
            buttonNext.SetActive(false);
            choix1.SetActive(true);
            choix2.SetActive(true);
        }
        else{
            buttonNext.SetActive(true);
            choix1.SetActive(false);
            choix2.SetActive(false);
        }
    }


    public void Story(){
        if(s_sequenceNumber == 0){
            if(choix == 2){ // refuser
                s_sequenceNumber = 1;
                UpdateDialogSequence(Dialog[s_sequenceNumber]);
                choix = 0;
            }
            else if(choix == 1){
                s_sequenceNumber =7 ; // accepter
                UpdateDialogSequence(Dialog[s_sequenceNumber]);
                choix = 0;
            }
        }
        if(s_sequenceNumber == 2){
            if(choix == 1){ // refuser
                s_sequenceNumber = 5;
                UpdateDialogSequence(Dialog[s_sequenceNumber]);
                choix = 0;
            }
            else if(choix == 2){ // accepter
                s_sequenceNumber = s_sequenceNumber + 1;
                UpdateDialogSequence(Dialog[s_sequenceNumber]);
                choix = 0;
            }
        }
        if(s_sequenceNumber == 4){
            if(choix == 3){ 
                Debug.Log("8");
                s_sequenceNumber = 8;
                UpdateDialogSequence(Dialog[s_sequenceNumber]);
                choix = 0;
            }
            
        }
        if(s_sequenceNumber == 9){
            if(choix == 1){ //Bureau

            }else if(choix == 2){ //Salle des clients
                s_sequenceNumber = 10;
                UpdateDialogSequence(Dialog[s_sequenceNumber]);
            }
        }
        if(s_sequenceNumber == 15){
            if(choix == 1){ // Dicussion
                s_sequenceNumber = 23;
                UpdateDialogSequence(Dialog[s_sequenceNumber]);

            }
            else if(choix == 2){// Accusation
                s_sequenceNumber = 16;
                UpdateDialogSequence(Dialog[s_sequenceNumber]);

            }
        }

        if(s_sequenceNumber == 19){
            if(choix == 1){// Respecter le choix
                s_sequenceNumber = 22;
                UpdateDialogSequence(Dialog[s_sequenceNumber]);
            }
            else if(choix==2){// Ne pas respecter le choix
                s_sequenceNumber = 20;
                UpdateDialogSequence(Dialog[s_sequenceNumber]);
            }
        }
        if(s_sequenceNumber == 21){
            if(choix == 3){
                fin1();
            }
        }

        if(s_sequenceNumber == 19){
            if(choix == 1){// Fouille
                s_sequenceNumber = 22;
                UpdateDialogSequence(Dialog[s_sequenceNumber]);
            }
            else if(choix==2){// Ne pas fouiller
                s_sequenceNumber = 20;
                UpdateDialogSequence(Dialog[s_sequenceNumber]);
            }
        }

        if(s_sequenceNumber == 26){
            if(choix == 1){// Fouille
                s_sequenceNumber = 27;
                UpdateDialogSequence(Dialog[s_sequenceNumber]);
            }
            else if(choix==2){// Ne pas fouiller
                s_sequenceNumber = 29;
                UpdateDialogSequence(Dialog[s_sequenceNumber]);
            }
        }

        
        
        
    }

    public void fin1(){
            Game.SetActive(false);
            End.SetActive(true);
        

    }





    

}

