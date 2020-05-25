using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy01 : MonoBehaviour
{
    public float speed = 0.1f;
    int direction = 1;
    float top;
    float bottom;
    //public AudioSource audio;

    void Start()
    {
        top = this.transform.position.y + 0.50f;
        bottom = this.transform.position.y - 1.00f;
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
