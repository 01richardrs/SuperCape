using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentManager : MonoBehaviour
{
    int CityStatus=0;
    public AudioSource[] Audio;

    public GameObject Environment1;
    public GameObject Ground1;
    public AudioSource EnvBGM1;

    public GameObject Environment2;
    public GameObject Ground2;
    public AudioSource EnvBGM2;

    // Start is called before the first frame update
    void Start()
    {
        Audio = GetComponents<AudioSource>();
        EnvBGM1 = Audio[1];
        EnvBGM2 = Audio[0];
        StartCoroutine(City());
    }

    private void Update()
    {
        if (Time.timeScale == 0f)
        {
            if (CityStatus == 0)
            {
                EnvBGM1.Pause();
            }
            else if (CityStatus == 1)
            {
                EnvBGM2.Pause();
            }    
        }
        else if (!(Time.timeScale == 0))
        {
            if (CityStatus == 0)
            {
                if (!EnvBGM1.isPlaying) 
                {
                    EnvBGM1.Play();
                }
            }
            else if (CityStatus == 1)
            {
                if (!EnvBGM2.isPlaying)
                {
                    EnvBGM2.Play();
                }
            }
        }
    }

    IEnumerator City()
    {
        CityStatus = 0;
        GameObject City = Instantiate(Environment1) as GameObject;
        GameObject City_Ground = Instantiate(Ground1) as GameObject;
        City.transform.position = new Vector2(0, 0);
        City_Ground.transform.position = new Vector2(7.2f, 2.2f);
        City_Ground.layer = 8;
        EnvBGM1.Play();
        yield return new WaitForSeconds(42);
        EnvBGM1.Stop();
        StartCoroutine(Beach());
        yield return new WaitForSeconds(3);
        Destroy(City);
        Destroy(City_Ground);
    }
    IEnumerator Beach()
    {
        CityStatus = 1;
        GameObject Beach = Instantiate(Environment2) as GameObject;
        GameObject Beach_Ground = Instantiate(Ground2) as GameObject;
        Beach.transform.position = new Vector2(0, 0);
        Beach_Ground.transform.position = new Vector2(7.2f, 2.8f);
        Beach_Ground.layer = 8;
        EnvBGM2.Play();
        yield return new WaitForSeconds(42);
        EnvBGM2.Stop();
        StartCoroutine(City());
        yield return new WaitForSeconds(3);
        Destroy(Beach);
        Destroy(Beach_Ground);
    }
}
