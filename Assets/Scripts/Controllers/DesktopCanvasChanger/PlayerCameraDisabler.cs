using AosSdk.Core.PlayerModule;
using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCameraDisabler : MonoBehaviour
{
    [SerializeField] private Image _knob;
    [SerializeField] private CursorManager _cursorManager;
    [SerializeField] private Zoom _zoom;

    public void EnableDesktopCamera(bool active)
    {
        if(active)
        {
            _cursorManager.EnableCursor(false);
        }
        else if(!active)
        {
            InstanceHandler.Instance.HelpTextController.HideReactionText();
            InstanceHandler.Instance.HelpTextController.HideHelperText();
            _cursorManager.EnableCursor(true);
        }
        Player.Instance.CanMove = active;
        _zoom.CanZoom = active;
    }
}
