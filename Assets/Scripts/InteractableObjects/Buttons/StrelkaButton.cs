using AosSdk.Core.PlayerModule.Pointer;
using UnityEngine;
using TMPro;
public class StrelkaButton : BaseButton
{
    [SerializeField] private TextMeshProUGUI _buttonText;
    private SceneAosObject _currentButton;

    public override void OnClicked(InteractHand interactHand)
    {
        if (_currentButton != null)
            _currentButton.InvokeOnClick();
    }
    public void SetButtonText(string text)
    {
        _buttonText.text = text;
    }
    public void SetSceneAosId(string id)
    {
        var dietContainer = FindObjectOfType<DietButtonsContainer>();
        _currentButton = dietContainer.GetButtonById(id);
    }
}
