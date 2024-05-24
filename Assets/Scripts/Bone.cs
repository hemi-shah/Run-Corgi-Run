using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bone : TimedObject
{
    public void Start()
    {
        SecondsOnScreen = GameParameters.BoneSecondsOnScreen;
        base.Start();
    }
}
