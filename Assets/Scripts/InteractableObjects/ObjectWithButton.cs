using AosSdk.Core.PlayerModule.Pointer;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectWithButton : SceneObject
{
    public static Action<ObjectWithButton> ObjectWithButtonClickedEvent;
    [SerializeField] protected Transform _buttonsPos;

    [SerializeField] private DisabableObject _disabableObject;
    [SerializeField] private RepairableObject _repairableObject;
    [SerializeField] private HandRotationObject _handRotationObject;
    [SerializeField] private ObjectWithAnimation _objectWithAnimation;
    public DisabableObject DisabableObject => _disabableObject;
    public RepairableObject RepairableObject => _repairableObject;
    public HandRotationObject HandRotationObject => _handRotationObject;

    public override void OnClicked(InteractHand interactHand)
    {
        base.OnClicked(interactHand);
       
        if (_objectWithAnimation != null)
        {
            InstanceHandler.Instance.AddAnimationObjectToList(_objectWithAnimation);
            _objectWithAnimation.PlayScriptableAnimationOpen();
            InstanceHandler.Instance.PlaceAnimationObject = _objectWithAnimation;
          
        }
    }
}
