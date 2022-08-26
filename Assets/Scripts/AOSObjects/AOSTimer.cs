using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using UnityEngine;
using UnityEngine.Events;


[AosSdk.Core.Utils.AosObject(name: "Таймер")]
public class AOSTimer : AosObjectBase
{
    [SerializeField] private Timer _timer;
    [AosEvent(name: "Запросить минуты")]
    public event AosEventHandlerWithAttribute GetMinutes;
    [AosEvent(name: "Запросить секунды")]
    public event AosEventHandlerWithAttribute GetSeconds;


    [AosAction(name: "Добавить минуты")]
    public void AddMinutes(float min)
    {
    _timer.AddMinutes(min);
    }
    [AosAction(name: "Добавить секунды")]
    public void AddSeconds(float sec)
    {
        _timer.AddSeconds(sec);
    }
    [AosAction(name: "Добавить секунды")]
    public void TimerEnabler(bool value)
    {
        _timer.ControlTime(value);
    }
    [AosAction(name: "запросить минуты")]
    public void GetTimerMinutes()
    {
        GetMinutes?.Invoke(_timer.GetMinutes());
    }
    [AosAction(name: "запросить минуты")]
    public void GetTimerSeconds()
    {
        GetMinutes?.Invoke(_timer.GetSeconds());
    }



}
