using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
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

    public void OnClick()
    {
        audioSource.Play();
    }

    public void OnClickPlay()
    {
        OnClick();
        GameStateManager.instance.Play();
    }

    public void OnClickCredits()
    {
        OnClick();
        GameStateManager.instance.RollCredits();
    }

    public void OnClickExit()
    {
        OnClick();
        GameStateManager.instance.Exit();
    }

    public void OnClickWebSite()
    {
        OnClick();
        Application.OpenURL("https://pa-suarezm.github.io");
    }
}
