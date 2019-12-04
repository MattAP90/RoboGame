using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportBall : MonoBehaviour
{

    public float speed;
    private bool teleOut;
    private bool cooldown;
    private bool facingRight;
    private bool up;
    private Rigidbody2D rb;    
    public GameObject roboPrefab;
    private Transform roboPos;
    private PlayerMovement plMove;
    private Transform pos;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pos = GetComponent<Transform>();
        teleOut = false;
        cooldown = false;
        plMove = roboPrefab.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {

        
        if (Input.GetButtonDown("Fire1") && cooldown)
        {
            //when teleported to, reset varibles
            cooldown = false;
            teleOut = false;
        }
        else if (Input.GetButtonDown("Fire1"))
        {
            facingRight = plMove.getFacingRight();
            up = Input.GetKey("w");
            //fire ball
            if (up)
            {
                rb.velocity = transform.up * speed;
            }
            else if (facingRight)
            {
                rb.velocity = transform.right * speed;
            }
            else if(!facingRight)
            {
                
                rb.velocity = new Vector2(speed * -1,rb.velocity.y);
            }
            
            teleOut = !teleOut;
        }
        else if (!teleOut)
        {
            facingRight = plMove.getFacingRight();
            roboPos = roboPrefab.GetComponent<Transform>();
            up = Input.GetKey("w");
            //keeps ball where needed
            if (up)
            {
                pos.position = new Vector3(roboPos.position.x, roboPos.position.y + 0.08f, 0);
            }
            else if (facingRight)
            {
                pos.position = new Vector3(roboPos.position.x + 0.08f,roboPos.position.y - 0.015f, 0);
                
            }else if (!facingRight)
            {
                pos.position = new Vector3(roboPos.position.x - 0.08f, roboPos.position.y - 0.015f, 0);
            }
            
        }
        
    }

    void fixedUpdate()
    {
        
    }

    //when the ball collides with an object it can then be teleported to
    void OnTriggerEnter2D(Collider2D thing)
    {
        if (teleOut)
        {
            if (thing.name != "Robo")
            {
                rb.gravityScale = 0.5f;
                rb.velocity = new Vector3(0, 0, 0);
            }
        }
    }
}
