using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedMultiplier : MonoBehaviour
{
    public GameObject PauseMenu;
    public float playedTime;
    public float BasicSpeed = 0.8f;
    // Start is called before the first frame update
    void Start()
    {
        playedTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(!(Time.timeScale == 0)) 
        {
            playedTime += Time.deltaTime;
            Time.timeScale = BasicSpeed;
            if (playedTime > 0)
            {
                BasicSpeed += 0.00005f;
            }
            else if (playedTime > 5)
            {
                BasicSpeed += 0.00010f;
            }
            else if (playedTime > 150)
            {

            }
            else if (playedTime > 300)
            {
                BasicSpeed += 0.00050f;
            }
            else
            {
                BasicSpeed += 0.00100f;
            }
        }
    }
}
