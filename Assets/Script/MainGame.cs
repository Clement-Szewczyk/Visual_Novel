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
    
    public Image ImageName;
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
    {   // On cache les boutons non utilisés
        HideButon();
        // On affiche le premier dialogue
        UpdateDialogSequence(Dialog[0]);
        // On ajoute un listener sur les boutons
        choix1.GetComponent<Button>().onClick.AddListener(Bouton1);
        choix2.GetComponent<Button>().onClick.AddListener(Bouton2);
        buttonNext.GetComponent<Button>().onClick.AddListener(Next);
        // On appelle la fonction Story pour gérer les choix
        Story();
        // On met la narration à false
        Dialog[s_sequenceNumber].narration = false;
        
    }

    // Quand on clique sur le bouton 1
    void Bouton1(){
        choix = 1;
        Story();
    }
    
    // Quand on clique sur le bouton 2
    void Bouton2(){
        choix = 2;
        Story();
    }

    // Quand on clique sur le bouton next
    void Next(){
        Debug.Log("next");
        choix = 3;
        if(s_sequenceNumber == 7 ){
            Debug.Log("fin");
            fin1();
        }
        Story();
        
    }

    void Update()
    {   
        // On gère la narration
        narration();
        // On gère les buttons
        button();
        // On ajoute un listener sur les boutons
        choix1.GetComponent<Button>().onClick.AddListener(Bouton1);
        choix2.GetComponent<Button>().onClick.AddListener(Bouton2);
        buttonNext.GetComponent<Button>().onClick.AddListener(Next);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            affichage_text();
        }



        Debug.Log("numéro de la séquence : " + s_sequenceNumber);

        
        
    }

    // On met à jour le dialogue
    void UpdateDialogSequence(DialogueSequence sequence)
    {   
        
        Debug.Log("UpdateDialogSequence en affichant la sequence : " + sequence);
        Debug.Log("Choix " + choix);
        //StartCoroutine(TypeText(sequence.TextDialog));
        // On met à jour les éléments du dialogue
        TextDialog.text = sequence.TextDialog;
        TextCharacterName.text = sequence.TextNameCharacter;
        ImageCharacter.sprite = sequence.SpriteCharacter;
        ImageBackground.sprite = sequence.SpriteBackground;
        // On met à jour les choix
        choix1.GetComponentInChildren<TMP_Text>().text = sequence.Choix1;
        choix2.GetComponentInChildren<TMP_Text>().text = sequence.Choix2;
    }

    // On affiche le texte lettre par lettre
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

    // On affiche tout le texte
    public void affichage_text(){
        // Si le texte est encore en train de s'afficher, affiche immédiatement tout le texte.
        //StopAllCoroutines();
        TextDialog.text = Dialog[s_sequenceNumber].TextDialog;
        isTyping = false;
    }


    // On gère le bouton next
    public void OnClickNextDialog()
    {   
        Debug.Log("JE PASSSSE");
        Story();
        Debug.Log("J'ai pas fait la STORYYYYYYYY");
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

    // On cache les boutons
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

    // On gère les boutons
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

    // On gère les choix pour les différentes séquences qui en ont besoin
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
                s_sequenceNumber = 64;
                UpdateDialogSequence(Dialog[s_sequenceNumber]);
            }
        }

        if(s_sequenceNumber == 22){
            Debug.Log("Je suis au 22 donc dialogue 23");
            Debug.Log("choix : " + choix);
            if(choix == 3){
                Debug.Log("Je vais au 64 donc dialogue 65");
                s_sequenceNumber = 64;
                UpdateDialogSequence(Dialog[s_sequenceNumber]);

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
            if(choix == 2 ){// rien
            
            }
            else if(choix == 1){
               s_sequenceNumber = 32;
                UpdateDialogSequence(Dialog[s_sequenceNumber]); 
            }
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

        if(s_sequenceNumber == 64){
            fin1();
        }
 
    }

    // On gère la narration
    public void narration(){
        if(Dialog[s_sequenceNumber].narration == true){
            Debug.Log("narration");
            ImageCharacter.gameObject.SetActive(false);
            TextCharacterName.gameObject.SetActive(false);
            ImageName.gameObject.SetActive(false);
            
        }
        else{
            Debug.Log("pas narration");
            ImageCharacter.gameObject.SetActive(true);
            TextCharacterName.gameObject.SetActive(true);
            ImageName.gameObject.SetActive(true);

        }
    }

    // On gère la fin
    public void fin1(){
            Game.SetActive(false);
            End.SetActive(true);
        

    }





    

}

