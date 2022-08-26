using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using UnityEngine;
using UnityEngine.Events;


[AosSdk.Core.Utils.AosObject(name: "Лампочка Реле")]
public class ReleLamp : AosObjectBase
{
    [SerializeField] private Lamp _lamp;


    [AosAction(name: "Сменить цвет лампочки: Красный")]
    public void SetLampColor()
    {
        _lamp.ChangeColor();
    }

    [AosAction(name: "Сминить цвет лампочки: Белый")]
    public void ResetLampColor()
    {
        _lamp.ResetColor();
    }
}
