using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class TimelineManager : MonoBehaviour
{
    public string nextScene;

    private PlayableDirector playableDirector;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        playableDirector = GetComponent<PlayableDirector>();
    }

    private void OnEnable()
    {
        playableDirector.stopped += GoToNextScene;
    }

    private void GoToNextScene(PlayableDirector _playableDirector)
    {
        SceneManager.LoadScene(nextScene);
    }
}
