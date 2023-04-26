using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandRotationObject : HandObject
{
    [SerializeField] private GameObject _toggle;

    private bool _rotate = false;
    public override void HandAction()
    {
        base.HandAction();
        StartCoroutine(Rotate());
    }
    private IEnumerator Rotate()
    {
        if(!_rotate)
        {
            int x = 0;
            _rotate = true;
            while (x < 65)
            {
                _toggle.transform.localEulerAngles += new Vector3(1, 0, 0);
                yield return new WaitForSeconds(0.005f);
                x++;
            }
        }
        else
        {
            int x = 65;
            _rotate = false;
            while (x > 0)
            {
                _toggle.transform.localEulerAngles -= new Vector3(1, 0, 0);
                yield return new WaitForSeconds(0.005f);
                x--;
            }
        }

    }
}
