using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rig;

    public float speed = .75f;

    private bool facingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() { }

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

}
