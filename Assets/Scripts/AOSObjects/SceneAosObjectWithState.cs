using AosSdk.Core.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[AosSdk.Core.Utils.AosObject(name: "AosObjectWithState")]

public class SceneAosObjectWithState : SceneAosObject
{
    [SerializeField] private BaseObjectWithState _baseObjectWithState;

    [AosAction(name: "������� ������")]
    public void BrokeObject() => _baseObjectWithState.BrokObject();
    [AosAction(name: "�������� ������")]
    public void RepairObject() => _baseObjectWithState.RepairObject();
}
