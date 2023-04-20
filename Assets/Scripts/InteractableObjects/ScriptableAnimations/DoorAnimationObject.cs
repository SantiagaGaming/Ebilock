using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimationObject : ObjectWithAnimation
{
    [SerializeField] private bool _side;

    public override void PlayScriptableAnimationOpen()
    {
        StartCoroutine(RotateDoor());
    }
    private IEnumerator RotateDoor()
    {
        int y = 0;
        if(_side)
        {
            while (y < 90)
            {
                transform.localRotation = Quaternion.Euler(0, y, 0);
                y++;
                yield return new WaitForSeconds(0.01f);
            }
        }
        else if(!_side)
        {
            while (y > -90)
            {
                transform.localRotation = Quaternion.Euler(0, y, 0);
                y--;
                yield return new WaitForSeconds(0.01f);
            }
        }
    }
}
