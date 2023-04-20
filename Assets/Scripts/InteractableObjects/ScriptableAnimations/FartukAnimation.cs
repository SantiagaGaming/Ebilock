using AosSdk.Core.PlayerModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FartukAnimation : ObjectWithAnimation
{
    [SerializeField] private GameObject _roof;

    public override void PlayScriptableAnimationOpen()
    {
        StartCoroutine(RoofRotator(true));
    }
    public override void PlayScriptableAnimationClose()
    {
        StartCoroutine(RoofRotator(false));
    }
    private IEnumerator RoofRotator(bool value)
    {
        if (value)
        {
            int x = 0;
            while (x <= 90)
            {
                _roof.transform.localRotation = Quaternion.Euler(x, 0, 0);
                x++;
                yield return new WaitForSeconds(0.001f);
            }
        }
        else
        {
            int x = 90;
            while (x >= 0)
            {
                _roof.transform.localRotation = Quaternion.Euler(x, 0, 0);
                x--;
                yield return new WaitForSeconds(0.001f);
            }
        }
    }
}
