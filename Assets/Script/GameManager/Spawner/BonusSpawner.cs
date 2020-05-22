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
                var randnum = Random.Range(0, 2);
                Debug.Log("Bonus Is Coming");
                switch (randnum)
                {
                    
                    case 0:
                        GameObject Bonus0 = Instantiate(Giant_Bonus, new Vector2(10.2f, randY), Quaternion.identity) as GameObject;
                        break;
                    case 1:
                        GameObject Bonus1 = Instantiate(Invisible_Bonus, new Vector2(10.2f, randY), Quaternion.identity) as GameObject;
                        break;
                    case 2:
                        GameObject Bonus2 = Instantiate(Health_Bonus, new Vector2(10.2f, -randY), Quaternion.identity) as GameObject;
                        break;
                }
                BonusTime = 0;
            }
            
        }
    }
}
