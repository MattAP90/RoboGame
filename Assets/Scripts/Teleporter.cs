using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{

    private bool canShoot = true;
    public GameObject ballPrefab;
    private Transform pos;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetButtonDown("Fire1") && canShoot)
        {
            canShoot = !canShoot;
        }else if (Input.GetButtonDown("Fire1") && !canShoot)
        {
            Teleport();
        }

    }

    //gets the position of the ball and teleports the player to that position
    void Teleport()
    {
        Transform ballPos = ballPrefab.GetComponent<Transform>();
        Rigidbody2D ballRB = ballPrefab.GetComponent<Rigidbody2D>();
        ballRB.gravityScale = 0f;
        pos = GetComponent<Transform>();

        pos.position = ballPos.position;

        canShoot = !canShoot;
    }
}
