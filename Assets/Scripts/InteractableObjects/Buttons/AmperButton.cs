using AosSdk.Core.PlayerModule.Pointer;
using UnityEngine;
public class AmperButton : PlaceButton
{
    [SerializeField] private Transform _amperPosition;
    public override void OnClicked(InteractHand interactHand)
    {
        base.OnClicked(interactHand);
        var amper = FindObjectOfType<Ampermetr>();
        if (amper != null)
            amper.EnableAmper(_amperPosition);
    }
}

