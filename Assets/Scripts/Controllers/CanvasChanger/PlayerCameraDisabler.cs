using AosSdk.Core.PlayerModule;
using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCameraDisabler : MonoBehaviour
{
    [SerializeField] private GameObject _interactHelpers;
    [SerializeField] private GameObject _menuCanvas;
    [SerializeField] private Image _knob;
    [SerializeField] private CursorManager _cursorManager;
    [SerializeField] private Zoom _zoom;

    public void EnableDesktopCamera(bool active)
    {
        if(active)
        {
            _cursorManager.EnableCursor(false);
            _interactHelpers.SetActive(true);
            _menuCanvas.SetActive(false);
        }
        else if(!active)
        {
            _cursorManager.EnableCursor(true);
            _interactHelpers.SetActive(false);
            _menuCanvas.SetActive(true);
        }
        Player.Instance.CanMove = active;
        _zoom.CanZoom = active;
    }
}
