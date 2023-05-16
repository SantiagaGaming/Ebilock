using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ampermetr : MonoBehaviour
{
    [SerializeField] private GameObject _ampermetr;

    private void Start()
    {
        BackButton.OnBackButtonClick += OnDisableAmper;
    }
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
        {
            OnDisableAmper();
        }
     
    }
    public void OnDisableAmper()
    {
        _ampermetr.SetActive(false);
    }
}
