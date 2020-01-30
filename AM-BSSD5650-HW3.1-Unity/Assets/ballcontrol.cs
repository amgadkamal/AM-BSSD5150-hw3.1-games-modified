using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballcontrol : MonoBehaviour
{

    private float maxSpeed = 10f;
    private float jump = 5f;
    private bool grounded = false;
    private bool sticky = false;
    private bool spacePressed;
    private float move;
    private Rigidbody2D rb;
    
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
  
    }

    // Update is called once per frame
    void Update()
    {
         move = Input.GetAxis("Horizontal");
        spacePressed = Input.GetKeyDown("space");
        rb.mass = 15;
        
    }


    private void FixedUpdate()
    {   rb.velocity = new Vector2(move * maxSpeed, rb.velocity.y);
        

        if (spacePressed && grounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + jump);
           
        }
         
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        Debug.Log(collision.gameObject.tag);
        if(collision.gameObject.tag == "floor")
        {
            grounded = true;
        }
        if (collision.gameObject.tag == "sticky")
        {
            maxSpeed = 0;
            rb.AddForce(new Vector2(rb.velocity.x, rb.velocity.y), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "floor")
        {
        grounded = false;
        }
        
    }

}

