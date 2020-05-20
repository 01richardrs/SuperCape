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

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (hearts.Length < 1)
        {
            //Debug.Log("lebu");
            //this.enabled = false;
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
