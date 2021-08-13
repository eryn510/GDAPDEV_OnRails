using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpreadEventArgs : EventArgs
{
    public Touch finger1 { get; private set; }
    public Touch finger2 { get; private set; }
    public float distanceDelta { get; private set; } = 0;
    public GameObject hitObject { get; private set; } = null;

    public SpreadEventArgs(Touch Finger1, Touch Finger2, float DistanceDelta, GameObject HitObject)
    {
        finger1 = Finger1;
        finger2 = Finger2;
        distanceDelta = DistanceDelta;
        hitObject = HitObject;
    }
}


