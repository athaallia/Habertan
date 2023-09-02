using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using StarterAssets;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider SFXSlider;
    // [SerializeField] private StarterAssetsInputs _starterAssetsInput;
    // [SerializeField] private GameObject pengaturanUI;
    // public bool isPause = false;



    private void Start() 
    {
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetMusicVolume();
            SetSFXVolume();
        }
    }



    // private void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.Escape))
    //     {
    //         if (isPause)
    //         {
    //             Resume();
    //             pengaturanUI.gameObject.SetActive(false);
    //         }
    //     }
    // }



    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        audioMixer.SetFloat("Music", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }



    public void SetSFXVolume()
    {
        float volume = SFXSlider.value;
        audioMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }



    private void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume");

        SetMusicVolume();
    }



    // public void Resume()
    // {
    //     Time.timeScale = 1;
    //     isPause = false;
    //     SetMouseInput(true);
    // }



    // private void SetMouseInput(bool isActive)
    // {
    //     if (_starterAssetsInput != null)
    //     {
    //         _starterAssetsInput.LookInput(new Vector2(0, 0));
    //         _starterAssetsInput.cursorLocked = isActive;
    //         _starterAssetsInput.cursorInputForLook = isActive;
    //         _starterAssetsInput.SetCursorState(isActive);
    //     }
    // }
} 
