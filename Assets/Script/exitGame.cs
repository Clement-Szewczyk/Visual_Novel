using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 


public class exitGame : MonoBehaviour
{      
    public MainGame mainGame;
    public Image ImageFade;
    public GameObject Fade;

    public GameObject game;
    public GameObject courrant;

    public string sceneName;

    public AudioSource gamesound;
    public AudioSource victorysound;
    public AudioSource defeatsound;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start exitGame");
       gamesound.Stop(); 
       if(mainGame.victoire){
           victorysound.Play();
           defeatsound.Stop();
         }else{
            victorysound.Stop();
            defeatsound.Play();
         }
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Escape)  ){
            //Va sur la scène menu
            Fade.SetActive(true);
            ImageFade.DOFade(1,0.8f).OnComplete(FadeComplete);
        } 

        if(Input.GetKeyDown(KeyCode.Space)  ){
            courrant.SetActive(false);
            game.SetActive(true);
            mainGame.startgame();
        }

    }

    private void FadeComplete(){
        SceneManager.LoadScene(sceneName);
    }
}
