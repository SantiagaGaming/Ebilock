using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ampermetr : MonoBehaviour
{
    [SerializeField] private GameObject _ampermetr;
    public void EnableAmper(bool value, Transform position)
    {
        if (value)
        {
            _ampermetr.SetActive(value);
            _ampermetr.transform.position = position.position;
            _ampermetr.transform.rotation = position.rotation;
        }
        else _ampermetr.SetActive(false);

    }
}
