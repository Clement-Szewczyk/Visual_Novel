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
    public Image ImageBackground;
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

    private bool Plankton;
    

    void Start()
    {   
        HideButon();
        UpdateDialogSequence(Dialog[0]);
        choix1.GetComponent<Button>().onClick.AddListener(Bouton1);
        choix2.GetComponent<Button>().onClick.AddListener(Bouton2);
        buttonNext.GetComponent<Button>().onClick.AddListener(Next);
        Story();
        Dialog[s_sequenceNumber].narration = false;
        
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
        choix1.GetComponent<Button>().onClick.AddListener(Bouton1);
        choix2.GetComponent<Button>().onClick.AddListener(Bouton2);
        buttonNext.GetComponent<Button>().onClick.AddListener(Next);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            affichage_text();
        }
        button();
        Debug.Log("numéro de la séquence : " + s_sequenceNumber);
        Debug.Log("narration : " + Dialog[s_sequenceNumber].narration);

        narration();
        
    }

    void UpdateDialogSequence(DialogueSequence sequence)
    {   
        
        Debug.Log("TEST");
        //StartCoroutine(TypeText(sequence.TextDialog));
        TextDialog.text = sequence.TextDialog;
        TextCharacterName.text = sequence.TextNameCharacter;
        ImageCharacter.sprite = sequence.SpriteCharacter;
        ImageBackground.sprite = sequence.SpriteBackground;
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
        isTyping = false;
    }

    public void OnClickNextDialog()
    {   
        Story();
        affichage_text();
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
                s_sequenceNumber = 32;
                UpdateDialogSequence(Dialog[s_sequenceNumber]);
                choix = 0;
            }else if(choix == 2){ //Salle des clients
                s_sequenceNumber = 10;
                UpdateDialogSequence(Dialog[s_sequenceNumber]);
                choix = 0;
            }
        }
        if(s_sequenceNumber == 15){
            if(choix == 1){ // Dicussion
                s_sequenceNumber = 23;
                UpdateDialogSequence(Dialog[s_sequenceNumber]);
                choix = 0;

            }
            else if(choix == 2){// Accusation
                s_sequenceNumber = 16;
                UpdateDialogSequence(Dialog[s_sequenceNumber]);
                choix = 0;

            }
        }


        if(s_sequenceNumber == 19){
            if(choix == 1){// Fouille
                s_sequenceNumber = 22;
                UpdateDialogSequence(Dialog[s_sequenceNumber]);
                choix = 0;
            }
            else if(choix==2){// Ne pas fouiller
                s_sequenceNumber = 20;
                UpdateDialogSequence(Dialog[s_sequenceNumber]);
                choix = 0;
            }
        }

        if(s_sequenceNumber == 21){
            if(choix == 3){
                fin1();
            }
        }

        if(s_sequenceNumber == 22){ // TODO
            if(choix == 3){
                s_sequenceNumber = 31;
                UpdateDialogSequence(Dialog[s_sequenceNumber]);
                choix = 0;
            }
        }

        if(s_sequenceNumber == 26){
            if(choix == 1){// Fouille
                s_sequenceNumber = 27;
                UpdateDialogSequence(Dialog[s_sequenceNumber]);
                choix = 0;
            }
            else if(choix==2){// Ne pas fouiller /// TODO
                s_sequenceNumber = 30;
                UpdateDialogSequence(Dialog[s_sequenceNumber]);
                choix = 0;
            }
        }


        if(s_sequenceNumber == 29){
            if(choix == 1){ // accuser
                fin1();
            }
            else if(choix == 2){// rien faire
                s_sequenceNumber = 31;
                UpdateDialogSequence(Dialog[s_sequenceNumber]);
                choix = 0;
            }
        }

        if(s_sequenceNumber == 30){
            if(choix == 1){// Acusation 
                fin1();
            }
            else if(choix==2){// Rien faire
                s_sequenceNumber = 31;
                UpdateDialogSequence(Dialog[s_sequenceNumber]);
            }
        }

        if(s_sequenceNumber == 31){
            Plankton = true;
        }

        if (s_sequenceNumber == 39){
            if(choix == 1){//Confronter
                s_sequenceNumber = 40;
                UpdateDialogSequence(Dialog[s_sequenceNumber]);
            }
            else if(choix == 2){//Rester dans le bureau 
                s_sequenceNumber = 51;
                UpdateDialogSequence(Dialog[s_sequenceNumber]);
            }
        }

        if(s_sequenceNumber == 45){
            if(choix == 1){//Fouille la maison
                s_sequenceNumber = 48;
                UpdateDialogSequence(Dialog[s_sequenceNumber]);  
            }
            else if(choix ==2){// piège
                s_sequenceNumber = 46;
                UpdateDialogSequence(Dialog[s_sequenceNumber]);
            }
        }
        if(s_sequenceNumber == 47){
            if(choix == 3){//Fin
                fin1();
            }
            
        }

        if(s_sequenceNumber == 50){
            if(choix == 3){//Fin
                fin1();
            }
        }
        
        if(s_sequenceNumber == 58){
            if(choix == 1){//Fouille la maison
               s_sequenceNumber = 61;
                UpdateDialogSequence(Dialog[s_sequenceNumber]); 
            }
            else if(choix ==2){// piège
                s_sequenceNumber = 59;
                UpdateDialogSequence(Dialog[s_sequenceNumber]);
                
            }
        }

        if(s_sequenceNumber == 60){
            if(choix == 3){//Fin
                fin1();
            }
        }

        if(s_sequenceNumber == 63){
            if(choix == 3){//Fin
                fin1();
            }
        }

        

        
        
    }


    public void narration(){
        if(Dialog[s_sequenceNumber].narration == true){
            Debug.Log("narration");
            ImageCharacter.gameObject.SetActive(false);
            TextCharacterName.gameObject.SetActive(false);
            
        }
        else{
            Debug.Log("pas narration");
            ImageCharacter.gameObject.SetActive(true);
            TextCharacterName.gameObject.SetActive(true);

        }
    }

    public void fin1(){
            Game.SetActive(false);
            End.SetActive(true);
        

    }





    

}

