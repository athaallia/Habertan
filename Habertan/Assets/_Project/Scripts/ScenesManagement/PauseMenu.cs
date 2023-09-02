using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using StarterAssets;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private StarterAssetsInputs _starterAssetsInput;
    [SerializeField] private GameObject pengaturanUI;
    [SerializeField] private Image timerUI;
    [SerializeField] private Image pickUpUI;
    [SerializeField] private GameObject scoreUI;
    [SerializeField] private GameObject popUpCanvas;
    [SerializeField] private Dumpster dumpster;
    public bool isPause = false;



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPause)
            {   
                Resume();
                pengaturanUI.gameObject.SetActive(false);
            }
            else
            {
                Pause();
                Cursor.lockState = CursorLockMode.None;
                pengaturanUI.gameObject.SetActive(true);
            }
        }
    }



    public void Pause()
    {
        Time.timeScale = 0;
        isPause = true;
        SetOpen(false);
        SetMouseInput(false);
    }



    public void Resume()
    {
        Time.timeScale = 1;
        isPause = false;
        SetOpen(true);
        SetMouseInput(true);
    }



    private void SetMouseInput(bool isActive)
    {
        if (_starterAssetsInput != null)
        {
            _starterAssetsInput.LookInput(new Vector2(0, 0));
            _starterAssetsInput.cursorLocked = isActive;
            _starterAssetsInput.cursorInputForLook = isActive;
            _starterAssetsInput.SetCursorState(isActive);
        }
    }



    private void SetOpen(bool isActive)
    {
        timerUI.gameObject.SetActive(isActive);
        pickUpUI.gameObject.SetActive(isActive);
        popUpCanvas.SetActive(isActive);
        dumpster.gameObject.SetActive(isActive);
        scoreUI.gameObject.SetActive(isActive);
    }
}