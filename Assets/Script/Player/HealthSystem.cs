using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public int healthNum;

    public Image[] hearts;
    public Sprite redHeart;

    GameObject player;
    GameObject loseCanvas;
    private ScoreManager scoremanager;

    public float scoreFromManager;

    // Start is called before the first frame update
    void Start()
    {
        scoremanager = FindObjectOfType<ScoreManager>();
        player = GameObject.Find("Player(Clone)");
        loseCanvas = GameObject.Find("LoseCanvas");

    }

    // Update is called once per frame
    void Update()
    {
        if (healthNum < 1)
        {
            //this.enabled = false;
            scoremanager.scoreIncrease = false;
            loseCanvas.GetComponent<LoseMenu>().activateLoseGame();

        }

        // buat display jumlah health, tergantung ama health num
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < healthNum)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }    

    }

    public void HealthLoss()
    {
        healthNum--;
    }
}
