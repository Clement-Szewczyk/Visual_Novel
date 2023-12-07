using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Video;


public class start : MonoBehaviour
{
    public GameObject gamestart;

    public GameObject Menu;

    public VideoPlayer player;

    public AudioSource audio;

    public Animator OnFade;



    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) )
        {
            gamestart.SetActive(false);
            OnFade.SetTrigger("OnFade");
            player.Stop();
            
            Menu.SetActive(true);
            audio.mute = false;
            audio.Play();
        }
    }
}
