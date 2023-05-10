using AosSdk.Core.Utils;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEditor.Progress;

public class Diet : MonoBehaviour
{
    [SerializeField] private GameObject _diet;
    [SerializeField] private StrelkaButton[] _cButtons;

    public bool DietEnabler { get; set; } = false;
    private int _currentButtonIndex = 0;

    private void Start()
    {
        BackButton.OnBackButtonClick += OnDisableDiet;
    }

    public void EnableDiet(Transform position)
    {
        DietEnabler = !DietEnabler;
        if (DietEnabler)
        {
            _diet.transform.position = position.position;
        }
        _diet.SetActive(DietEnabler);
    }

    public void EnableDietButtons(string id, string buttonText)
    {
        Debug.Log("In Diet " + id +"  "+ buttonText);
        var tempButton = _cButtons[_currentButtonIndex];
        tempButton.SetSceneAosId(id);
        tempButton.SetButtonText(buttonText);
        tempButton.gameObject.SetActive(true);
        _currentButtonIndex++;
    }
    public void DisableAllButtons()
    {
        _currentButtonIndex = 0;
        foreach (var item in _cButtons)
        {
            item.gameObject.SetActive(false);
        }
    }
    private void OnDisableDiet()
    {
        DietEnabler = false;
        _diet.SetActive(DietEnabler);
        DisableAllButtons();
    }
}
