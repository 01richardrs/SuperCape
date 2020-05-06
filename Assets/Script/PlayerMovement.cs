using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Collider2D coll2D;
    public Animator animator;
    //private AudioSource audio;
    //public Text Score;

    //public float gravity = 1f;
    public float maxSpeed = 1f;
    public float SpeedMultiplier;
    public float Speed= 10f;
    public float JumpHeight=10f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //audio = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
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
            transform.localScale = new Vector2(-1f, 1f);
        }
        else if (horizontalAxis > 0 && this.transform.localScale.x == -1f)
        {
            transform.localScale = new Vector2(1f, 1f);
        }

        if (jump >= 0.01)// add + touch Ground
        {
            animator.SetBool("isJump", true);
            rb.AddForce(new Vector2(0, 1 * JumpHeight));
            rb.AddForce(transform.up * JumpHeight); 
        }
        else {
            animator.SetBool("isJump", false);
        }
        animator.SetFloat("Height", jump);
        if (verticalAxis <= 0.01) 
        {
            rb.AddForce(-transform.up * JumpHeight);
        }
    }

}
