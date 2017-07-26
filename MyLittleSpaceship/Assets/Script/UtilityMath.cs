using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilityMath : MonoBehaviour {
    public static float GetDistance(int x1, int y1, int z1, int x2, int y2, int z2)
    {
        return Mathf.Sqrt(Mathf.Pow(x1-x2, 2) + Mathf.Pow(y1 - y2, 2) + Mathf.Pow(z1 - z2, 2));
    }
}
