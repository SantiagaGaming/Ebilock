using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableObjectWithAnimation : ClickableScenarioObject ,IScriptableAnimationObject
{
    private bool _open = false;
    public override void OnClicked(InteractHand interactHand)
    {
       base.OnClicked(interactHand);
        if (_open)
        {
            _open = false;
            PlayScriptableAnimationClose();
        }
        else
        {
            _open = true;
            PlayScriptableAnimationOpen();
        }
    }

    public virtual void PlayScriptableAnimationClose()
    {
        
    }

    public virtual void PlayScriptableAnimationOpen()
    {
       
    }
}
