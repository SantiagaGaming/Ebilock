using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseReactionCanvasButton : BaseButton
{
    [SerializeField] private GameObject _canvas;
    public override void OnClicked(InteractHand interactHand)
    {
    _canvas.SetActive(false);
    }
}
