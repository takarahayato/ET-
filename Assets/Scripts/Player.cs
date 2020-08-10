using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float gravity;
    public float jumpSpeed;
    public float jumpHeight;
    public GroundCheck ground;

    private Animator anim = null;
    private Rigidbody2D rb = null;
    private bool isGround = false;
    private bool isJump = false;
    private float jumpPos = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isGround = ground.IsGround();

        float horizontalKey = Input.GetAxis("Horizontal"); 
        float vertikalKey = Input.GetAxis("Vertical");
        float xSpeed = 0.0f;
        float ySpeed = -gravity;

        if(isGround)
        {
            if (vertikalKey > 0)
            {
                ySpeed = jumpSpeed;
                jumpPos = transform.position.y;
                isJump = true;
            }
            else
            {
                isJump = false;
            }
        }
        else if(isJump)
        {
            if (vertikalKey > 0 && jumpPos + jumpHeight > transform.position.y)
            {
                ySpeed = jumpSpeed;
                Debug.Log("判定できてるよ!!!");
            }
            else
            {
                Debug.Log("2");
                isJump = false;
            }
        }

        if (horizontalKey > 0) 
        {
            transform.localScale = new Vector3(5, 5, 5);
            anim.SetBool("player_run", true);
            xSpeed = speed;
        }
        else if (horizontalKey < 0) 
        {
            transform.localScale = new Vector3(-5, 5, 5);
            anim.SetBool("player_run", true);
            xSpeed = -speed;
        }
        else
        {
            anim.SetBool("player_run", false);
            xSpeed = 0.0f;
        }
        rb.velocity = new Vector2(xSpeed, ySpeed);
    }
}
