using AosSdk.Core.PlayerModule;
using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCameraDisabler : MonoBehaviour
{
    [SerializeField] private GameObject _playerDesktopCamera;
    [SerializeField] private GameObject _menuDesktopCamera;
    [SerializeField] private Image _knob;
    [SerializeField] private CursorManager _cursorManager;

    public void EnableDesktopCamera(bool active)
    {
        if(active)
        {
            _cursorManager.EnableCursor(false);
            _menuDesktopCamera.SetActive(false);
            Player.Instance.CanMove = true;
        }
        else if(!active)
        {
            InstanceHandler.Instance.HelpTextController.HideReactionText();
            InstanceHandler.Instance.HelpTextController.HideHelperText();
            _cursorManager.EnableCursor(true);
            _menuDesktopCamera.SetActive(true);
            Player.Instance.CanMove = false;
        }   
        _playerDesktopCamera.SetActive(active);
    }
}
