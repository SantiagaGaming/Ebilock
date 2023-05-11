using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using AosSdk.Core.PlayerModule.Pointer;
using UnityEngine;
using UnityEngine.Events;
public class RadioButton : BaseButton
{
    [SerializeField] protected Transform _dietPosition;
    protected override void Start()
    {
        base.Start();
        _dietPosition.transform.parent = null;
    }

    public override void OnClicked(InteractHand interactHand)
    {
        base.OnClicked(interactHand);
        InstanceHandler.Instance.Diet.EnableDiet(_dietPosition);
    }
}
