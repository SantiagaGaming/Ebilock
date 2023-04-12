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
    }
    public bool ChekLacationNames(string locationName)
    {
       return _locationNames.Any(item => item == locationName);
    }
}
