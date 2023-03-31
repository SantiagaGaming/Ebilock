using AosSdk.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collide : MonoBehaviour
{
    [SerializeField] private GrabbableScenarioObject _obj;

    private void OnTriggerEnter(Collider other)
    {
   
        if (other.TryGetComponent(out ScrewCollideableObject obj))
        {
            _obj.EventInvoke();
            obj.PlayAnimation();
        }
         
    }
}
