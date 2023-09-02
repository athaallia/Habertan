using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;



    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }



    public void PlayMusic(string audioName)
    {
        Sound sound = Array.Find(musicSounds, x => x.audioName == audioName);

        if (sound == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            musicSource.clip = sound.clip;
            musicSource.volume = sound.volume;
            musicSource.Play();
        }
    }



    public void PlaySFX(string audioName)
    {
        Sound sound = Array.Find(sfxSounds, x => x.audioName == audioName);

        if (sound == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            sfxSource.volume = sound.volume;
            sfxSource.PlayOneShot(sound.clip);
        }
    }
}
