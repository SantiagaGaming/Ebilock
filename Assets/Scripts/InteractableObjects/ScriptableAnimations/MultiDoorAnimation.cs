using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum DoorRotationSide
{
    X,
    Y,
    Z
}
public class MultiDoorAnimation : ObjectWithAnimation
{
    [SerializeField] private GameObject _door;
    [SerializeField] private DoorRotationSide _doorRotationSide;

    [SerializeField] private  float _startDegree;
    [SerializeField] private float _finishDegree;
    public override void PlayScriptableAnimationOpen()
    {
        base.PlayScriptableAnimationOpen();
        StartCoroutine(Rotate(true));
    }
    public override void PlayScriptableAnimationClose()
    {
        base.PlayScriptableAnimationClose();
        StartCoroutine(Rotate(false));
    }
    private IEnumerator Rotate(bool open)
    {
        if(open)
        {
          float rotationDegree = _startDegree;
           while (rotationDegree < _finishDegree)
           {
            SetRotationSide(rotationDegree);
            rotationDegree++;
            yield return new WaitForSeconds(0.01f);
                }
            }
        else
        {
            float rotationDegree = _finishDegree;
            while (rotationDegree > _startDegree)
            {
            SetRotationSide(rotationDegree);
            rotationDegree--;
            yield return new WaitForSeconds(0.01f);
            }
        }
    }
    private void SetRotationSide(float rotationDegree)
    {
        switch (_doorRotationSide)
        {
            case DoorRotationSide.X:
                _door.transform.localRotation = Quaternion.Euler(rotationDegree, _door.transform.localRotation.y, _door.transform.localRotation.z);
                break;
            case DoorRotationSide.Y:
                _door.transform.localRotation = Quaternion.Euler(_door.transform.localRotation.x, rotationDegree, _door.transform.localRotation.z);
                break;
            case DoorRotationSide.Z:
                _door.transform.localRotation = Quaternion.Euler(_door.transform.localRotation.x, _door.transform.localRotation.y, rotationDegree);
                break;
        }
    }
 }

