using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPressed : MonoBehaviour
{

    private bool pressed;
    private Animator switchAnimator;

    // Start is called before the first frame update
    void Start()
    {
        pressed = false;
        switchAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {}

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if(hitInfo.name == "Robo" || hitInfo.name == "TeleportBall" && !hitInfo.isTrigger)
        {
            pressed = true;
            switchAnimator.SetBool("pressed", true);
        }
    }

    void OnTriggerExit2D(Collider2D hitInfo)
    {
        if (hitInfo.name == "Robo" || hitInfo.name == "TeleportBall" && !hitInfo.isTrigger)
        {
            pressed = false;
            switchAnimator.SetBool("pressed", false);
        }
    }

    public bool getPressed()
    {
        return pressed;
    }
}
