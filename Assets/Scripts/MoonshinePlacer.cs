using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonshinePlacer : RandomObjectPlacer
{
    public void Start()
    {
        minimumSecondsUntilCreation = GameParameters.MoonshineMaximumSecondsUntilCreation;
        maximumSecondsUntilCreation = GameParameters.MoonshineMaximumSecondsUntilCreation;
    }

    protected override void Place()
    {
        // pick random place on screen
        // create a bone at spot on screen
        Instantiate(ItemPrefab, SpriteTools.RandomTopOfScreenLocationWorldSpace(), Quaternion.identity);
    }
}
