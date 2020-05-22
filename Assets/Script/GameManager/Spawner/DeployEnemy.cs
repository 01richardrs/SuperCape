using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployEnemy : MonoBehaviour
{
    int CityInfo;
    float timecount;
    public float respawnTime = 15.0f;

    public GameObject Enemy01;
    public GameObject Enemy02;
    public GameObject Enemy03;
    public GameObject Enemy04;
    
    private Vector2 screenBounds;
    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z));
        StartCoroutine(SpawnEnemy());
    }

    private void Update()
    {
       CityInfo = this.GetComponent<EnvironmentManager>().CityStatus;
    }
    IEnumerator SpawnEnemy()
    {
        while (CityInfo == 0)
        {
            var RandNum = Random.Range(0,100);
            yield return new WaitForSeconds(respawnTime);
            if (RandNum>87)
            {
                GameObject Dragon = Instantiate(Enemy01) as GameObject;
                Dragon.transform.position = new Vector2(screenBounds.x * -2, Random.Range(-screenBounds.y, screenBounds.y));
            }
            else {
                GameObject Bird = Instantiate(Enemy04) as GameObject;
                Bird.transform.position = new Vector2(screenBounds.x * -2, Random.Range(-screenBounds.y, screenBounds.y));
            }
            
        }
        while (CityInfo == 1)
        {
            var RandNum = Random.Range(0, 100);
            yield return new WaitForSeconds(respawnTime);
            if (RandNum < 71)
            {
                GameObject Crab = Instantiate(Enemy02) as GameObject;
                Crab.transform.position = new Vector2(screenBounds.x * -2, Random.Range(-screenBounds.y, screenBounds.y));
            }
            else 
            {
                GameObject Squid = Instantiate(Enemy03) as GameObject;
                Squid.transform.position = new Vector2(screenBounds.x * -2, Random.Range(-screenBounds.y, screenBounds.y));
            }
            
        }
        StartCoroutine(SpawnEnemy());
    }

}
