using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportBallGravPower : MonoBehaviour
{
    private float speed;
    private float teleportTimer;
    private bool teleOut;
    private bool canTeleport;
    private bool facingRight;
    private bool up;
    private bool fullCharge;
    private bool charging;
    private Vector3 resetBallSpeed;
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
        Application.targetFrameRate = 60;
        rb = GetComponent<Rigidbody2D>();
        pos = GetComponent<Transform>();
        canTeleport = false;
        teleOut = false;
        resetBallSpeed = new Vector3(0, 0, 0);
        plMove = roboPrefab.GetComponent<PlayerMovement>();
        speed = 1f;
        cirColl = GetComponent<CircleCollider2D>();
        capColl = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    // fire1 is LMB and fire2 is RMB
    void Update()
    {

        if (Input.GetButton("Fire2") && teleOut)
        {
            if (teleportTimer < 20f)
            {
                teleportTimer++;
            }
            else
            {
                canTeleport = true;
            }
        }

        if (Input.GetButtonUp("Fire2"))
        {
            //when teleported to, reset varibles
            resetVariables();
        }
        else if (Input.GetButtonUp("Fire1") && !teleOut)
        {
            shootBall();
        }
        else if (!teleOut)
        {
            keepBallOnPlayer();
        }

        if(Input.GetButton("Fire1") && !teleOut)
        {
            if (speed < 3f)
            {
                speed = speed + .034f;
                charging = true;
            }
            else
            {
                speed = 3f;
                charging = false;
                fullCharge = true;
            }
        }
        else
        {
            speed = 1f;
            fullCharge = false;
            charging = false;

        }

    }

    void fixedUpdate() { }

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
                rb.velocity = resetBallSpeed;
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

    void shootBall()
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
        speed = 1f;
    }
    
    void resetVariables()
    {
        teleOut = false;
        canTeleport = false;
        cirColl.enabled = false;
        capColl.enabled = false;
        rb.gravityScale = 0f;
        rb.velocity = resetBallSpeed;
        speed = 1f;
        teleportTimer = 0f;
    }

    public bool getCanTeleport()
    {
        return canTeleport;
    }

    public bool getFullCharge()
    {
        return fullCharge;
    }

    public bool getCharging()
    {
        return charging;
    }
}
