using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LocationNamesHandler
{
    private List<string> _locationNames = new List<string>();

    public LocationNamesHandler()
    {

        _locationNames.Add("hall");
        _locationNames.Add("r_dsp");
        _locationNames.Add("r_shn");
        _locationNames.Add("relay1");
        _locationNames.Add("relay2");
        _locationNames.Add("field");
        _locationNames.Add("feed");
        _locationNames.Add("str1");
        _locationNames.Add("str3");
        _locationNames.Add("sezd1-3");
        _locationNames.Add("str11");
        _locationNames.Add("sv_N");
        _locationNames.Add("sv_m3");
        _locationNames.Add("sv_ch1");
    }
    
    public bool ChekLacationNames(string locationName)
    {
        var temp = _locationNames.FirstOrDefault(item => item == locationName);
        if (temp != null)

            return true;

        return false;
    }
}
