using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using UnityEngine;
using UnityEngine.Events;
[AosSdk.Core.Utils.AosObject(name: "Амперметр")]
public class AOSAmpermetr : AosObjectBase
{
    [SerializeField] private GameObject _leverArm;
    [SerializeField] private FuseAmperButton _fuse;
    [SerializeField] private PointerDevice _pointerDevice;
    [AosAction(name: "Изменить переключатель пределов измерений")]
    public void SetCondition(float value)
    {
        if (value < 0)
            _fuse.ResetButton();
        else if (value <= 0.5f)
            _leverArm.transform.localRotation = Quaternion.Euler(0, -135f, 0);
        else if (value <= 2.5f)
            _leverArm.transform.localRotation = Quaternion.Euler(0, -120f, 0);
        else if (value <= 10f)
            _leverArm.transform.localRotation = Quaternion.Euler(0, -105f, 0);
        else if (value <= 25f)
            _leverArm.transform.localRotation = Quaternion.Euler(0, -90f, 0);
        else if (value <= 50f)
            _leverArm.transform.localRotation = Quaternion.Euler(0, -75f, 0);
        else if (value <= 100f)
            _leverArm.transform.localRotation = Quaternion.Euler(0, -60f, 0);
        else if (value <= 250f)
            _leverArm.transform.localRotation = Quaternion.Euler(0, -45f, 0);
        else if (value <= 500f)
            _leverArm.transform.localRotation = Quaternion.Euler(0, -30f, 0);
        else if (value <= 1000f)
            _leverArm.transform.localRotation = Quaternion.Euler(0, -15f, 0);
        else if (value > 1000)
            _fuse.ResetButton();
    }

    [AosAction(name: "Изменить минимальное значение отклонения стрелки")]
    public void SetMinAmperValue(float value)
    {
        _pointerDevice.SetMinValue(value);
    }
    [AosAction(name: "Изменить максимальное значение отклонения стрелки")]
    public void SetMaxAmperValue(float value)
    {
        _pointerDevice.SetMaxValue(value);
    }

    [AosAction(name: "Задать значение деления")]
    public void SetDevisionValue(float value)
    {
        _pointerDevice.SetDevisionValue(value);
    }

    [AosAction(name: "Задать  угол вращение Стрелки")]
    public void SetStrelkaRotation(float value)
    {
        _pointerDevice.SetValue(value);
    }
}
