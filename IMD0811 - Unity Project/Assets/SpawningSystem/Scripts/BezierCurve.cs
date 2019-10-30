using System;
using UnityEngine;

public class BezierCurve : MonoBehaviour
{
    public Vector3[] points;

    private void Reset()
    {
        points = new Vector3[]
        {
            new Vector3(1, 0, 0),
            new Vector3(2, 0, 0),
            new Vector3(3, 0, 0),
        };
    }
}