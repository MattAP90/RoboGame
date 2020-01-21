using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeBar : MonoBehaviour
{

    private Animator animator;
    public GameObject tBall;
    private bool charging;
    private bool isCharged;
    // Start is called before the first frame update
    void Start()
    {
        //gets this game objects animator
        animator = gameObject.GetComponent<Animator>();

        //set variables for the animations 
        charging = false;
        isCharged = false;
    }

    // Update is called once per frame
    void Update()
    {

        charging = tBall.GetComponent<TeleportBallGravPower>().getCharging();
        isCharged = tBall.GetComponent<TeleportBallGravPower>().getFullCharge();

        if (charging)
        {
            animator.SetBool("isCharging", true);
        }

        if (isCharged)
        {
            animator.SetBool("fullyCharged", true);
        }

        if (!isCharged && !charging)
        {
            animator.SetBool("fullyCharged", false);
            animator.SetBool("isCharging", false);
        }
    }
}
