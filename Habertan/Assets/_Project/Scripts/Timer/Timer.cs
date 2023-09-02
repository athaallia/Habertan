using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public static Timer Instance;
    public Level level;
    bool isDestroying = false;



    private void Awake()
    {
        if (Instance == null)
        {


            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }



    private float startTime = 0f;
    private float totalPlayTime = 0f;



    private void Start()
    {
        startTime = Time.time;
    }



    private void Update()
    {
        if (!isDestroying && (SceneManager.GetActiveScene().name == "WinCondition" || SceneManager.GetActiveScene().name == "GameOver"))
        {
            Debug.Log(level.score);
            if (level.score == 0 || level.score == 5 || level.score == 25)
            {
                Debug.Log("Hehe");
                SceneController sceneManager = FindObjectOfType<SceneController>();

                sceneManager.restartScene = "Level2";
                sceneManager.nextScene = "MainMenu";
            }

            isDestroying = true;
            Invoke(nameof(DestroySelf), 0.1f);
        }

        if (IsWinCondition())
            return;

        totalPlayTime = Time.time - startTime;


    }



    public int GetMinutes()
    {
        return (int)totalPlayTime / 60;
    }


    public int GetSeconds()
    {
        return (int)totalPlayTime % 60;
    }



    public float GetTimePlay()
    {
        return totalPlayTime;
    }



    public void ResetTimer()
    {
        startTime = Time.time;
        totalPlayTime = 0;
    }



    public string GetTimerText()
    {
        return $"{GetMinutes().ToString("00")}:{GetSeconds().ToString("00")}";
    }



    public bool IsWinCondition()
    {
        return ScoreManager.Instance.score == level.score;
    }
}
