using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    public GameObject health_1;
    public GameObject health_2;
    public GameObject health_3;

    private static HealthUI instance;

    private void Start()
    {
        instance = this;
    }

    public static void OnHealthLoss(int newHp)
    {
        if (newHp == 2)
        {
            instance.health_3.SetActive(false);
        }
        else if (newHp == 1)
        {
            instance.health_2.SetActive(false);
        }
        else
        {
            instance.health_1.SetActive(false);
        }
    }
}
