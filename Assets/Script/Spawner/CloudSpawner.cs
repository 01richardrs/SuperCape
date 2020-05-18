using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    public GameObject CloudPrefab0;
    public GameObject CloudPrefab1;
    public GameObject CloudPrefab2;
    public GameObject CloudPrefab3;
    public float respawnTime = 8f;
    private Vector2 screenBounds;
    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z));
        StartCoroutine(CloudSpawn());
        //StartCoroutine(CloudSpawn());
    }


    private void Randomizer()
    {
        var randnum = Random.Range(0, 100);

        if (randnum > 80)
        {
            GameObject ab = Instantiate(CloudPrefab1) as GameObject;
            ab.transform.position = new Vector2(screenBounds.x * -2, Random.Range(1.7f, 4.6f));
        }
        else if (randnum > 60)
        {
            GameObject abcd = Instantiate(CloudPrefab3) as GameObject;
            abcd.transform.position = new Vector2(screenBounds.x * -2, Random.Range(1.7f, 4.6f));
        }
        else if (randnum > 40)
        {
            GameObject a = Instantiate(CloudPrefab0) as GameObject;
            a.transform.position = new Vector2(screenBounds.x * -2, Random.Range(1.7f, 4.6f));
        }else
        {
            GameObject abc = Instantiate(CloudPrefab2) as GameObject;
            abc.transform.position = new Vector2(screenBounds.x * -2, Random.Range(1.7f, 4.6f));
        }

    }

    IEnumerator CloudSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            Randomizer();

            yield return new WaitForSeconds(0.5f);

            yield return new WaitForSeconds(respawnTime);
            Randomizer();
        }
        
    }
}
