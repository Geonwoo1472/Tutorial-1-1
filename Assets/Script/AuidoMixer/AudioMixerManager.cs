using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioMixerManager : MonoBehaviour
{
    public AudioMixer mixer;
    
    public void BGSoundVolume(float val)
    {
        mixer.SetFloat("BGMVolume", Mathf.Log10(val) * 20);
    }

    public void SFXSoundVolume(float val)
    {
        mixer.SetFloat("SFXVolume", Mathf.Log10(val) * 20); 
    }

    public void PlayerSoundVolume(float val)
    {
        if(val <=1)
            mixer.SetFloat("PlayerVolume", Mathf.Log10(val) * 20);
        

    }
}
