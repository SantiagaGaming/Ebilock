using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using AosSdk.Core.PlayerModule.Pointer;
using UnityEngine;
using UnityEngine.Events;
public class RadioButton : BaseButton
{
    [SerializeField] protected Transform _dietPosition;

    public override void OnClicked(InteractHand interactHand)
    {
        base.OnClicked(interactHand);
        InstanceHandler.Instance.Diet.EnableDiet(_dietPosition);
    }
}
