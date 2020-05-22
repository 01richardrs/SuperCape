using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    int healthNum;
    public Image[] hearts;
    GameObject Player;

    void Update()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        healthNum = Player.GetComponent<PlayerMovement>().HEALTH;
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
   
}
