using UnityEngine;

public class HelpTextController : MonoBehaviour
{
    [SerializeField] private ModeController _modeController;
    [SerializeField] private MovingTextWindow _helperWindow;
    [SerializeField] private MovingTextWindow _reactionWindow;
    [SerializeField] private HelperCanvas _helperCanvas;
    public void ShowHelperText(Transform pos, string text)
    {
        if (!_modeController.VrMode)
        {
            _helperCanvas.EnableHelperWindow(true);
            _helperCanvas.SetHelperText(text);
        }
        else
        {
            _helperWindow.SetTransfromAndText(pos,text);
        }
    }
    public void HideHelperText()
    {
        if (!_modeController.VrMode)
        {
            _helperCanvas.EnableHelperWindow(false);
            _helperCanvas.SetHelperText("");
        }
        else
            _helperWindow.SetTransfromAndText(null, null);
    }
    public void SetReactionText(string text)
    {
        if (!_modeController.VrMode)
        {
            _helperCanvas.SetReactionText(text);
            _helperCanvas.EnableReactionWindow(true);
        }

    }
    public void SetReactionPosition(Transform pos)
    {
        if (!_modeController.VrMode)
            return;

    }
    public void HideReactionText()
    {
        if (!_modeController.VrMode)
        {
            _helperCanvas.EnableReactionWindow(false);
            _helperCanvas.SetReactionText("");
        }
    }
}
