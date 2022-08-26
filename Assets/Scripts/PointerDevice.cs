using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerDevice : MonoBehaviour
{
    [SerializeField] private float minValue;
    [SerializeField] private float maxValue;
    [Space] [SerializeField] private float divisionValue;
    [SerializeField] private Transform arrowTransform;
    [SerializeField] private ArrowRotationAxis arrowRotationAxis;

    private enum ArrowRotationAxis
    {
        X,
        Y,
        Z
    }

    public void SetValue(float value)
    {
        value = Mathf.Clamp(value, minValue, maxValue);

        var targetRotation = arrowRotationAxis switch
        {
            ArrowRotationAxis.X => Vector3.right,
            ArrowRotationAxis.Y => Vector3.up,
            ArrowRotationAxis.Z => Vector3.forward,
            _ => throw new ArgumentOutOfRangeException()
        };

        targetRotation *= divisionValue * value;

        arrowTransform.localRotation = Quaternion.Euler(targetRotation);
    }
    public void SetMinValue(float min)
    {
        minValue = min;
    }
    public void SetMaxValue(float max)
    {
        maxValue = max;
    }
    public void SetDevisionValue(float dev)
    {
        divisionValue = dev;
    }
}
