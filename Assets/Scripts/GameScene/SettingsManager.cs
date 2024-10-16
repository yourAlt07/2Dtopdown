using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider SFXSlider;
    [SerializeField] private AudioMixer myMixer;

    void Start(){
        if(!PlayerPrefs.HasKey("musicvolume")){
            SetMusicVolume();
        }
        if(!PlayerPrefs.HasKey("sfxvolume")){
            SetSFXVolume();
        }
        Load();
    }
    private void Load(){
        musicSlider.value = PlayerPrefs.GetFloat("musicvolume");
        SFXSlider.value = PlayerPrefs.GetFloat("sfxvolume");
        SetMusicVolume();
        SetSFXVolume();
    }
    // private void Save(){
    //     PlayerPrefs.SetFloat("musicVolume", musicSlider.value);
    // }
    
    public void SetMusicVolume(){
        float volume = musicSlider.value;
        myMixer.SetFloat("musicvolume",Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("musicvolume",volume);
    }
    public void SetSFXVolume(){
        float volume = SFXSlider.value;
        myMixer.SetFloat("sfxvolume",Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("sfxvolume",volume);
    }
}
