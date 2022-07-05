using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private AudioSource audioSource;

    public AudioClip pausePlay;
    public AudioClip btnClick;

    public GameObject veil;
    public GameObject btnPlay;
    public GameObject btnPause;
    public GameObject btnMusic;
    public GameObject btnSoundFX;
    public GameObject btnExit;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        veil.SetActive(false);
        btnPlay.SetActive(false);
        btnMusic.SetActive(false);
        btnSoundFX.SetActive(false);
        btnExit.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!GameStateManager.paused)
            {
                Debug.Log("Back button -> OnClickPause()");
                OnClickPause();
            }
            else
            {
                Debug.Log("Back button -> OnClickExit()");
                OnClickExit();
            }
        }
    }

    public void OnClickPause()
    {
        if (GameStateManager.soundFX)
        {
            audioSource.PlayOneShot(pausePlay);
        }
        GameStateManager.instance.TogglePause();

        veil.SetActive(GameStateManager.paused);
        btnPlay.SetActive(GameStateManager.paused);
        btnExit.SetActive(GameStateManager.paused);
        btnPause.SetActive(!GameStateManager.paused);
        btnMusic.SetActive(GameStateManager.paused);
        btnSoundFX.SetActive(GameStateManager.paused);
    }

    public void OnClickMusic()
    {
        audioSource.PlayOneShot(btnClick);
        GameStateManager.music = !GameStateManager.music;
        if (GameStateManager.music)
        {
            BackgroundMusic.backgroundMusic.Play();
        }
        else
        {
            BackgroundMusic.backgroundMusic.Stop();
        }
    }

    public void OnClickSoundFX()
    {
        audioSource.PlayOneShot(btnClick);
        GameStateManager.soundFX = !GameStateManager.soundFX;
    }

    public void OnClickExit()
    {
        GameStateManager.instance.QuitToMenu();
    }
}
