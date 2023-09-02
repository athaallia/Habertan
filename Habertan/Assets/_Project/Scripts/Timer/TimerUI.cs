using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerUI : MonoBehaviour
{
    TextMeshProUGUI timerText;
    private void Awake()
    {
        timerText = GetComponentInChildren<TextMeshProUGUI>();
    }

    void Update()
    {
        timerText.text = Timer.Instance.GetTimerText();
    }
}
