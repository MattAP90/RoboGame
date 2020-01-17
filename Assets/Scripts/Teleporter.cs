using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{

    private bool canTeleport;
    public GameObject ballPrefab;

    private Transform pos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //change based on what script we are using w/ Gravity or w/o gravity
        //teleOut = ballPrefab.GetComponent<TeleportBall>().getTeleOut();
        canTeleport = ballPrefab.GetComponent<TeleportBallGrav>().getCanTeleport();
        if (Input.GetButtonDown("Fire1") && !canTeleport)
        {
            Teleport();
        }

    }

    //gets the position of the ball and teleports the player to that position
    void Teleport()
    {
        
        Transform ballPos = ballPrefab.GetComponent<Transform>();
        Rigidbody2D ballRB = ballPrefab.GetComponent<Rigidbody2D>();
        pos = GetComponent<Transform>();

        pos.position = ballPos.position;
    }
}
