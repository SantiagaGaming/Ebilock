using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using UnityEngine;
using AosSdk.Core.PlayerModule;
using AosSdk.Core.PlayerModule.Pointer;
using UnityEngine.Events;
[AosSdk.Core.Utils.AosObject(name: "Телепорт")]

public class Teleporter : AosObjectBase
{
    [SerializeField] private CameraFlash _cameraFlash;
    [SerializeField] private GameObject _descPlayer;
    [SerializeField] private GameObject _vrPlayer;
    [SerializeField] private Transform _corridorFromFieldPosition;
    [SerializeField] private Transform _fieldPosition;
    [SerializeField] private Transform _corridorFromRelePosition;
    [SerializeField] private Transform _relePosition;
    [SerializeField] private Transform _corridorFromDspPosition;
    [SerializeField] private Transform _dspPosition;

    [AosAction(name: "Телепорт в ДСП из коридора метод")]
    public void TeleportToDsp()
    {
        TeleportPlayer(_dspPosition);
    }
    [AosAction(name: "Телепорт в коридор из ДСП метод")]
    public void TeleportToCorridorFromDsp()
    {
        TeleportPlayer(_corridorFromDspPosition);
    }
    [AosAction(name: "Телепорт в Реле из коридора метод")]
    public void TeleportToRele()
    {
        TeleportPlayer(_relePosition);
    }
    [AosAction(name: "Телепорт в коридор из Реле метод")]
    public void TeleportToCorridorFromRele()
    {
        TeleportPlayer(_corridorFromRelePosition);
    }
    [AosAction(name: "Телепорт на поле из коридора метод")]
    public void TeleportToField()
    {
        TeleportPlayer(_fieldPosition);
    }
    [AosAction(name: "Телепорт в коридор с поля метод")]
    public void TeleportToCorridorFromStreet()
    {
        TeleportPlayer(_corridorFromFieldPosition);
    }

    private void TeleportPlayer(Transform newPosition)
    {
        Player.Instance.TeleportTo(newPosition);
        _descPlayer.transform.rotation = newPosition.rotation;
        _vrPlayer.transform.rotation = newPosition.rotation;
        _cameraFlash.CameraFlashStart();
    }

}
