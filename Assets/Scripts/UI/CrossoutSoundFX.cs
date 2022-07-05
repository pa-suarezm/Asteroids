using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossoutSoundFX : MonoBehaviour
{
    public GameObject crossout;

    // Update is called once per frame
    void Update()
    {
        crossout.SetActive(!GameStateManager.soundFX);
    }
}
