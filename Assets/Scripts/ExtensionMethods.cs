using System.Collections.Generic;
using UnityEngine;

public static class ExtensionMethods
{
    public static T GetRandomItem<T>(this List<T> list)
    {
        return list[UnityEngine.Random.Range(0, list.Count)];
    }

    public static void Randomize<T>(this List<T> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int chosenIndex = UnityEngine.Random.Range(i, list.Count);
            var temp = list[i];
            list[i] = list[chosenIndex];
            list[chosenIndex] = temp;
        }
    }

    public static bool CoinFlip(float cutoff = 0.5f)
    {
        return UnityEngine.Random.Range(0.0f, 1.0f) < cutoff;
    }
}
