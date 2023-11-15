using AosSdk.Core.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[AosSdk.Core.Utils.AosObject(name: "AosObjectWithState")]

public class SceneAosObjectWithState : SceneAosObject
{
    [SerializeField] private BaseObjectWithState _baseObjectWithState;

    [AosAction(name: "Сломать объект")]
    public void BrokeObject() => _baseObjectWithState.BrokObject();
    [AosAction(name: "Починить объект")]
    public void RepairObject() => _baseObjectWithState.RepairObject();
}
