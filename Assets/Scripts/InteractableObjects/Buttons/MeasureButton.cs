using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using AosSdk.Core.PlayerModule.Pointer;
using UnityEngine;
using UnityEngine.Events;
public class MeasureButton : BaseButton
{
    public SceneAosObject MeasureButtonObject => SceneAOSObject;
    public override void OnClicked(InteractHand interactHand)
    {
        InstanceHandler.Instance.ShupPositionChanger.SetNewShupPositon(transform,  SceneAOSObject.ObjectId);
    }
    public override void OnHoverIn(InteractHand interactHand)
    {
        transform.localScale *= 2f;
    }
    public override void OnHoverOut(InteractHand interactHand)
    {
        transform.localScale /= 2f;
    }

}