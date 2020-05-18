using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectEnemy : MonoBehaviour
{
    public bool PlayerInvisible = false;
    public bool PlayerGiant = false;
    public GameObject Player;
    public BoxCollider2D Bcoll2D;
    public CircleCollider2D Ccoll2D;

    private void Start()
    {
        Bcoll2D = GetComponent<BoxCollider2D>();
        Ccoll2D = GetComponent<CircleCollider2D>();
    }
    private void Update()
    {
        PlayerInvisible = Player.GetComponent<PlayerMovement>().InvicibleStatus;
        PlayerGiant = Player.GetComponent<PlayerMovement>().GiantStatus;

        if (PlayerInvisible)
        {
            Bcoll2D.enabled = false;
            Ccoll2D.enabled = false;
        }
        else {
            Bcoll2D.enabled = true;
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
