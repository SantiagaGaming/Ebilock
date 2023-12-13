using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeasureController : MonoBehaviour
{
    [SerializeField] private PointerDevice _pointerDevice;

    private string _measuretext;
    private string _type;
    private string _blackValue;
    private string _redValue;
    private string _pointerValue;

    public void SetDeviceValue(float value)
    {
        Debug.Log(_measuretext + " API MeasureText From Measure Controller");
        _pointerValue = _pointerDevice.SetValue(value);
        _measuretext = $"d_m_c43101:{_type}:{_blackValue}:{_redValue}:{_pointerValue}";
        API.Instance.InvokeOnMeasure(_measuretext);
    }

    public void SetTypeText(string type)
    {
        _type = type;
        ReturnMeasureText();
    }
    public void SetRedText(string red)
    {
        _redValue = red;
        ReturnMeasureText();
    }
    public void SetBlackText(string black)
    {
        _blackValue = black;
        ReturnMeasureText();
    }
    public void ReturnMeasureText()
    {
        _pointerValue = null;
        if (_type != null && _blackValue != null && _redValue != null)
        {
            _measuretext = $"d_m_c43101:{_type}:{_blackValue}:{_redValue}:{_pointerValue}";
        }
        else
        {
            _pointerDevice.SetValue(0);
            _measuretext = $"d_m_c43101:{_type}:{_blackValue}:{_redValue}:{_pointerValue}";
          
        }
        API.Instance.InvokeOnMeasure(_measuretext);
    }
}
