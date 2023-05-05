using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using UnityEngine;
[AosSdk.Core.Utils.AosObject(name: "Анимация Стрелки 11")]
public class StrelkaAnimation : AosObjectBase
{
    [SerializeField]private Animator _anim;

    private const string MINUS_ANIM = "minusAnim";
    private const string PLUS_ANIM = "plusAnim";

    [AosAction(name: "Проиграть анимацию плюс")]
    public void PlayPlusAnim()
    {
        _anim.SetTrigger(PLUS_ANIM);
    }
    [AosAction(name: "Проиграть анимацию минус")]
    public void PlayMinusAnim()
    {
        _anim.SetTrigger(MINUS_ANIM);
    }
}

