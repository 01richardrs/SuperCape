using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacle : MonoBehaviour
{
    public float respawnTime = 3.8f;

    public GameObject Pattern0;
    public GameObject Pattern1;
    public GameObject Pattern2;
    public GameObject Pattern3;
    public GameObject Pattern4;
    public GameObject Pattern5;
    public GameObject Pattern6;

    private Vector2 screenBounds;
    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z));
        StartCoroutine(SpawnEnemy());
    }
    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            var RandNum = Random.Range(0, 100);
            yield return new WaitForSeconds(respawnTime);
            if (RandNum > 50)
            {
                ChooseObstacle(1);
            }
            else if (RandNum < 35)
            {
                ChooseObstacle(2);
            }
            else 
            {
                ChooseObstacle(3);
            }
        }
    }
    void ChooseObstacle(int num)
    {
        Debug.Log("CALLED0");
        if (num == 1)
        {
            var RandNum = Random.Range(0, 100);
            if (RandNum < 40)
            {
                GameObject Patt3 = Instantiate(Pattern3, new Vector2(screenBounds.x * -2, -0.15f), Quaternion.identity) as GameObject;
            }
            else if (RandNum > 60)
            {
                GameObject Patt5 = Instantiate(Pattern5, new Vector2(screenBounds.x * -2, -0.236f), Quaternion.identity) as GameObject;
            }
            else
            {
                GameObject Patt6 = Instantiate(Pattern6, new Vector2(screenBounds.x * -2, -0.018f), Quaternion.identity) as GameObject;
            }
        }
        else if (num == 2)
        {
            GameObject Patt4 = Instantiate(Pattern4, new Vector2(screenBounds.x * -2, -0.236f), Quaternion.identity) as GameObject;
        }
        else 
        {
            var RandNum = Random.Range(0, 100);
            if (RandNum < 40)
            {
                GameObject Patt0 = Instantiate(Pattern0, new Vector2(screenBounds.x * -2, -0.20f), Quaternion.identity) as GameObject;
            }
            else if (RandNum > 60)
            {
                GameObject Patt1 = Instantiate(Pattern1, new Vector2(screenBounds.x * -2, 1.50f), Quaternion.identity) as GameObject;
            }
            else
            {
                GameObject Patt2 = Instantiate(Pattern2, new Vector2(screenBounds.x * -2, -0.105f), Quaternion.identity) as GameObject;
            }
        }
    }
}
