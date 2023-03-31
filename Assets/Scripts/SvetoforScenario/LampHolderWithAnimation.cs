using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampHolderWithAnimation : ClickableObjectWithAnimation
{
    private Animator _anim;
    public override void PlayScriptableAnimationClose()
    {
      _anim = GetComponent<Animator>();
        _anim.SetTrigger("Close");
    }
    public override void PlayScriptableAnimationOpen()
    {
        _anim = GetComponent<Animator>();
        _anim.SetTrigger("Open");
    }
}
