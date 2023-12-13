using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

public class Ampermetr : MonoBehaviour
{
    [SerializeField] private GameObject _ampermetr;
    [SerializeField] private MeasureButtonsActivator _measureButtonActivator;
    [SerializeField] private ShupController _shupController;
    [SerializeField] private PointerDevice _pointerDevice;

    public void EnableAmper(Transform position)
    {
        var active = _ampermetr.activeSelf;
        if (!active)
        {
            transform.position = position.position;
            transform.rotation= position.rotation;
            _ampermetr.SetActive(true);
        }
        else
            DisableAmper();
     
    }
    public void DisableAmper()
    {
        _shupController.ResetShupPosition();
        _measureButtonActivator.DeactivateAllButtons();
        _pointerDevice.SetValue(1);
        _ampermetr.SetActive(false);
    }
}
