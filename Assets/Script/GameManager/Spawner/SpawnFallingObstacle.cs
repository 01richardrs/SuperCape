using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFallingObstacle : MonoBehaviour
{
    int CityInfo;
    public float respawnTime = 15f;

    public GameObject Obstacle1;
    public GameObject Obstacle2;
    
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
            yield return new WaitForSeconds(respawnTime);
            GameObject Meteorite = Instantiate(Obstacle1) as GameObject;
            Meteorite.transform.position = new Vector2(Random.Range(-3.25f, 4.55f), 5);
        }
        while (CityInfo == 1)
        {
            yield return new WaitForSeconds(respawnTime);
            GameObject Coconut = Instantiate(Obstacle2) as GameObject;
            Coconut.transform.position = new Vector2(Random.Range(-3.25f, 4.55f), -3.17f); 
        }
        StartCoroutine(SpawnEnemy());
    }

}
