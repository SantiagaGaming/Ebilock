using System.Collections.Generic;
using System.Linq;
using AosSdk.Core.Utils;
using UnityEngine;

namespace AosSdk.CommonBehaviours
{
    [RequireComponent(typeof(Collider))]
    public class TriggerObject : AosObjectBase
    {
        private Collider _thisCollider;
        [AosEvent(name: "При попадании объекта в триггер")]
        public event AosEventHandlerWithAttribute OnObjectTriggerEnter;

        private void Awake()
        {
            _thisCollider = GetComponent<Collider>();

            if (_thisCollider.isTrigger)
            {
                return;
            }
            _thisCollider.isTrigger = true;
        }

        private void OnTriggerEnter(Collider col)
        {
            var aosObject = col.GetComponentInParent<AosObjectBase>();
            if (!aosObject)
            {
                return;
            }
            OnObjectTriggerEnter?.Invoke(ObjectId);

        }


    }
}