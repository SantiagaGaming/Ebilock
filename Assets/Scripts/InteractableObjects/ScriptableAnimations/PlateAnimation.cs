using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateAnimation : RepairableObject
{
    [SerializeField] private Animator _anim;
    [SerializeField] private GameObject _plate;
    [SerializeField] private GameObject _rotator;

    private float _finalPos= -0.005f;
    private float _startPos;
    private void Start()
    {
        _startPos = _plate.transform.localPosition.y;
    }
    public override void ToolAction()
    {
        base.ToolAction();
        StartCoroutine(RepairableAnimation());
    }
    private IEnumerator RepairableAnimation()
    {
        _anim.SetTrigger("Open");
        yield return new WaitForSeconds(1.2f);
        int x = 0;
        while (x<=65)
        {
            _rotator.transform.localEulerAngles += new Vector3(1, 0, 0);
            x++;
            yield return new WaitForSeconds(0.005f);
        }
        while (_plate.transform.localPosition.y > _finalPos)
        {
            _plate.transform.localPosition -= new Vector3(0, 0.0001f, 0);
            yield return new WaitForSeconds(0.01f);
        }
        _plate.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        _plate.SetActive(true);
        while (_plate.transform.localPosition.y < _startPos)
        {
            _plate.transform.localPosition += new Vector3(0, 0.0001f, 0);
            yield return new WaitForSeconds(0.01f);
        }
        while (x >= 0)
        {
            _rotator.transform.localEulerAngles -= new Vector3(1, 0, 0);
            x--;
            yield return new WaitForSeconds(0.005f);
        }
        _anim.SetTrigger("Close");
    }
}
