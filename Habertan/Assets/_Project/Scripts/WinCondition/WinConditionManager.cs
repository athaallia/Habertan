using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WinConditionManager : MonoBehaviour
{
    [SerializeField] private Image cleanSuccessImage;
    [SerializeField] private Image fiveMinutesSuccessImage;
    [SerializeField] private Image fiveMinutesUnsuccessImage;
    [SerializeField] private Image threeMinutesSuccessImage;
    [SerializeField] private Image threeMinutesUnsuccessImage;

    [SerializeField] private Image threeStarsImage;
    [SerializeField] private Image threeStarsTextCongrats;
    [SerializeField] private Image threeStarsTextDetail;

    [SerializeField] private Image twoStarsImage;
    [SerializeField] private Image twoStarsTextCongrats;
    [SerializeField] private Image twoStarsTextDetail;

    [SerializeField] private Image oneStarImage;
    [SerializeField] private Image oneStarTextCongrats;
    [SerializeField] private Image oneStarTextDetail;

    [SerializeField] private TextMeshProUGUI timerText;


    private void Start()
    {
        WinCondition();
    }



    private void WinCondition()
    {
        timerText.text = Timer.Instance.GetTimerText();

        if (Timer.Instance.GetMinutes() <= 2)
        {
            Debug.Log(Timer.Instance.GetMinutes());
            AudioManager.Instance.PlaySFX("Bintang 3");

            cleanSuccessImage.gameObject.SetActive(true);
            fiveMinutesSuccessImage.gameObject.SetActive(true);
            threeMinutesSuccessImage.gameObject.SetActive(true);

            threeStarsImage.gameObject.SetActive(true);
            threeStarsTextCongrats.gameObject.SetActive(true);
            threeStarsTextDetail.gameObject.SetActive(true);
        }

        else if (Timer.Instance.GetMinutes() > 2 && Timer.Instance.GetMinutes() <= 5)
        {
            Debug.Log(Timer.Instance.GetMinutes());
            AudioManager.Instance.PlaySFX("Bintang 2");

            cleanSuccessImage.gameObject.SetActive(true);
            fiveMinutesSuccessImage.gameObject.SetActive(true);
            threeMinutesUnsuccessImage.gameObject.SetActive(true);

            twoStarsImage.gameObject.SetActive(true);
            twoStarsTextCongrats.gameObject.SetActive(true);
            twoStarsTextDetail.gameObject.SetActive(true);
        }

        else if (Timer.Instance.GetMinutes() > 5)
        {
            AudioManager.Instance.PlaySFX("Bintang 1");

            cleanSuccessImage.gameObject.SetActive(true);
            fiveMinutesUnsuccessImage.gameObject.SetActive(true);
            threeMinutesUnsuccessImage.gameObject.SetActive(true);

            oneStarImage.gameObject.SetActive(true);
            oneStarTextCongrats.gameObject.SetActive(true);
            oneStarTextDetail.gameObject.SetActive(true);
        }
    }
}
