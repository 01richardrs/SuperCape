using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
	public static bool GameIsPaused = false;

	public GameObject pauseMenuUI;

    public GameObject GameManager;

    public GameObject LoseManager;

    float BasicSpeed;

    void Update()
    {
        BasicSpeed = GameManager.GetComponent<SpeedMultiplier>().BasicSpeed;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
        	if(GameIsPaused)
        	{
        		Resume();
        	}
        	else
        	{
        		Pause();
        	}
        }
    }

    public void Resume()
    {
    	pauseMenuUI.SetActive(false);
    	Time.timeScale = BasicSpeed; //change this according to current speed of the game
    	GameIsPaused = false;
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        pauseMenuUI.SetActive(true);
    	GameIsPaused = true;
    }

    public void LoadMenu()
    {
    	SceneManager.LoadScene("StartGame");
    	Time.timeScale = BasicSpeed;
    }

    public void loadlevel()
    {
        string scene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
        Time.timeScale = 1f;
        LoseManager.GetComponent<LoseMenu>().RestartGame();
    }

    public void QuitGame()
    {
    	Debug.Log("Quitting Game..");
    	Application.Quit();
    }
}
