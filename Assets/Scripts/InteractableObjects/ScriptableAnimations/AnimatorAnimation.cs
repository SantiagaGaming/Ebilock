using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorAnimation : ObjectWithAnimation
{
    [SerializeField] protected Animator Animator;

    public override void PlayScriptableAnimationOpen()
    {
        Animator.SetTrigger("Open");
    }
    public override void PlayScriptableAnimationClose()
    {
        Animator.SetTrigger("Close");
    }
}
