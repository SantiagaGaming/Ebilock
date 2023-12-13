using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceObject : SceneObject
{
    [SerializeField] private BackButton _backButton;
    [SerializeField] private Transform _reactionPos;
    [SerializeField] private ObjectWithAnimation _objectWithAnimation;
    public override void OnClicked(InteractHand interactHand)
    {
        base.OnClicked(interactHand);
        if (_backButton != null)
            InstanceHandler.Instance.SetCurrentBackButton(_backButton);
        //if (_reactionPos != null)
        //    InstanceHandler.Instance.ReactionInfoWindow.SetPosition(_reactionPos);
        if (_objectWithAnimation != null)
        {
            InstanceHandler.Instance.AddAnimationObjectToList(_objectWithAnimation);
            _objectWithAnimation.PlayScriptableAnimationOpen();
            InstanceHandler.Instance.PlaceAnimationObject = _objectWithAnimation;
        }
        InstanceHandler.Instance.BackTriggersHoler.EnableCurrentTrigger(true);
    }
}