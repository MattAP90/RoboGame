using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportBallAnimator : MonoBehaviour
{

    private Animator animator;
    public GameObject tBall;
    private bool charging;
    private bool canTeleport;

    // Start is called before the first frame update
    void Start()
    {
        //gets this game objects animator
        animator = gameObject.GetComponent<Animator>();

        //set variables for the animations 
        charging = false;
        canTeleport = false;
    }

    // Update is called once per frame
    void Update()
    {


        charging = tBall.GetComponent<TeleportBallGravPower>().getBallCharging();
        canTeleport = tBall.GetComponent<TeleportBallGravPower>().getCanTeleport();

        if (charging)
        {
            animator.SetBool("isCharging", true);
        }

        if (canTeleport)
        {
            animator.SetBool("canTeleport", true);
        }

        if (!canTeleport && !charging)
        {
            animator.SetBool("canTeleport", false);
            animator.SetBool("isCharging", false);
        }
    }
}
