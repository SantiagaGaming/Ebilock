using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using UnityEngine;
[AosSdk.Core.Utils.AosObject(name: "�����")]

public class MaterialChanger : AosObjectBase
{
    [SerializeField] private GameObject _lamp;
    [SerializeField] private Material _none;
    [SerializeField] private Material _bright;

    [AosAction(name: "��������� �������� ����")]
    public void LampTurnOn()
    {
        _lamp.GetComponent<Renderer>().material = _bright;
    }
    [AosAction(name: "��������� �������� ����")]
    public void LampTurnOff()
    {
        _lamp.GetComponent<Renderer>().material = _none;
    }
}
