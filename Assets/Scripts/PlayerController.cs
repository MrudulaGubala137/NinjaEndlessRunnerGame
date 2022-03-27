using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public int playerJumpForce;
    float inputX, inputY;
    public int playerSpeed;
    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer render;
    bool isGrounded=true;
    ScoreManager scoreManager;
    void Start()
    {
      rb=GetComponent<Rigidbody2D>();
        render=GetComponent<SpriteRenderer>();
        anim=GetComponent<Animator>();
        scoreManager=GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetTrigger("isIdle");
        if (Input.GetKeyUp(KeyCode.Space)&&isGrounded==true)
        {
            anim.SetTrigger("isJumping");
            rb.AddForce(Vector2.up * playerJumpForce);
            isGrounded=false;
        }
        if (Input.GetKeyUp(KeyCode.P)&&isGrounded == true)
        {
            anim.SetTrigger("isJumping");
            rb.AddForce(Vector2.up *2* playerJumpForce);
            isGrounded = false;
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            anim.SetTrigger("isAttacking");
        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
            anim.SetTrigger("isSliding");
        }
        if(inputX>0||inputX<0)
        {
            anim.SetTrigger("isRunning");
        }
        if(inputX>0)
        {
            render.flipX = false;
        }
        if(inputX<0)
        {
            render.flipX=true;
        }
    }
    private void FixedUpdate()
    {

        inputX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(inputX * playerSpeed * Time.deltaTime, rb.velocity.y);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
            if (gameObject.tag == "Player")
            {
                isGrounded = true;
            }
          }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag =="Dimond")
        {
            scoreManager.Score(10);
        }
    }
}
