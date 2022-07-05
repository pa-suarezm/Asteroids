using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverUIManager : MonoBehaviour
{
    public GameObject menu;
    public GameObject veil;
    public GameObject title;
    public GameObject hiScore;
    public GameObject score;
    public GameObject btnRetry;
    public GameObject btnExit;

    public static GameOverUIManager instance;

    // Start is called before the first frame update
    void Start()
    {
        veil.SetActive(false);
        title.SetActive(false);
        hiScore.SetActive(false);
        score.SetActive(false);
        btnRetry.SetActive(false);
        btnExit.SetActive(false);

        instance = this;
    }

    public static void OnGameOver(bool newHiScore)
    {
        if (newHiScore)
        {
            instance.NewHighScore();
        }
        instance.menu.SetActive(false);
        instance.veil.SetActive(true);
        instance.title.SetActive(true);
        instance.score.SetActive(true);
        instance.btnRetry.SetActive(true);
        instance.btnExit.SetActive(true);
    }

    private void NewHighScore()
    {
        instance.hiScore.SetActive(true);
        StartCoroutine(ToggleHiScoreMsg());
    }

    IEnumerator ToggleHiScoreMsg()
    {
        while (!GameStateManager.playingGame)
        {
            yield return new WaitForSeconds(0.5f);
            instance.hiScore.SetActive(!instance.hiScore.activeInHierarchy);
        }
    }

    public void OnClickRetry()
    {
        GameStateManager.instance.Play();
    }

    public void OnClickExit()
    {
        GameStateManager.instance.QuitToMenu();
    }
}
