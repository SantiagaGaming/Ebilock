using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using AosSdk.Core.PlayerModule.Pointer;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class OscilLeverArmButton : BaseButton
{
    [SerializeField] private bool _left;
    [SerializeField] private GameObject _leverArm;
    [SerializeField] private GameObject _strelka;

    public override void OnClicked(InteractHand interactHand)
    {
        if(_left)
        {
            _leverArm.transform.localRotation *= Quaternion.Euler(0, -15f, 0);
        }
        else
        {
            _leverArm.transform.localRotation *= Quaternion.Euler(0, 15f, 0);
        }
    }
}
