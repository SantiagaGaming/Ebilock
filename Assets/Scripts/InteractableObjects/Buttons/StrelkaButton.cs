using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using AosSdk.Core.PlayerModule.Pointer;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class StrelkaButton : BaseButton
{
    [SerializeField] private Side _currentSide;
    private enum Side
    {
        Plus,
        Minus,
        Indication
    }
    public override void OnClicked(InteractHand interactHand)
    {
        Diet diet = FindObjectOfType<Diet>();
        if (diet != null)
        {
            if (_currentSide == Side.Plus)
                diet.PlusID.InvokeOnClick();
            else if (_currentSide == Side.Minus)
                diet.MinusID.InvokeOnClick();
            else if (_currentSide == Side.Indication)
                diet.GetIndicationID.InvokeOnClick();
        }
    }
}
