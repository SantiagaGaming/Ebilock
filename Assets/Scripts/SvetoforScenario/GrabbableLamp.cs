using AosSdk.Core.Interaction;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.PlayerModule.Pointer;
using AosSdk.Core.Utils;
using UnityEngine;

namespace AosSdk.Examples
{
    public class GrabbableLamp : ScenarioObject, IGrabbable
    {
        [field: SerializeField] public GrabType GrabType { get; set; }

        [field: SerializeField] public Transform GrabAnchor { get; set; }

        public bool IsGrabbable { get; set; } = true;

        public bool IsGrabbed { get; set; }

        public void OnGrabbed(InteractHand interactHand)
        {
            OnActionWithObject?.Invoke();
            GetComponent<Collider>().isTrigger = false;
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<Rigidbody>().useGravity = true;
        }

        public void OnUnGrabbed(InteractHand interactHand)
        {

        }

    }
}