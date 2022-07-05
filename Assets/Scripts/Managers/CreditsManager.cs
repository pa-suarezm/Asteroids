using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsManager : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            OnClickExit();
        }
    }

    public void OnClickExit()
    {
        audioSource.Play();
        GameStateManager.instance.QuitToMenu();
    }
}
