﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text hiScoreText;

    public float scoreCount;
    public float hiScoreCount;

    public float pointsPerSecond;

    public bool scoreIncrease;

    //GameObject LoseCanvas;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("highscore"))
        {
            hiScoreCount = PlayerPrefs.GetFloat("highscore");
        }

        //LoseCanvas = GameObject.Find("LoseCanvas");

    }




    // Update is called once per frame
    void Update()
    {
        if( scoreIncrease)
        {
            scoreCount += pointsPerSecond * Time.deltaTime;
        }


        if (scoreCount > hiScoreCount)
        {
            hiScoreCount = scoreCount;
            PlayerPrefs.SetFloat("highscore", hiScoreCount);
        }

        scoreText.text = "Score: " + Mathf.Round (scoreCount);
        hiScoreText.text = "High Score: " + Mathf.Round(hiScoreCount);

        // score masih kagak bener
        //if (LoseCanvas.GetComponent<LoseMenu>().GameFinished == true)
        //{
        PlayerPrefs.SetFloat("ScoreNum", scoreCount);
        //}
    }
}