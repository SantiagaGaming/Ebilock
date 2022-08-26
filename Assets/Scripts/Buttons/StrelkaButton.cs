using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using AosSdk.Core.PlayerModule.Pointer;
using UnityEngine;
using UnityEngine.Events;
public class StrelkaButton : BaseButton
{
    [SerializeField] private bool _side;
    public override void OnClicked(InteractHand interactHand)
    {
        StrelkaAOS strelka = FindObjectOfType<StrelkaAOS>();
        if (_side)
            strelka.TrySwitchStrelkaPlus();
        else
            strelka.TrySwitchStrelkaMinus();
    }
}
