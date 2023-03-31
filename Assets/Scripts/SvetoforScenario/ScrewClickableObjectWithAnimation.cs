using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrewClickableObjectWithAnimation : ClickableObjectWithAnimation
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
            int x = -120;
            while (x <= 0)
            {
                transform.localRotation = Quaternion.Euler(x, 0, 0);
                transform.localPosition -= new Vector3(0.000001f, 0, 0);
                x++;
                yield return new WaitForSeconds(0.005f);
            }
        }
        else 
        {
            int x = 0;
            while (x >= -120)
            {
                transform.localRotation = Quaternion.Euler(x, 0, 0);
                transform.localPosition += new Vector3(0.000001f, 0, 0);
                x--;
                yield return new WaitForSeconds(0.005f);
            }
    
        }
    }
}

