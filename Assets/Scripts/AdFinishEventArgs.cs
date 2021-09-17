using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AdFinishEventArgs : EventArgs
{
    public string placementID
    {
        get; private set;
    }

    public UnityEngine.Advertisements.ShowResult AdResult
    {
        get; private set;
    }

    public AdFinishEventArgs(string id, UnityEngine.Advertisements.ShowResult result)
    {
        placementID = id;
        AdResult = result;
    }
}
