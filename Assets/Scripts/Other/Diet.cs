using AosSdk.Core.Utils;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Diet : MonoBehaviour
{
    [SerializeField] private GameObject _diet;
    [SerializeField] private StrelkaButton _strelkaMinus;
    [SerializeField] private StrelkaButton _strelkaPlus;
    [SerializeField] private StrelkaButton _indication;
    [SerializeField] private List<SceneAosObject> _radioButtons;

    private SceneAosObject _minusID;
    private SceneAosObject _plusID;
    private SceneAosObject _indicationID;
    public SceneAosObject PlusID => _plusID;
    public SceneAosObject MinusID => _minusID;
    public SceneAosObject GetIndicationID => _indicationID;
    private PlusButtonsNames _plusButtonsNames = new PlusButtonsNames();
    private MinusButtonsNames _minusButtonsNames = new MinusButtonsNames();
    private IndicationButtonsNames _indicationButtonsNames = new IndicationButtonsNames();
    public bool DietEnabler { get; set; } = false;
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

    public void EnablePlusOrMinus(string button)
    {
        if (_plusButtonsNames.FindButton(button))
        {
            var tempButton = _radioButtons.FirstOrDefault(b => b.ObjectId == button);
            _plusID = tempButton;
            _strelkaPlus.gameObject.SetActive(true);
        }
        if (_minusButtonsNames.FindButton(button))
        {
            var tempButton = _radioButtons.FirstOrDefault(b => b.ObjectId == button);
            _minusID = tempButton;
            _strelkaMinus.gameObject.SetActive(true);
        }
        if (_indicationButtonsNames.FindButton(button))
        {
            var tempButton = _radioButtons.FirstOrDefault(b => b.ObjectId == button);
            _indicationID = tempButton;
            _indication.gameObject.SetActive(true);
        }
        else if (button == null)
        {
            DisableAllButtons();
        }
    }
    private void DisableAllButtons()
    {
        _strelkaMinus.gameObject.SetActive(false);
        _strelkaPlus.gameObject.SetActive(false);
        _indication.gameObject.SetActive(false);
    }
    private void OnDisableDiet()
    {
        DietEnabler = false;
        _diet.SetActive(DietEnabler);
    }
}
