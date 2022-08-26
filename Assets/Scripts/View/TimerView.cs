using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TimerView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timerText;
    public void ShowTimerText(string time)
    {
        _timerText.text = time;
    }

}
