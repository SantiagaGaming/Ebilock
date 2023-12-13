using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AosSdk.Core.PlayerModule;
using UnityEngine.Events;

public class Teleporter : MonoBehaviour
{
    public UnityAction<string> TeleportEndEvent;
    public bool CanTeleport { get; set; } = true;
    [SerializeField] private Transform _hallFieldPosition;
    [SerializeField] private Transform _hallFeedPosition;
    [SerializeField] private Transform _hallDspPosition;
    [SerializeField] private Transform _hallShnPosition;
    [SerializeField] private Transform _hallRelay1Position;
    [SerializeField] private Transform _hallRelay2Position;
    [SerializeField] private Transform _hallFromFieldPosition;
    [SerializeField] private Transform _hallFromFeedPosition;
    [SerializeField] private Transform _hallFromDspPosition;
    [SerializeField] private Transform _hallFromShnPosition;
    [SerializeField] private Transform _hallFromRelay1Position;
    [SerializeField] private Transform _hallFromRelay2Position;
    [Space]
    [SerializeField] private CameraFlash _cameraFlash;
    [SerializeField] private ModeController _modeController;


    private string _previousLocation;

    private LocationNamesHandler _locationNamesHandler = new LocationNamesHandler();    
    public void Teleport(string locationName)
    {
   
        TeleportEndEvent?.Invoke(locationName);

    
        if (_locationNamesHandler.ChekLacationNames(locationName))
        { 
            if (_previousLocation == locationName)
                return;
            Debug.Log(locationName + "From teleport Loc " + _previousLocation);
            if (locationName == "hall" && _previousLocation == "r_dsp")
            {
                TeleportPlayer(_hallFromDspPosition);
            }
            else if (locationName == "hall" && _previousLocation == "field")
            {
                TeleportPlayer(_hallFromFieldPosition);
            }
            else if (locationName == "hall" && _previousLocation == "r_shn")
            {
                TeleportPlayer(_hallFromShnPosition);
            }
            else if (locationName == "hall" && _previousLocation == "relay1")
            {
                TeleportPlayer(_hallFromRelay1Position);
            }
            else if (locationName == "hall" && _previousLocation == "relay2")
            {
                TeleportPlayer(_hallFromRelay2Position);
            }
            else if (locationName == "hall" && _previousLocation == "feed")
            {
                TeleportPlayer(_hallFromFeedPosition);
            }
            else if (locationName == "hall")
            {
                TeleportPlayer(_hallFromFieldPosition);
            }
            else if (locationName == "field")
            {
                TeleportPlayer(_hallFieldPosition);
            }
            else if (locationName == "r_dsp")
            {
                TeleportPlayer(_hallDspPosition);
            }
            else if (locationName == "r_shn")
            {
                TeleportPlayer(_hallShnPosition);
            }
            else if (locationName == "relay1")
            {
                TeleportPlayer(_hallRelay1Position);
            }
            else if (locationName == "relay2")
            {
                TeleportPlayer(_hallRelay2Position);
            }
            else if (locationName == "feed")
            {
                TeleportPlayer(_hallFeedPosition);
            }
            if (_previousLocation != locationName)
            {
                _previousLocation = locationName;
            }
        }       
    }
    private void TeleportPlayer(Transform newPosition)
    {
        if (!CanTeleport)
            return;
        _cameraFlash.CameraFlashStart();
        Player.Instance.TeleportTo(newPosition);
    }
}
