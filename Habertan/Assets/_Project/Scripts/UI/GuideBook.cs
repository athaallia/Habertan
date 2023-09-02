using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class GuideBook : MonoBehaviour
{
    [SerializeField] private GameObject panduanCanvas;
    [SerializeField] private StarterAssetsInputs _starterAssetsInputs;

    bool isOpen;



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
            if (isOpen)
                HandleCloseGuideBook();
            else
                HandleOpenGuideBook();
    }



    private void SetMouseInput(bool isActive)
    {
        if (_starterAssetsInputs != null)
        {
            _starterAssetsInputs.cursorLocked = isActive;
            _starterAssetsInputs.cursorInputForLook = isActive;
            _starterAssetsInputs.SetCursorState(isActive);
        }
    }



    public void HandleOpenGuideBook()
    {
        isOpen = true;
        panduanCanvas.SetActive(true);
        SetMouseInput(false);
    }



    public void HandleCloseGuideBook()
    {
        isOpen = false;
        panduanCanvas.SetActive(false);
        SetMouseInput(true);
    }
}
