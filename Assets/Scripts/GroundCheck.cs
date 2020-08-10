using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private string groundTag = "Ground"; 
    private bool isGround = false; 
    private bool isGroundEnter, isGroundStay, isGroundExit; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IsGround()
    {
        if(isGround || isGroundStay)
        {
            isGround = true;
        }
        
        if(isGroundExit)
        {
            isGround = false;
        }

        isGroundEnter = false;
        isGroundStay = false;
        isGroundExit = false;
        
        return isGround;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == groundTag)
        {
            isGroundEnter = true;
            // Debug.Log("enter");
        }
    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == groundTag)
        {
            isGroundStay = true;
            // Debug.Log("stay");
        }
    }
        
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == groundTag)
        {
            isGroundExit = true; 
            Debug.Log("exit");
        }

    }
}
