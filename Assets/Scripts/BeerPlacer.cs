using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeerPlacer : RandomObjectPlacer
{
    public void Start()
    {
        minimumSecondsUntilCreation = GameParameters.BeerMaximumSecondsUntilCreation;
        maximumSecondsUntilCreation = GameParameters.BeerMaximumSecondsUntilCreation;
    }
}
