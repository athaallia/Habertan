using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class Dumpster : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    [SerializeField] private GameObject dumpsterUI;
    [SerializeField] private GameObject pickUpHUD;
    [SerializeField] private GameObject popUpCanvas;



    [SerializeField] private Vector3 pickUpHUD_pos1;
    [SerializeField] private Vector3 pickUpHUD_pos2;



    public string InteractionPrompt => _prompt;
    private StarterAssetsInputs _starterAssetsInput;



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CloseUI();
        }
    }


    public void CloseUI()
    {
        SetMouseInput(true);

        dumpsterUI.SetActive(false);
        pickUpHUD.GetComponent<RectTransform>().anchoredPosition = pickUpHUD_pos1;
    }



    public bool Interact(Interactor interactor)
    {
        _starterAssetsInput = interactor.GetComponent<StarterAssetsInputs>();

        // matiin input mouse untuk kamera, agar mouse bisa drag and drop
        SetMouseInput(false);

        // ya lu munculin si UI Dumpsternya
        dumpsterUI.SetActive(true);

        pickUpHUD.GetComponent<RectTransform>().anchoredPosition = pickUpHUD_pos2;

        // kalo UI Dumpsternya muncul, berarti isDumpsterOpen ya kudu true juga
        interactor.isDumpsterOpen = true;

        // trus prompt buat nyuruh buka Dumpsternya kita matiin, supaya gitu
        popUpCanvas.GetComponent<InteractionPromptUI>().CloseDisplayed();

        return true;
    }



    private void OnTriggerExit(Collider other)
    {
        if (dumpsterUI.activeSelf)
        {
            SetMouseInput(true);

            dumpsterUI.SetActive(false);
            pickUpHUD.GetComponent<RectTransform>().anchoredPosition = pickUpHUD_pos1;
        }
    }



    private void SetMouseInput(bool isActive)
    {
        if (_starterAssetsInput != null)
        {
            _starterAssetsInput.cursorLocked = isActive;
            _starterAssetsInput.cursorInputForLook = isActive;
            _starterAssetsInput.SetCursorState(isActive);
            _starterAssetsInput.look.x = _starterAssetsInput.look.y = 0;

            // kalau mouse nya aktif, berarti UI Dumpster mati, kita set isDumpsterOpen ke false
            if (isActive == true)
            {
                _starterAssetsInput.GetComponent<Interactor>().isDumpsterOpen = false;
            }
        }
    }
}
