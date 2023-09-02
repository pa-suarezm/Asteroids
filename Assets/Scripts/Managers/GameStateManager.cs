using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    [HideInInspector] public static GameStateManager instance;

    public int targetFramerate = 60;
    [HideInInspector] public static bool playingGame = false;
    [HideInInspector] public static bool paused = false;
    [HideInInspector] public static bool music = true;
    [HideInInspector] public static bool soundFX = true;

    [HideInInspector] public static int points;
    [HideInInspector] public static int hiScore = 0;

    private void Awake()
    {
        //Singleton
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); //Permite que este objeto exista entre escenas
        }
        else if (instance != this)
        {
            Destroy(gameObject); //Ya existe una instancia del GameStateManager
        }
    }

    private void Start()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = targetFramerate;
        try
        {
            hiScore = PlayerPrefs.GetInt("HiScore");
        }
        catch (System.Exception e)
        {
            Debug.LogError(e.Message);
        }
    }

    private void Update()
    {
        if (playingGame && !paused)
        {
            points++;
            if (points > hiScore)
            {
                hiScore = points;
            }
        }
    }

    public void AddPoints(int pointsToAdd)
    {
        if (playingGame && !paused)
        {
            points += pointsToAdd;
            if (points > hiScore)
            {
                hiScore = points;
            }
        }
    }


    public void Play()
    {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
        playingGame = true;
        paused = false;
        points = 0;
    }

    public void TogglePause()
    {
        paused = !paused;
        if (paused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        playingGame = false;
    }

    public void RollCredits()
    {
        SceneManager.LoadScene("Credits", LoadSceneMode.Single);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void GameOver()
    {
        playingGame = false;

        Debug.Log("hiScore: " + hiScore.ToString());
        Debug.Log("points: " + points.ToString());

        if (points >= hiScore)
        {
            hiScore = points;
            PlayerPrefs.SetInt("HiScore", hiScore);
            GameOverUIManager.OnGameOver(true);
        }
        else
        {
            GameOverUIManager.OnGameOver(false);
        }
    }
}
