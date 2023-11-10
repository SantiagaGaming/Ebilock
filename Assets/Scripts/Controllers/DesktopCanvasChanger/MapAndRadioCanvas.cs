using AosSdk.Core.PlayerModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapAndRadioCanvas : MonoBehaviour
{
    [SerializeField]private GameObject _radioObjects;
    [SerializeField] private GameObject _mapObjects;
    [SerializeField] private CursorManager _cursormanager;
    [SerializeField] private CloseCanvasButton _closeCanvasButton;
    private void Start()
    {
        RadioButton.RadioButtonClickEvent += OnRadioButtonClickEvent;
        _closeCanvasButton.BackButtonClickEvent += OnCloseCanvas;
    }

    private void OnCloseCanvas()
    {
        _radioObjects.SetActive(false);
        _cursormanager.EnableCursor(false);
    }

    private void OnRadioButtonClickEvent()
    {
        _radioObjects.SetActive(true);
        _cursormanager.EnableCursor(true);
    }
}
