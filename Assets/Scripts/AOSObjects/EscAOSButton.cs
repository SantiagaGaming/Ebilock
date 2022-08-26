using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using UnityEngine;
using UnityEngine.Events;
[AosSdk.Core.Utils.AosObject(name: "EscAOS Button")]
public class EscAOSButton : AosObjectBase
{

    [AosEvent(name: "Попытка перевода стрелки в плюс")]
    public event AosEventHandler EscButtonPressedEvent;
    public void EscButtonPressed()
    {
        EscButtonPressedEvent?.Invoke();
    }
}
