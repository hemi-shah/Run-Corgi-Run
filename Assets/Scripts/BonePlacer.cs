using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonePlacer : RandomObjectPlacer
{
    public void Start()
    {
        minimumSecondsUntilCreation = GameParameters.BoneMaximumSecondsUntilCreation;
        maximumSecondsUntilCreation = GameParameters.BoneMaximumSecondsUntilCreation;
    }
}
