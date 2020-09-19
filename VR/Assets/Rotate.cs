using System.Collections;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [Header("Rotate Angle"), Range(0, 150)]
    public float angle = 90;
    [Header("Rotate Speed"), Range(0, 100)]
    public float speed = 1.5f;

    /// <summary>
    /// Start Rotating
    /// </summary>
    public void RotateStart()
    {

    }
}
