using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSrc;
    [SerializeField] AudioSource SFXSrc;

    public AudioClip background;
    public AudioClip shoot;

    private void Start(){
        musicSrc.clip = background;
        musicSrc.Play();
    }

    public void PlaySFX(AudioClip clip){
        SFXSrc.PlayOneShot(clip);
    }
}
