using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointUiButton : BaseUIButton
{
    private string _pointId;
    protected override void Click()
    {
       API.Instance.OnDialogInvoke(_pointId);
    }
    public void SetButtonId(string id)
    {
        _pointId = id;
    }
}
