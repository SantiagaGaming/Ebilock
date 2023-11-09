using AosSdk.Core.Interaction;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.PlayerModule.Pointer;
using AosSdk.Core.Utils;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

namespace AosSdk.Examples
{

    public class GrabbableScenarioObject : ScenarioObject, IGrabbable
    {
        [SerializeField] private Transform _ugrabPos;
        [field: SerializeField] public GrabType GrabType { get; set; }
        [field: SerializeField] public Transform GrabAnchor { get; set; }
        public bool IsGrabbable { get; set; } = true;
        public bool IsGrabbed { get; set; }
        public void OnGrabbed(InteractHand interactHand)
        {
            OnActionWithObject?.Invoke();
            GetComponent<Collider>().isTrigger = false;
            GetComponent<Rigidbody>().isKinematic = false;
        }
        public void OnUnGrabbed(InteractHand interactHand)
        {
    
            GetComponent<Rigidbody>().isKinematic = true;
            transform.position = _ugrabPos.position;
            transform.rotation = _ugrabPos.rotation;
            GetComponent<Collider>().isTrigger = true;
        }
        public void OnUnGrabbed(Transform newPos)
        {
            GetComponent<Rigidbody>().isKinematic = true;
            transform.position = newPos.position;
            transform.rotation = newPos.rotation;
            GetComponent<Collider>().enabled = false;
        }
        public void EventInvoke()
        {
            OnActionWithObject?.Invoke();
        }
    }
}