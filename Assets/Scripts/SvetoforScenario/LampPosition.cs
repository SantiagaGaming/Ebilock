
using UnityEngine;

public class LampPosition : ScenarioObject
{
    [SerializeField] private Transform _newLampPosition;

    public Transform NewLampPosition() => _newLampPosition;
}
