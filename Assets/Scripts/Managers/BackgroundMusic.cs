using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public static AudioSource backgroundMusic;

    private void Start()
    {
        backgroundMusic = gameObject.GetComponent<AudioSource>();
        if (GameStateManager.music)
        {
            backgroundMusic.Play();
        }
    }
}
