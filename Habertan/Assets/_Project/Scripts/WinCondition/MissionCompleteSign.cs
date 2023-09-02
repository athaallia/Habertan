using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionCompleteSign : MonoBehaviour
{
    [SerializeField] private Image finishCongratsImage;
    [SerializeField] private Image timerUI;
    [SerializeField] private Image pickUpUI;
    [SerializeField] private GameObject popUpCanvas;
    [SerializeField] private Dumpster dumpster;
    private bool isWin;



    private void Update()
    {
        if (Timer.Instance.IsWinCondition() && !isWin)
        {
            dumpster.CloseUI();
            FinishCongrats();

            popUpCanvas.SetActive(false);
            pickUpUI.gameObject.SetActive(false);
            timerUI.gameObject.SetActive(false);
        }
    }



    private void FinishCongrats()
    {
        isWin = true;
        StartCoroutine(ShowImage(finishCongratsImage, 7f));
    }



    public IEnumerator ShowImage(Image _image, float time)
    {
        _image.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(time);
        _image.gameObject.SetActive(false);
    }
}
