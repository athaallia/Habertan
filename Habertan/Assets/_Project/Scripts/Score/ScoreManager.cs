using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    bool isDestroying = false;

    private void Awake()
    {
        if (Instance == null)
        {
            if (SceneManager.GetActiveScene().name == "WinCondition")
            {
                Invoke(nameof(DestroySelf), 1f);
            }

            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public int score = 0;

    private void Update() {
        if (!isDestroying && SceneManager.GetActiveScene().name == "WinCondition")
        {
            isDestroying = true;
            Invoke(nameof(DestroySelf), 1f);
        }
    }

    public void ResetScore()
    {
        score = 0;
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}


