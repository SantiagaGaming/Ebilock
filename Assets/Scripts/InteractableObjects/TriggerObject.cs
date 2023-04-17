using System.Collections.Generic;
using System.Linq;
using AosSdk.Core.PlayerModule.Pointer;
using AosSdk.Core.Utils;
using UnityEngine;
[RequireComponent(typeof(Collider))]

public class TriggerObject : SceneObject
{
    [SerializeField] private bool _exitTriger;
    protected override void Start()
    {
        base.Start();
        IsHoverable= false;
        IsClickable= false;
    }
    private void OnTriggerEnter(Collider col)
        {
        if (_exitTriger)
            return;
        DetecoCollision(col);
    }
    private void OnTriggerExit(Collider col)
    {
        if (!_exitTriger)
            return;
        DetecoCollision(col);
        Debug.Log("Exit trigger + " + SceneAOSObject.ObjectId);
    }
    private void DetecoCollision(Collider col)
    {
        var aosObject = col.GetComponentInParent<AosObjectBase>();
        if (!aosObject)
            return;
        SceneAOSObject = GetComponent<SceneAosObject>();
        if (SceneAOSObject != null)
        {
            SceneAOSObject.InvokeOnClick();
        }
   
    }
}
