using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poop : TimedObject
{
    public void Start()
    {
        SecondsOnScreen = GameParameters.PoopSecondsOnScreen;
        base.Start();
    }
}
