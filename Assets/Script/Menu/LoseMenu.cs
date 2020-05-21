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

    private ScoreManager scoreManager;

    public GameObject GameManager;
    public GameObject PauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreNum = scoreManager.scoreCount;

        if (GameFinished)
        {
            PauseMenu.GetComponent<PauseMenu>().enabled = false;
            GameManager.GetComponent<SpeedMultiplier>().enabled = false;
            Time.timeScale = 0f;
            LoseMenuUI.SetActive(true);
            scoreText.text = "Score: " + Mathf.Round(scoreNum);
        }
    }


    public void GoToMenu()
    {
        SceneManager.LoadScene("StartGame");
        Time.timeScale = 1f;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void activateLoseGame()
    {
        GameFinished = true;
    }
}
