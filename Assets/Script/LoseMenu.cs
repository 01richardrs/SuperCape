using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoseMenu : MonoBehaviour
{
    public bool GameFinished = false;

    public GameObject LoseMenuUI;

    public Text scoreText;

    public float scoreNum;

    // Start is called before the first frame update
    void Start()
    {
        // score masih kagak bener
        scoreNum = PlayerPrefs.GetFloat("ScoreNum");
    }

    // Update is called once per frame
    void Update()
    {
        if (GameFinished)
        {
            Time.timeScale = 0f;
            LoseMenuUI.SetActive(true);
            scoreText.text = "High Score: " + Mathf.Round(scoreNum);
        }
    }


    public void GoToMenu()
    {
        SceneManager.LoadScene("StartGame");
        Time.timeScale = 1f;
    }

    public void ExitGame()
    {
        Debug.Log("Habis kalah keluar");
        Application.Quit();
    }

    public void activateLoseGame()
    {
        GameFinished = true;
    }
}
