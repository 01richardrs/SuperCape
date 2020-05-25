using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallEnemy : MonoBehaviour
{
    public bool PlayerInvisible = false;
    public bool PlayerGiant = false;
    GameObject Player;
    public CircleCollider2D Ccoll2D;
    public float speed = 0.8f;
    public ParticleSystem explosion;

    private void Start()
    {
        Ccoll2D = GetComponent<CircleCollider2D>();
    }
    private void Update()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerInvisible = Player.GetComponent<PlayerMovement>().InvicibleStatus;
        PlayerGiant = Player.GetComponent<PlayerMovement>().GiantStatus;
        
        if (!(this.transform.position.y <=-3.15))
        {
            transform.Translate((-Vector3.up * speed) * Time.deltaTime);
        }else
        {
            transform.Translate((Vector3.left * speed) * Time.deltaTime);
        }
        if (PlayerInvisible)
        {
            Ccoll2D.enabled = false;
        }
        else {
            Ccoll2D.enabled = true;
        }
        if (PlayerGiant)
        {
            //dosomething
        }
        else
        {
            //dosomething
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground")
        {
            Destroy(this.gameObject);
            explosion.Play();
        }

        if (other.tag == "Deleter")
        {
            //this.GetComponent<Renderer>().enabled = false;
            StartCoroutine(BeforeDestroyed());
        }
    }

    //IEnumerator touchedGround()
    //{
    //    yield return new WaitForSeconds(2);
    //    Destroy(this.gameObject);
    //}

    IEnumerator BeforeDestroyed()
    {
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
    }
}
