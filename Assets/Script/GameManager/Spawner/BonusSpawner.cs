using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSpawner : MonoBehaviour
{
    float BonusTime;
    public GameObject Giant_Bonus;
    public GameObject Invisible_Bonus;
    public GameObject Health_Bonus;
    void Update()
    {
        if (!(Time.timeScale == 0))
        {
            BonusTime += Time.deltaTime;
            if (BonusTime > 75)
            {
                var randY = Random.Range(-2.4f, 3.50f);
                var randnum = Random.Range(0, 100);
                Debug.Log("BONUS RAND" + randnum);
                if (randnum < 40)
                {
                    GameObject Bonus0 = Instantiate(Giant_Bonus, new Vector2(10.2f, randY), Quaternion.identity) as GameObject;
                } 
                else if (randnum > 60)
                {
                    GameObject Bonus1 = Instantiate(Invisible_Bonus, new Vector2(10.2f, randY), Quaternion.identity) as GameObject;
                }
                else 
                {
                    GameObject Bonus2 = Instantiate(Health_Bonus, new Vector2(10.2f, -randY), Quaternion.identity) as GameObject;
                }
        
                BonusTime = 0;
            }
            
        }
    }
}
