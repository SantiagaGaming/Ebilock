using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScenarioObjectsHandler : MonoBehaviour
{
    [SerializeField] private ScenarioObject[] _scenarioObjects;
    public void DiableAllScenarioObjects()
    {
        foreach (var item in _scenarioObjects)
        {
            item.EnableObject(false);
        }
    }
    public void EnableObjectByName(string name)
    {
        var obj = _scenarioObjects.FirstOrDefault(o => o.ObjectName == name);
        if (obj != null)
            obj.EnableObject(true);
    }
    public ScenarioObject[] ScenarioObjects => _scenarioObjects;
}
