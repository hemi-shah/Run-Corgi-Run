using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beer : TimedObject
{
    public void Start()
    {
        SecondsOnScreen = GameParameters.BeerSecondsOnScreen;
        base.Start();
    }
}
