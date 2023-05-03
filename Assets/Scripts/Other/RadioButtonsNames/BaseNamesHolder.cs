

using System.Collections.Generic;
using System.Linq;

public class BaseNamesHolder 
{
    protected List<string> ButtonsNames = new List<string>();
    public bool FindButton(string buttonName)
    {
        var tempButton = ButtonsNames.FirstOrDefault(b => b == buttonName);
        if (tempButton != null)
            return true;
        return false;
    }
}
