using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableScenarioObject : ScenarioObject
{
    public override void OnClicked(InteractHand interactHand)
    {
        OnActionWithObject?.Invoke();
    }
}
