using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
public class LocationController : MonoBehaviour
{
    [SerializeField] private LocationText _locationText;

    private string _currentLocation = "hall";

    public void SetLocationtext(string text)
    {
        _locationText.SetLocationText(text);
    }
    public void SetLocation(string location)
    {
        _currentLocation = location;
        //StreetCollidersActivator.Instance.ActivateColliders(location);
    }
 
}
