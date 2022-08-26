using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerController : MonoBehaviour
{
    [SerializeField] private TimerView _viev;
    [SerializeField] private VrTimerView _vrView;
    [SerializeField] private Timer _timer;

    private void Update()
    {
        _viev.ShowTimerText(_timer.ReturnTime());
        _vrView.SetTextOnCanvas(_timer.ReturnTime());
    }

    public void ControlTimer(bool value)
    {
        _timer.ControlTime(value);
    }

}

