using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraGetter : MonoBehaviour
{
    public static CameraGetter Instance;
    [SerializeField] private Camera _cameraVr;
    [SerializeField] private Camera _cameraDesc;
    private Camera _camera;
    private CameraGetter() {}
    private void Awake()
    {
        if(Instance==null)
            Instance = this;
    }
    private void Start()
    {
        if (_cameraDesc.isActiveAndEnabled)
            _camera = _cameraDesc;
        else _camera = _cameraVr;
    }
    public Camera GetCurrentCamera()
    {
        return _camera;
    }

}
