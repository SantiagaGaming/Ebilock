using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkafDoorAnimation : ObjectWithAnimation
{
    [SerializeField] private bool _side;
    public override void PlayScriptableAnimationOpen()
    {
        StartCoroutine(RotateDoorOpen());
    }
    public override void PlayScriptableAnimationClose()
    {
        StartCoroutine(RotateDoorClose());
    }
    private IEnumerator RotateDoorOpen()
    {
        int y = 0;

        if (_side)
        {
            while (y < 90)
            {
                transform.localRotation = Quaternion.Euler(0, y, 0);
                y++;
                yield return new WaitForSeconds(0.01f);
            }
        }
        else if (!_side)
        {
            while (y > -90)
            {
                transform.localRotation = Quaternion.Euler(0, y, 0);
                y--;
                yield return new WaitForSeconds(0.01f);
            }
        }
    }
    private IEnumerator RotateDoorClose()
    {
        if (_side)
        {
            int y = 90;
            while (y >= 0)
            {
                transform.localRotation = Quaternion.Euler(0, y, 0);
                y--;
                yield return new WaitForSeconds(0.01f);
            }
        }
        else if (!_side)
        {
            int y = -90;
            while (y <= 0)
            {
                transform.localRotation = Quaternion.Euler(0, y, 0);
                y++;
                yield return new WaitForSeconds(0.01f);
            }
        }

    }
}