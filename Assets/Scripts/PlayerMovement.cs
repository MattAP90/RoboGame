using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 startPos;
    private Rigidbody2D rig;

    private float speed;

    private bool facingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        speed = .05f;
        startPos = new Vector2(GetComponent<Transform>().position.x, GetComponent<Transform>().position.y);
    }

    // Update is called once per frame
    void Update()
    { 

    }

    //called a fixed amount of times, use for physics
    void FixedUpdate()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");

        rig.velocity = new Vector2(moveInput * speed, rig.velocity.y);

        //checks to see if player is facing the right way based on move direction
        if(facingRight == false && moveInput > 0)
        {
            Flip();
        }else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }

        if ((Input.GetKey("a") || Input.GetKey("d")) && speed <= .95f)
        {
            speed = speed + .05f;
        }
        else if (!(Input.GetKey("a") || Input.GetKey("d")))
        {
            speed = 0.0f;
        }
    }


    //flips the sprite to face the way the character is moving
    void Flip()
    {

        facingRight = !facingRight;

        transform.Rotate(0f, 180f, 0f);

    }

    public bool getFacingRight()
    {
        return facingRight;
    }

    public Vector2 getStartPos()
    {
        return startPos;
    }

}
