using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using UnityEngine;
using UnityEngine.Events;


[AosSdk.Core.Utils.AosObject(name: "Желтая лампочка")]
public class YellowLamp : AosObjectBase
{
    [SerializeField] private Lamp _lamp;


    [AosAction(name: "Сминить цвет лампочки: Желтый")]
    public void SetLampColor()
    {
        _lamp.ChangeColor();
    }

    [AosAction(name: "Сминить цвет лампочки: Черный")]
    public void ResetLampColor()
    {
        _lamp.ResetColor();
    }
}
