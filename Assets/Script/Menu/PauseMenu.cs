﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
	public static bool GameIsPaused = false;

	public GameObject pauseMenuUI;

    public GameObject GameManager;

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

    void Pause()
    {
    	pauseMenuUI.SetActive(true);
    	Time.timeScale = 0f;
    	GameIsPaused = true;
    }

    public void LoadMenu()
    {
    	SceneManager.LoadScene("StartGame");
    	Time.timeScale = BasicSpeed;
    }

    public void QuitGame()
    {
    	Debug.Log("Quitting Game..");
    	Application.Quit();
    }
}
