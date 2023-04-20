using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorAnimation : ObjectWithAnimation
{
    [SerializeField] private Animator _animator;
    public override void PlayScriptableAnimationOpen()
    {
        _animator.SetTrigger("Open");
    }
    public override void PlayScriptableAnimationClose()
    {
        _animator.SetTrigger("Close");
    }
}
