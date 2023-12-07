using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;   

public class Menu : MonoBehaviour
    {   
    public Image ImageFade;
    public GameObject Fade;
    public CanvasGroup Options2;
    public CanvasGroup Credit;
    public List<MenuButton> Buttons;

    public void OnclickPlay(){
        Fade.SetActive(true);
        ImageFade.DOFade(1,0.8f).OnComplete(FadeComplete);
        for(int i = 1; i<Buttons.Count; i++){
            Buttons[i].Hide(0.8f);
        }
    }

    public void OnclickOptions(){
        Options2.gameObject.SetActive(true);
        Options2.alpha = 0;
        Options2.DOFade(1, 0.2f);
        
    }

    public void OnclickCredit(){
        Credit.gameObject.SetActive(true);
        Credit.alpha = 0;
        Credit.DOFade(1, 0.2f);
        
    }


    private void FadeComplete(){
        SceneManager.LoadScene("Game");
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && Options2.gameObject.activeInHierarchy){
            Options2.DOFade(0, 0.2f).OnComplete( ()=> {Options2.gameObject.SetActive(false);});
        }
        if(Input.GetKeyDown(KeyCode.Escape) && Credit.gameObject.activeInHierarchy){
            Credit.DOFade(0, 0.2f).OnComplete( ()=> {Credit.gameObject.SetActive(false);});
        }
    }
}
