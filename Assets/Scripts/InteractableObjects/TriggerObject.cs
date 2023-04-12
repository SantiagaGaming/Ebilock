using System.Collections.Generic;
using System.Linq;
using AosSdk.Core.PlayerModule.Pointer;
using AosSdk.Core.Utils;
using UnityEngine;
[RequireComponent(typeof(Collider))]

public class TriggerObject : SceneObject
{
    [SerializeField] private SceneAosObject _exitObject;
    protected override void Start()
    {
        base.Start();
        IsHoverable= false;
        IsClickable= false;
    }
    private void OnTriggerEnter(Collider col)
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
    private void OnTriggerExit(Collider col)
    {
            var aosObject = col.GetComponentInParent<AosObjectBase>();
            if (!aosObject)
                return;
            _exitObject.InvokeOnClick();
    }
}
