using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using StarterAssets;

public class SceneController : MonoBehaviour
{
    private StarterAssetsInputs _starterAssetsInput;
    public string restartScene;
    public string nextScene;



    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }



    public void RestartGame()
    {
        SceneManager.LoadScene(restartScene);
    }



    public void MainMenuScene()
    {
        SceneManager.LoadScene(1);
    }



    public void GoToNextLevel()
    {
        SceneManager.LoadScene(nextScene);
    }
}
