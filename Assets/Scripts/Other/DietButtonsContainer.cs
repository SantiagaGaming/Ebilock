using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DietButtonsContainer : MonoBehaviour
{
    [SerializeField] private SceneAosObject[] _buttons;
    public SceneAosObject GetButtonById(string id)
    {
        var button = _buttons.FirstOrDefault(b => b.ObjectId == id);
            if(button!=null)
        {
            Debug.Log(button.ObjectId + " From diet container");
            return button;
        }
        
        return null;
    }

}
