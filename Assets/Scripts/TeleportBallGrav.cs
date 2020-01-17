using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportBallGrav : MonoBehaviour
{

    private float speed;
    private bool teleOut;
    private bool canTeleport;
    private bool facingRight;
    private bool up;
    private Rigidbody2D rb;
    public GameObject roboPrefab;
    private Transform roboPos;
    private PlayerMovement plMove;
    private Transform pos;
    private CircleCollider2D cirColl;
    private CapsuleCollider2D capColl;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pos = GetComponent<Transform>();
        canTeleport = false;
        teleOut = false;
        plMove = roboPrefab.GetComponent<PlayerMovement>();
        speed = 1f;
        cirColl = GetComponent<CircleCollider2D>();
        capColl = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire2"))
        {
            //reset all variables and gravity if player retracts the ball
            teleOut = false;
            canTeleport = false;
            cirColl.enabled = false;
            capColl.enabled = false;
            rb.gravityScale = 0f;
        }
        else if (Input.GetButtonDown("Fire1") && capColl.enabled)
        {
            //when teleported to, reset varibles
            teleOut = false;
            canTeleport = false;
            cirColl.enabled = false;
            capColl.enabled = false;
            rb.gravityScale = 0f;
        }
        else if (Input.GetButtonDown("Fire1"))
        {
                        
            facingRight = plMove.getFacingRight();
            up = Input.GetKey("w");
            rb.gravityScale = .1f;
            //fire ball
            if (up)
            {
                rb.velocity = transform.up * speed;
                
            }
            else if (facingRight)
            {
                rb.velocity = transform.right * speed;
                
            }
            else if (!facingRight)
            {

                rb.velocity = (-1 * transform.right) * speed;
            }

            teleOut = true;
            capColl.enabled = true;
            canTeleport = true;

        }
        else if (!teleOut)
        {
            keepBallOnPlayer();
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
            if (thing.name != "Robo" && thing.name != "Switch")
            {
                capColl.enabled = true;
                cirColl.enabled = true;
                rb.gravityScale = .5f;
                rb.velocity = new Vector3(0, 0, 0);
            }
        }
    }

    void keepBallOnPlayer()
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
            pos.position = new Vector3(roboPos.position.x + 0.08f, roboPos.position.y - 0.015f, 0);

        }
        else if (!facingRight)
        {
            pos.position = new Vector3(roboPos.position.x - 0.08f, roboPos.position.y - 0.015f, 0);
        }
    }

    public bool getCanTeleport()
    {
        return canTeleport;
    }
}
