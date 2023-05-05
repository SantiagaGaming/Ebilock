using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using UnityEngine;
[AosSdk.Core.Utils.AosObject(name: "Лампа")]

public class MaterialChanger : AosObjectBase
{
    [SerializeField] private GameObject _lamp;
    [SerializeField] private Material _none;
    [SerializeField] private Material _bright;

    [AosAction(name: "Проиграть анимацию плюс")]
    public void LampTurnOn()
    {
        _lamp.GetComponent<Renderer>().material = _bright;
    }
    [AosAction(name: "Проиграть анимацию плюс")]
    public void LampTurnOff()
    {
        _lamp.GetComponent<Renderer>().material = _none;
    }
}
