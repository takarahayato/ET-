using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed;
    public float gravity;
    public float jumpSpeed;
    public float jumpHeight;
    public float jumpLimitTime;//ジャンプ制限時間 New
    public GroundCheck ground;

    public GroundCheck head;//頭ぶつけた判定 New

    private Animator anim = null;
    private Rigidbody2D rb = null;
    private bool isGround = false;
    private bool isHead = false; //New
    private bool isJump = false;
    private float jumpPos = 0.0f;

    private float jumpTime = 0.0f;//New

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
        isHead = head.IsGround(); //New 

        float horizontalKey = Input.GetAxis("Horizontal"); 
        float verticalKey = Input.GetAxis("Vertical");
        float xSpeed = 0.0f;
        float ySpeed = -gravity;

        if(isGround)
        {
            if (verticalKey > 0)
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
            //New
            //上方向キーを押しているか
            bool pushUpKey = verticalKey > 0;
            //現在の高さが飛べる高さより下か
            bool canHeight = jumpPos + jumpHeight > transform.position.y;
            //ジャンプ時間が長くなりすぎてないか
            bool canTime = jumpLimitTime > jumpTime;


        if (pushUpKey && canHeight && canTime && !isHead)
                {
                    ySpeed = jumpSpeed;
                    jumpTime += Time.deltaTime;
                    // Debug.Log("働いてる？");
                }
        else
                {
                    isJump = false;
                    jumpTime = 0.0f; //New
                    // Debug.Log("働いてないよ");
                }


        
        if (verticalKey > 0 && jumpPos + jumpHeight > transform.position.y)
        {
            ySpeed = jumpSpeed;
            // Debug.Log("判定できてるよ!!!");
        }
        else
        {
            // Debug.Log("2");
            isJump = false;
            jumpTime = 0.0f; //New
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

        if(transform.position.y < -5){
            SceneManager.LoadScene("GameOver");
        }
    }
}

