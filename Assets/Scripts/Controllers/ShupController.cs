using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using UnityEngine;
using UnityEngine.Events;

[AosSdk.Core.Utils.AosObject(name: "Щуп")]
public class ShupController : AosObjectBase
{
    public UnityAction<string> SetMeasureTextEvent;

    [SerializeField] private GameObject _redShup;
    [SerializeField] private GameObject _blackShup;

    [AosEvent(name: "Измерение точки красным щупом событие")]
    public event AosEventHandlerWithAttribute OnRedShupConnected;
    [AosEvent(name: "Измерение точки черным щупом событие")]
    public event AosEventHandlerWithAttribute OnBlackShupConnected;
    [AosEvent(name: "Красный щуп убран событие")]
    public event AosEventHandlerWithAttribute OnRedShupDisconnected;
    [AosEvent(name: "Черный щуп убран событие")]
    public event AosEventHandlerWithAttribute OnBlackShupDisconnected;

    private bool _firstMeasure = false;
    public string measureText;

    [AosAction(name: "Измерение точки")]
    public string SetShupPosition([AosParameter("Позиция щупа и название точки измерения")]Transform newPos, string text)
    {
        if (!_firstMeasure)
        {
            if (_redShup.transform.position != newPos.position && _blackShup.transform.position != newPos.position)
            {
                _redShup.transform.position = newPos.position;
                _redShup.transform.rotation = Quaternion.Euler(20, 0, 0);
                _firstMeasure = true;
                measureText = text;
                SetMeasureTextEvent?.Invoke(measureText);
                OnRedShupConnected?.Invoke(measureText);
            }
            else if (_redShup.transform.position == newPos.position)
            {
                _redShup.transform.position = Vector3.zero;

            }
            else if (_blackShup.transform.position == newPos.position)
            {
                _blackShup.transform.position = Vector3.zero;
                OnBlackShupDisconnected?.Invoke(measureText);
                _firstMeasure = true;
            }
        }
        else if (_firstMeasure)
        {
            if (_redShup.transform.position != newPos.position && _blackShup.transform.position != newPos.position)
            {
                _blackShup.transform.position = newPos.position;
                _blackShup.transform.rotation = Quaternion.Euler(20, 0, 0);
                _firstMeasure = false;
                measureText = text;
                SetMeasureTextEvent?.Invoke(measureText);
                OnBlackShupConnected?.Invoke(measureText);
            }

            else if (_blackShup.transform.position == newPos.position)
            {
                _blackShup.transform.position = Vector3.zero;
   
            }
            else if (_redShup.transform.position == newPos.position)
            {
                _redShup.transform.position = Vector3.zero;
                OnRedShupDisconnected?.Invoke(measureText);
                _firstMeasure = false;
            }
        }
        if (_redShup.transform.position == Vector3.zero && _blackShup.transform.position == Vector3.zero)
            _firstMeasure = false;
 

        return measureText;
    }

  public void ResetShupPosition()
    {
        _redShup.transform.position = Vector3.zero;
        _blackShup.transform.position = Vector3.zero;
        measureText = "";
        SetMeasureTextEvent?.Invoke("");
        _firstMeasure = false;
    }
}
