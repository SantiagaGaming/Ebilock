using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidableObject : ClickableScenarioObject
{
    [SerializeField] private GameObject _showObj;
    [SerializeField] private GameObject _hideObj;
    public override void OnClicked(InteractHand interactHand)
    {
        base.OnClicked(interactHand);
        _showObj.SetActive(true);
        _hideObj.SetActive(false);
        EnableObject(false);
    }
}
