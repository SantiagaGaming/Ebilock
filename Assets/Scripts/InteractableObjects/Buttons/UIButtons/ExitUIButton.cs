using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitUIButton : BaseUIButton
{
    private const string EXIT = "exit";
    protected override void Click()
    {
      API.Instance.OnInvokeNavAction(EXIT);
    }
}
