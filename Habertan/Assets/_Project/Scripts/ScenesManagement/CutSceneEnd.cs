using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using StarterAssets;

public class CutSceneEnd : MonoBehaviour
{
    private StarterAssetsInputs _starterAssetsInput;

    public void ShowWinCondition()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        AudioManager.Instance.musicSource.Stop();
    }
}
