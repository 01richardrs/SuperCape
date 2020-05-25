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
    GameObject loseCanvas;
    public AudioSource Audio;
    public AudioClip Hit_SFX;
    public AudioClip Bonus_SFX;
    public AudioClip Coins_SFX;

    //public Text Score;

    //public float gravity = 1f;
    public bool GiantStatus = false;
    public bool InvicibleStatus = false;
    public bool jumpStatus = false;

    public float maxSpeed = 1f;
    public float SpeedMultiplier;
    public float Speed = 10f;
    public float JumpHeight = 10f;


    public int HEALTH = 3;
    void Start()
    {
        SpriteRender = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        coll2D = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        scoremanager = FindObjectOfType<ScoreManager>();

        loseCanvas = GameObject.Find("LoseCanvas");

        Audio = GetComponent<AudioSource>();
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

        if (jump >= 0.01)// add + touch Ground
        {
            jumpStatus = true;
            coll2D.size = new Vector2(1.6f, 1.2f);
            animator.SetBool("isJump", true);
            rb.AddForce(new Vector2(0, 3 * JumpHeight));
            rb.AddForce(transform.up * JumpHeight);
        }
        else if (this.transform.position.y <= -.2484081)
        {
            coll2D.size = new Vector2(1.3f, 1.65f);
            animator.SetBool("isJump", false);
            jumpStatus = false;
        }
        animator.SetFloat("Height", jump);
        if (verticalAxis <= 0.01)
        {
            rb.AddForce(-transform.up * JumpHeight);
        }
    }

    private void Update()
    {
        if (HEALTH < 1)
        {
            StartCoroutine(Dead());
            //audio.Play();
            //animator.SetBool("isDead", true);

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy" && (!GiantStatus && !InvicibleStatus))
        {
            HEALTH--;
            Audio.PlayOneShot(Hit_SFX);
            if (HEALTH > 0)
            {
                Invisible(1.5f);
            }

        }
        else if (other.tag == "Enemy" && (GiantStatus))
        {
            Destroy(other.gameObject);
        }
    }

    public void HealthBonus()
    {
        //supposed to be this easy, but there is a problem sometimes the health cant increment 
        //and the health++ are counted as its Playerprefs even though there isnt.
        if (HEALTH < 3)
        {
            HEALTH++;
        }

    }

    public void Giant()
    {
        scoremanager.scoreCount += 20;
        Audio.PlayOneShot(Bonus_SFX);
        StartCoroutine(GoGiant());
    }

    IEnumerator GoGiant()
    {
        this.transform.localScale = new Vector3(3, 3, 1);
        coll2D.size = new Vector2(1.6f, 1.2f);
        GiantStatus = true;
        yield return new WaitForSeconds(8f);
        this.transform.localScale = new Vector3(1, 1, 1);
        coll2D.size = new Vector2(1.3f, 1.65f);
        GiantStatus = false;
    }

    public void Invisible(float time)
    {
        Audio.PlayOneShot(Bonus_SFX);
        scoremanager.scoreCount += 15;
        StartCoroutine(GoInvisible(time));
    }

    IEnumerator GoInvisible(float time)
    {
        SpriteRender.color = new Color(1f, 1f, 1f, .5f);
        InvicibleStatus = true;
        yield return new WaitForSeconds(time);
        SpriteRender.color = new Color(1f, 1f, 1f, 1f);
        InvicibleStatus = false;
        //no need change collider since /invi status is true
    }

    IEnumerator Dead()
    {
        animator.SetBool("isDead", true);
        coll2D.size = new Vector2(1.6f, 1.2f);
        this.enabled = false;
        rb.AddForce(-transform.up * 75);
        scoremanager.scoreIncrease = false;
        yield return new WaitForSeconds(2);
        loseCanvas.GetComponent<LoseMenu>().activateLoseGame();
    }

    //Audio.PlayOneShot(Coins_SFX); for coins

}
