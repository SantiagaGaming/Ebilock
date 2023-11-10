using AosSdk.Core.PlayerModule.Pointer;
using UnityEngine;
using TMPro;
public class RadioUiButton : BaseUIButton
{
    [SerializeField] private TextMeshProUGUI _buttonText;
    private string _buttonId;

    protected override void Click()
    {
        if (_buttonId != null)
        {
            var dietContainer = FindObjectOfType<DietButtonsContainer>();
            var button = dietContainer.GetButtonById(_buttonId);
            button.InvokeOnClick();
            Debug.Log("Click button radio");
        }
    }
    public void SetButtonText(string text)
    {
        _buttonText.text = text;
    }
    public void SetSceneAosId(string id)
    {
      _buttonId= id;
    }
}
