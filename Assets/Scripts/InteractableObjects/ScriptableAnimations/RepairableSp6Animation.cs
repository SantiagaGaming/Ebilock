using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairableSp6Animation : RepairableObject
{
    [SerializeField] private GameObject _sp6Object;

    private float _finalPos = 0.007f;
    private float _startPos;
    private void Start()
    {
        _startPos = _sp6Object.transform.localPosition.y;
    }
    public override void ToolAction()
    {
        base.ToolAction();
        StartCoroutine(RepairableAnimation());
    }
    private IEnumerator RepairableAnimation()
    {

        while (_sp6Object.transform.localPosition.y < _finalPos)
        {
            _sp6Object.transform.localPosition += new Vector3(0, 0.01f, 0);
            yield return new WaitForSeconds(0.008f);
        }
        _sp6Object.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        _sp6Object.SetActive(true);
        while (_sp6Object.transform.localPosition.y > _startPos)
        {
            _sp6Object.transform.localPosition -= new Vector3(0, 0.01f, 0);
            yield return new WaitForSeconds(0.008f);
        }
    }
}
