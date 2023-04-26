using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectWithButton : SceneObject
{
    [SerializeField] protected Transform _buttonsPos;

    [SerializeField] protected DisabableObject DisabableObject;
    [SerializeField] protected RepairableObject RepairableObject;
    [SerializeField] private ObjectWithAnimation _objectWithAnimation;

    public override void OnClicked(InteractHand interactHand)
    {
        base.OnClicked(interactHand);
        InstanceHandler.Instance.MovingButtonsController.HideAllButtons();
        if (_buttonsPos == null)
            return;
        InstanceHandler.Instance.MovingButtonsController.SetCurrentBaseObjectAndMovingButtonsPosition(_buttonsPos.position, this);
        InstanceHandler.Instance.MovingButtonsController.ObjectHelperName = HelperName;
        InstanceHandler.Instance.ReactionInfoWindow.HidetextHelper();
        InstanceHandler.Instance.MovingButtonsController.HandObject = null;
        InstanceHandler.Instance.MovingButtonsController.ToolObject = null;
        InstanceHandler.Instance.SceneAosObject = SceneAOSObject;
        if (DisabableObject != null)
        {
            InstanceHandler.Instance.MovingButtonsController.HandObject = DisabableObject;
        }
        if(RepairableObject!=null)
        {
            InstanceHandler.Instance.MovingButtonsController.ToolObject = RepairableObject;
        }
        if (_objectWithAnimation != null)
        {
            InstanceHandler.Instance.AddAnimationObjectToList(_objectWithAnimation);
            _objectWithAnimation.PlayScriptableAnimationOpen();
            InstanceHandler.Instance.PlaceAnimationObject = _objectWithAnimation;
        }

    }
}
