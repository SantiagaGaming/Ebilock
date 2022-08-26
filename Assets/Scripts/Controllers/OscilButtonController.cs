using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscilButtonController : MonoBehaviour
{
    [SerializeField] private OscilButton[] _buttons;
    private int _currentButton;
    private bool _firsttap = false;

    private void Start()
    {
        foreach (var item in _buttons)
        {
            item.ButtonDownEvent += OnCurrentButtonChanged;
        }
    }

    private void OnCurrentButtonChanged(int number)
    {
        if (_firsttap)
            UpButton();
        else _firsttap = true;
        _currentButton = number;
    }
    private void UpButton()
    {
          _buttons[_currentButton].ResetButton();
    }
}
