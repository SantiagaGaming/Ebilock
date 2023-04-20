using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectWithAnimation : MonoBehaviour, IScriptableAnimationObject
{
    public virtual void PlayScriptableAnimationOpen()
    {
    }
    public virtual void PlayScriptableAnimationClose()
    {
    }
}
