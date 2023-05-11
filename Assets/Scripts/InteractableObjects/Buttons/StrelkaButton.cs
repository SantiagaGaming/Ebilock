using AosSdk.Core.PlayerModule.Pointer;
using UnityEngine;
using TMPro;
public class StrelkaButton : BaseButton
{
    [SerializeField] private TextMeshProUGUI _buttonText;
    private string _buttonId;

    public override void OnClicked(InteractHand interactHand)
    {
        if (_buttonId != null)
        {
            var dietContainer = FindObjectOfType<DietButtonsContainer>();
            var button = dietContainer.GetButtonById(_buttonId);
            button.InvokeOnClick();
            Debug.Log(button.ObjectId + " Finded Button!");
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
