using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScreen : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider sliderLoadingScreen;



    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        sliderLoadingScreen.value = 0.1f;

    }


    
    private void Start()
    {
        StartCoroutine(LoadingScreen());
    }



    private IEnumerator LoadingScreen()
    {
        while (sliderLoadingScreen.value < 0.3f)
        {
            sliderLoadingScreen.value += 0.01f;
            yield return new WaitForSeconds(0.01f);
        }

        yield return new WaitForSeconds(2f);

        while (sliderLoadingScreen.value < 0.9f)
        {
            sliderLoadingScreen.value += 0.01f;
            yield return new WaitForSeconds(0.001f);
        }

        yield return new WaitForSeconds(1f);

        while (sliderLoadingScreen.value < 1f)
        {
            sliderLoadingScreen.value += 0.01f;
            yield return new WaitForSeconds(0.01f);
        }

        // StartCoroutine(ScreenFade.FadeIn(1f, FadeColor.Black));

        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene("MainMenu");
    }
}