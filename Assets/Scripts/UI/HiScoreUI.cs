using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HiScoreUI : MonoBehaviour
{
    private TextMeshProUGUI text;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        text.text = "Hi: " + GameStateManager.hiScore.ToString() + " pts";
    }

    void Update()
    {
        if (GameStateManager.hiScore == GameStateManager.points)
        {
            text.text = "Hi: " + GameStateManager.hiScore.ToString() + " pts";
        }
    }
}
