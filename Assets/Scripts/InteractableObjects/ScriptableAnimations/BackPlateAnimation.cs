using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackPlateAnimation : RepairableObject
{
    [SerializeField] private GameObject _plate;

    private float _finalPos = 0.0042f;
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

        while (_plate.transform.localPosition.y < _finalPos)
        {
            _plate.transform.localPosition += new Vector3(0, 0.0001f, 0);
            yield return new WaitForSeconds(0.01f);
        }
        _plate.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        _plate.SetActive(true);
        while (_plate.transform.localPosition.y > _startPos)
        {
            _plate.transform.localPosition -= new Vector3(0, 0.0001f, 0);
            yield return new WaitForSeconds(0.01f);
        }
    }
}
