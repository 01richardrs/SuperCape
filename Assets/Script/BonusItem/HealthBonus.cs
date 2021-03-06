﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBonus : MonoBehaviour
{
    public float speed = 0.1f;
    GameObject Player;
    void Update()
    {
        transform.Translate((Vector3.left * speed) * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Deleter")
        {
            //this.GetComponent<Renderer>().enabled = false;
            StartCoroutine(BeforeDestroyed());
        }
        if (other.tag == "Player")
        {
            Player = GameObject.FindGameObjectWithTag("Player");
            Player.GetComponent<PlayerMovement>().HealthBonus();
            Destroy(this.gameObject);
        }
    }

    IEnumerator BeforeDestroyed()
    {
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
    }
}
