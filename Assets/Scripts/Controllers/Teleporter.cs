using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AosSdk.Core.PlayerModule;
using UnityEngine.Events;

public class Teleporter : MonoBehaviour
{
    public UnityAction<string> OnTeleportEnd;
    public bool CanTeleport { get; set; } = true;
    private bool _menu = false;
    private bool _delay = false;

    [SerializeField] private Transform _menuPosition;
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
    [SerializeField] private Transform _str1Position;
    [SerializeField] private Transform _str3Position;
    [SerializeField] private Transform _sezd1_3Position;
    [SerializeField] private Transform _str11Position;
    [SerializeField] private Transform _svNPosition;
    [SerializeField] private Transform _svM3Position;
    [SerializeField] private Transform _svCh1Position;
    [Space]
    [SerializeField] private CameraFadeIn _cameraFadeIn;
    [SerializeField] private ModeController _modeController;

    private Vector3 _currentPlayerPosition = new Vector3();

    private string _previousLocation;

    private LocationNamesHandler _locationNamesHandler = new LocationNamesHandler();    
    public void Teleport(string locationName)
    {
   
        OnTeleportEnd?.Invoke(locationName);
        if (locationName == "start")
            TeleportPlayer(_menuPosition);
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
            else if (locationName == "str1")
            {
                TeleportPlayer(_str1Position);
            }
            else if (locationName == "str3")
            {
                TeleportPlayer(_str3Position);
            }
            else if (locationName == "sezd1-3")
            {
                TeleportPlayer(_sezd1_3Position);
            }
            else if (locationName == "str11")
            {
                TeleportPlayer(_str11Position);
            }
            else if (locationName == "sv_N")
            {
                TeleportPlayer(_svNPosition);
            }
            else if (locationName == "sv_m3")
            {
                TeleportPlayer(_svM3Position);
            }
            else if (locationName == "sv_ch1")
            {
                TeleportPlayer(_svCh1Position);
            }
            if (_previousLocation != locationName)
            {
                _previousLocation = locationName;
            }
        }       
    }
    public void TeleportToMenu()
    {
        if (_delay)
            return;
        _delay = true;
        StartCoroutine(TeleportDelay());
        if (!_menu)
        {
            _menu = true;
            _currentPlayerPosition = new Vector3(_modeController.GetPlayerTransform().position.x, 2.6f, _modeController.GetPlayerTransform().position.z); ;
            TeleportPlayer(_menuPosition);
            OnTeleportEnd?.Invoke("menu");
        }
        else
        {
            _menu = false;
            TeleportPlayer(_currentPlayerPosition);
        }
    }
    private void TeleportPlayer(Transform newPosition)
    {
        if (!CanTeleport)
            return;
        _cameraFadeIn.StartFade();
        Player.Instance.TeleportTo(newPosition);
    }
    private void TeleportPlayer(Vector3 newPos)
    {
        if (!CanTeleport)
            return;
        _cameraFadeIn.StartFade();
        Player.Instance.TeleportTo(newPos);
    }
    private IEnumerator TeleportDelay()
    {
        yield return new WaitForSeconds(1f);
        _delay = false;
    }
}
