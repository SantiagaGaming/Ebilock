using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertController : MonoBehaviour
{
    [SerializeField] private GameObject _canvas;
    [SerializeField] private GameObject _descPlayer;
    [SerializeField] private GameObject _vrPlayer;
    private Vector3 _camPos;
    private Vector3 _tempPos;

    private float _elapsedTime = 2f;
    private void Start()
    {
        _camPos = GetCurrentTransform();
        _tempPos = GetCurrentTransform();
    }


    private void Update()
    {
        if (!CompareTransforms(_tempPos, _camPos))
            _canvas.SetActive(false);
       _camPos = GetCurrentTransform();
        _elapsedTime -= Time.deltaTime;
        if(_elapsedTime<=0)
        {
            _elapsedTime = 2f;
            if (CompareTransforms(_camPos, _tempPos))
                ActivateCanvas();
            else
            {
                _canvas.SetActive(false);
                _tempPos = GetCurrentTransform();
            }
        }
    }
    private void ActivateCanvas()
    {
        _canvas.SetActive(true);
        _canvas.transform.position = GetCurrentTransform();
        if (_descPlayer.activeSelf)
        {
            _canvas.transform.rotation = _descPlayer.transform.rotation;
        }

        else
        {
            _canvas.transform.rotation = _vrPlayer.transform.rotation;
        }
    }
    private Vector3 GetCurrentTransform()
    {
        if (_descPlayer.activeSelf)
        {
            return _descPlayer.transform.position;
        }
         
        else
        {
            return _vrPlayer.transform.position;
        }
    }
    private bool CompareTransforms(Vector3 camPos, Vector3 tempPos)
    {
        if (camPos == tempPos)
            return true;
        else return false;
    }
}
