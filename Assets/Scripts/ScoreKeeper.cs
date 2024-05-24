using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreKeeper
{
    private static int score = 0;

    public static void Add(int amount)
    {
        score = score + amount;
        MonoBehaviour.print("Score = " + score);
    }

    public static void Reset()
    {
        score = 0;
    }

    public static int Get()
    {
        return score;
    }
}
