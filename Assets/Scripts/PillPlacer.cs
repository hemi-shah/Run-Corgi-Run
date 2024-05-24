using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillPlacer : RandomObjectPlacer
{
    public void Start()
    {
        minimumSecondsUntilCreation = GameParameters.PillMaximumSecondsUntilCreation;
        maximumSecondsUntilCreation = GameParameters.PillMaximumSecondsUntilCreation;
    }
}
