using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectWithButton : BaseObject
{

    [SerializeField] private Transform _buttonsPos;
    [SerializeField] private bool _vertical;

    public override void OnClicked(InteractHand interactHand)
    {
        base.OnClicked(interactHand);

        if (_buttonsPos == null && !_vertical)
            MovingButtonsController.Instance.SetMovingButtonsPosition(transform.position + new Vector3(0f, 0.12f, 0));
        else if(_buttonsPos == null && _vertical)
            MovingButtonsController.Instance.SetMovingButtonsPosition(transform.position + new Vector3(0.09f, 0.05f, 0));
        else
            MovingButtonsController.Instance.SetMovingButtonsPosition(_buttonsPos.position);
        MovingButtonsController.Instance.ObjectHelperName = helperName;
        MovingButtonsController.Instance.ShowAllButtons();

    }


}
