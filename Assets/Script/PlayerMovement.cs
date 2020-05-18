using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public BoxCollider2D coll2D;
    public Animator animator;
    public SpriteRenderer SpriteRender;

    private ScoreManager scoremanager;
    //private AudioSource audio;
    //public Text Score;

    //public float gravity = 1f;
    public bool GiantStatus=false;
    public bool InvicibleStatus=false;

    public float maxSpeed = 1f;
    public float SpeedMultiplier;
    public float Speed= 10f;
    public float JumpHeight=10f;
    // Start is called before the first frame update
    void Start()
    {
        SpriteRender = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        //audio = GetComponent<AudioSource>();
        coll2D = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        scoremanager = FindObjectOfType<ScoreManager>();
    }

    void FixedUpdate()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");
        float jump = Input.GetAxis("Jump");
        float rbVelocity = rb.velocity.magnitude;
        if (rbVelocity < maxSpeed)
        {
            rb.AddForce(new Vector2(horizontalAxis * Speed, 0));
        }

        if (horizontalAxis < 0 && this.transform.localScale.x == 1f)
        {
            transform.localScale = new Vector2(1f, 1f);
        }
        else if (horizontalAxis > 0 && this.transform.localScale.x == -1f)
        {
            transform.localScale = new Vector2(1f, 1f);
        }

        if (jump >= 0.01 && this.transform.position.y > -2.484081)// add + touch Ground
        {
            coll2D.size = new Vector2(1.6f, 1.2f);
            animator.SetBool("isJump", true);
            rb.AddForce(new Vector2(0, 1 * JumpHeight));
            rb.AddForce(transform.up * JumpHeight); 
        }
        else if (this.transform.position.y <= -.2484081) {
            coll2D.size = new Vector2(1.3f, 1.65f);
            animator.SetBool("isJump", false);
        }
        animator.SetFloat("Height", jump);
        if (verticalAxis <= 0.01) 
        {
            rb.AddForce(-transform.up * JumpHeight);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy"&&(!GiantStatus && !InvicibleStatus))
        {
            //audio.Play();
            //animator.SetBool("isDead", true);
            this.enabled = false;

            scoremanager.scoreIncrease = false;
       

            //StartCoroutine(Wait2GameOver());
        }
    }

    public void Giant()
    {
        //bonus point
        StartCoroutine(GoGiant());
    }

    IEnumerator GoGiant()
    {
        this.transform.localScale = new Vector3(3, 3, 1);
        coll2D.size = new Vector2(1.6f, 1.2f);
        GiantStatus = true;
        yield return new WaitForSeconds(5f);
        this.transform.localScale = new Vector3(1, 1, 1);
        coll2D.size = new Vector2(1.3f, 1.65f);
        GiantStatus = false;
    }

    public void Invisible()
    {
        //bonus point
        StartCoroutine(GoInvisible());
    }

    IEnumerator GoInvisible()
    {
        SpriteRender.color = new Color(1f, 1f, 1f, .5f);
        InvicibleStatus = true;
        yield return new WaitForSeconds(5f);
        SpriteRender.color = new Color(1f, 1f, 1f, 1f);
        InvicibleStatus = false;
        //no need change collider since /invi status is true
    }
    
}
