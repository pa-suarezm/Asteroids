using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleAsteroid : MonoBehaviour
{
    private Rigidbody2D rgb;
    public bool left = true;
    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
        float degrees = -30;
        if (left)
        {
            degrees *= -1;
        }
        rgb.angularVelocity = degrees;
    }
}
