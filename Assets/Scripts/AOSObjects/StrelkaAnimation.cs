using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using UnityEngine;
[AosSdk.Core.Utils.AosObject(name: "�������� ������� 11")]
public class StrelkaAnimation : AosObjectBase
{
    [SerializeField]private Animator _anim;

    private const string MINUS_ANIM = "minusAnim";
    private const string PLUS_ANIM = "plusAnim";

    [AosAction(name: "��������� �������� ����")]
    public void PlayPlusAnim()
    {
        _anim.SetTrigger(PLUS_ANIM);
    }
    [AosAction(name: "��������� �������� �����")]
    public void PlayMinusAnim()
    {
        _anim.SetTrigger(MINUS_ANIM);
    }
}

