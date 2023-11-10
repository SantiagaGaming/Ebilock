using AosSdk.Core.Utils;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Diet : MonoBehaviour
{
    [SerializeField] private RadioUiButton[] _cButtons;

    public bool DietEnabler { get; set; } = false;
    private int _currentButtonIndex = 0;

    private void Start()
    {
        BackButton.OnBackButtonClick += OnDisableDiet;
    }

    public void EnableDietButtons(string id, string buttonText)
    {
        Debug.Log("In Diet " + id +"  "+ buttonText);
        var tempButton = _cButtons[_currentButtonIndex];
        tempButton.SetSceneAosId(id);
        tempButton.SetButtonText(buttonText);
        tempButton.GetComponent<Image>().enabled = true;
        tempButton.GetComponent<Button>().enabled = true;
        _currentButtonIndex++;
    }
    public void DisableAllButtons()
    {
        _currentButtonIndex = 0;
        foreach (var item in _cButtons)
        {
            item.GetComponent<Image>().enabled = false;
            item.GetComponent<Button>().enabled = false;
            item.GetComponentInChildren<TextMeshProUGUI>().text = "";
        }
    }
    private void OnDisableDiet()
    {
        DietEnabler = false;
        DisableAllButtons();
    }
}
