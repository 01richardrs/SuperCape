using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy03 : MonoBehaviour
{
    public float speed = 0.1f;
    int direction = 1;
    float top = 4.25f;
    float bottom = -2.50f;
    //public AudioSource audio;

    void Start()
    {
        //audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y >= top)
            direction = -1;

        if (transform.position.y <= bottom)
            direction = 1;

        transform.Translate(0, speed * direction * Time.deltaTime, 0);
        transform.Translate((Vector3.left *speed)* Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Deleter")
        {
            //this.GetComponent<Renderer>().enabled = false;
            StartCoroutine(BeforeDestroyed());
        }
    }

    IEnumerator BeforeDestroyed()
    {
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
    }
}
