using AosSdk.Core.PlayerModule.Pointer;
using UnityEngine;
using TMPro;
public class StrelkaButton : BaseButton
{
    [SerializeField] private TextMeshProUGUI _buttonText;
    private SceneAosObject _cButton;

    public override void OnClicked(InteractHand interactHand)
    {
        Diet diet = FindObjectOfType<Diet>();
        if (diet != null && _cButton != null)
        {
            _cButton.InvokeOnClick();
            Debug.Log(_cButton.ObjectId);
        }
    }
    public void SetButtonText(string text)
    {
        _buttonText.text = text;
    }
    public void SetSceneAosId(string id)
    {
    var dietContainer = FindObjectOfType<DietButtonsContainer>();
       _cButton= dietContainer.GetButtonById(id);
    }
}
