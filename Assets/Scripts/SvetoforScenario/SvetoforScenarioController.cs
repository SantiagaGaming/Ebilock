using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SvetoforScenarioController : MonoBehaviour
{
    [SerializeField] private ScenarioObjectsHandler _scenarioObjectsHandler;
    private int _step;

    private void Start()
    {
        foreach (var obj in _scenarioObjectsHandler.ScenarioObjects)
        {
            obj.OnActionWithObject += OnStartScenarioStep;
        }
        _scenarioObjectsHandler.DiableAllScenarioObjects();
        OnStartScenarioStep();
    }

    private void OnStartScenarioStep()
    {
        _scenarioObjectsHandler.DiableAllScenarioObjects();
        if (_step == 0)
        {
            _scenarioObjectsHandler.EnableObjectByName("Bag");
        }
        else if(_step == 1)
        {
            _scenarioObjectsHandler.EnableObjectByName("Screw");
        }
        else if (_step == 2)
        {
            _scenarioObjectsHandler.EnableObjectByName("Screw");
            _scenarioObjectsHandler.EnableObjectByName("Nut1");
        }
        else if (_step == 3)
        {
            _scenarioObjectsHandler.EnableObjectByName("Bolt1");
        }
  
        else if (_step == 4)
        {
            _scenarioObjectsHandler.EnableObjectByName("Cap1");
        }
        else if (_step == 5)
        {
            _scenarioObjectsHandler.EnableObjectByName("LampHolder1");
          
        }
        else if (_step == 6)
        {
            _scenarioObjectsHandler.EnableObjectByName("LampBroken");
            Debug.Log("Lampa");
           
        }
        else if (_step == 7)
        {
            _scenarioObjectsHandler.EnableObjectByName("Screw");
        }
        else if (_step == 8)
        {
            _scenarioObjectsHandler.EnableObjectByName("Screw");
            _scenarioObjectsHandler.EnableObjectByName("Nut2");
        }
 
        else if (_step == 9)
        {
            _scenarioObjectsHandler.EnableObjectByName("Bolt2");
        }
        else if (_step == 10)
        {
            _scenarioObjectsHandler.EnableObjectByName("Cap2");
        }
        else if (_step == 11)
        {
            _scenarioObjectsHandler.EnableObjectByName("LampHolder2");
        }
        else if (_step == 12)
        {
            _scenarioObjectsHandler.EnableObjectByName("LampUsed");
        }
        else if (_step == 13)
        {
            _scenarioObjectsHandler.EnableObjectByName("LampUsed");
            _scenarioObjectsHandler.EnableObjectByName("LampPosition1");
            
        }
        else if (_step == 14)
        {
            _scenarioObjectsHandler.EnableObjectByName("LampHolder1");
        }
        else if (_step == 15)
        {
            _scenarioObjectsHandler.EnableObjectByName("Cap1");
        }
        else if (_step == 16)
        {
            _scenarioObjectsHandler.EnableObjectByName("Bolt1");
        }
        else if (_step == 17)
        {
            _scenarioObjectsHandler.EnableObjectByName("Screw");
        }
        else if (_step == 18)
        {
            _scenarioObjectsHandler.EnableObjectByName("Screw");
            _scenarioObjectsHandler.EnableObjectByName("Nut1");
        }
    
        else if (_step == 19)
        {
            _scenarioObjectsHandler.EnableObjectByName("LampNew");
        }
        else if (_step == 20)
        {
            _scenarioObjectsHandler.EnableObjectByName("LampNew");
            _scenarioObjectsHandler.EnableObjectByName("LampPosition2");
        }
        else if (_step == 21)
        {
            _scenarioObjectsHandler.EnableObjectByName("LampHolder2");
        }
        else if (_step == 22)
        {
            _scenarioObjectsHandler.EnableObjectByName("Cap2");
        }
        else if (_step == 23)
        {
            _scenarioObjectsHandler.EnableObjectByName("Bolt2");
        }
        else if (_step == 24)
        {
            _scenarioObjectsHandler.EnableObjectByName("Screw");
        }
        else if (_step == 25)
        {
            _scenarioObjectsHandler.EnableObjectByName("Screw");
            _scenarioObjectsHandler.EnableObjectByName("Nut2");
        }
        Debug.Log("Sucess! " + _step);


        _step++;
    }





}
