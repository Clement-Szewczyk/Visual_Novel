using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.UI;

public class SliderValue : MonoBehaviour
{
    public TMPro.TextMeshProUGUI TextValue;
    public Slider _slider;

    public AudioSource Music;

    public void OnValueChanged(){
        int valueINT = (int)Math.Round(_slider.value*100.0f);
        TextValue.text = valueINT.ToString();
        OnMusicValueChanged(_slider.value);

    }

    public void OnMusicValueChanged(float newValue){
        Music.volume = newValue;
    }

    void Start(){
        // Définir une valeur par défaut (par exemple, 0.4 correspondant à 40%)
        float defaultValue = 1f;
        
        // Initialiser la valeur du slider avec la valeur par défaut
        _slider.value = defaultValue;

        OnValueChanged();
    }

    

}
