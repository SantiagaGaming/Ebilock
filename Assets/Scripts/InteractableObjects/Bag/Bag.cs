using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using AosSdk.Core.PlayerModule.Pointer;
using UnityEngine;
using UnityEngine.Events;
public class Bag : BaseObject
{
    [SerializeField] private GameObject _bagOpen;
    [SerializeField] private GameObject _bagClose;

    public override void OnClicked(InteractHand interactHand)
    {
            _bagOpen.SetActive(true);
            _bagClose.SetActive(false);
           GetComponent<Collider>().enabled = false;
    }
}
