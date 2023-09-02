using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverTrigger : MonoBehaviour
{
    public string nextScene;
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Mati");

        if (other.CompareTag("Player"))
        {
            AudioManager.Instance.musicSource.Stop();

            SceneManager.LoadScene(nextScene);
        }
    }
}
