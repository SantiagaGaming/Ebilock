using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltClickableObject : ClickableObjectWithAnimation
{
    public override void PlayScriptableAnimationOpen()
    {
        StartCoroutine(PlayScriptableAnimation(true));
    }
    public override void PlayScriptableAnimationClose()
    {
        StartCoroutine(PlayScriptableAnimation(false));
    }

    private IEnumerator PlayScriptableAnimation(bool value)
    {

        if (value)
        {
            int z = 0;
            while (z <= 75)
            {
                transform.localRotation = Quaternion.Euler(-90, 0, z);
                z++;
                yield return new WaitForSeconds(0.01f);
            }
        }
        else
        {
            int z = 75;
            while (z >= 0)
            {
                transform.localRotation = Quaternion.Euler(-90, 0, z);
                z--;
                yield return new WaitForSeconds(0.01f);
            }
        }
    }
}