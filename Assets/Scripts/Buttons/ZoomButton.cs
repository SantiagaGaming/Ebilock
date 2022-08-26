using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using AosSdk.Core.PlayerModule.Pointer;
using UnityEngine;
using UnityEngine.Events;

public class ZoomButton : BaseButton
{
    [SerializeField] private ZoomController _playerInventController;
    public override void OnClicked(InteractHand interactHand)
    {
       // _playerInventController.ZoomCamera();
    }
}
