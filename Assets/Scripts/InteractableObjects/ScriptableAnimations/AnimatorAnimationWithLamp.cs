using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorAnimationWithLamp : AnimatorAnimation
{
    [SerializeField]private GameObject _lamp;

    private float _startPos = 181.01f;
    private float _endPos = 180.7f;
    private float _startRot = 0f;
    private float _endRot = 90f;
    private bool _rotate = false;
    public override void PlayScriptableAnimationOpen()
    {
        base.PlayScriptableAnimationOpen();
        StartCoroutine(LampAction(true));
    }
    public override void PlayScriptableAnimationClose()
    {
        base.PlayScriptableAnimationClose();
        StartCoroutine(LampAction(false));
    }
    private IEnumerator LampAction(bool value)
    {
 
        if (value)
        {
            yield return new WaitForSeconds(0.5f);
            while (_lamp.transform.localPosition.x > _endPos)
            {
                _lamp.transform.localPosition -= new Vector3(0.01f, 0, 0);
                yield return new WaitForSeconds(0.01f);
            }
            if (_lamp.transform.localRotation.z < _endRot)
            {
                float z = _startRot;
                while (z <= _endRot)
                {
                    _lamp.transform.localRotation = Quaternion.Euler(0, 0, z);
                    yield return new WaitForSeconds(0.01f);
                    z+=3;
                }
                _rotate= true;
                StartCoroutine(LampRotation());
            }
        }
        else
        {
            _rotate = false;
            float z = _endRot;
            while (z >= _startRot)
            {
                _lamp.transform.localRotation = Quaternion.Euler(0, 0, z);
                yield return new WaitForSeconds(0.0001f);
                z-=3;
            }
            while (_lamp.transform.localPosition.x < _startPos)
            {
                _lamp.transform.localPosition += new Vector3(0.01f, 0, 0);
                yield return new WaitForSeconds(0.01f);
            }
     
        }
    }
    private IEnumerator LampRotation()
    {
        int y = 0;
        while (_rotate)
        {
            _lamp.transform.localRotation = Quaternion.Euler(0, y, 90);
            yield return new WaitForSeconds(0.05f);
            y++;
        }  
    }
}
