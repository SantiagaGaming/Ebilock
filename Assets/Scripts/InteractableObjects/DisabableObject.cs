using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisabableObject : HandObject
{
    [SerializeField] private GameObject _objectTodisable;
    public override void HandAction()
    {
        base.HandAction();
        var currentCollider = GetComponent<BoxCollider>();
        if (currentCollider != null)
        {
            currentCollider.size= new Vector3(0, 0, 0);
        }
        _objectTodisable.SetActive(false);
        
    }
}
