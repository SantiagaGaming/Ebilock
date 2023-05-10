using AosSdk.Core.PlayerModule.Pointer;
using UnityEngine;
using TMPro;
public class StrelkaButton : BaseButton
{
    [SerializeField] private TextMeshProUGUI _buttonText;
    [SerializeField] private SceneAosObject _cButton;

    public override void OnClicked(InteractHand interactHand)
    {
        Diet diet = FindObjectOfType<Diet>();
        if (diet != null && _cButton!=null)
        {
            _cButton.InvokeOnClick();
        }
    }
    public void SetButtonText(string text)
    {
        _buttonText.text = text;
    }
    public void SetSceneAosId(string newId)
    {
        if(_cButton!=null)
            _cButton.ObjectId= newId;
    }
}
