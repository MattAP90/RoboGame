using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchTriggerRight : MonoBehaviour
{
    private Vector2 switchStartPos;
    private Vector2 switchPressPos;
    private Vector3 openPos;
    private Vector3 closedPos;
    private Vector3 tempPos;
    private Rigidbody2D ballRB;
    private Rigidbody2D doorRB;
    private Transform doorPos;
    public GameObject doorPrefab;
    public GameObject ballPrefab;
    
    // Start is called before the first frame update
    void Start()
    {

        ballRB = ballPrefab.GetComponent<Rigidbody2D>();
        doorPos = doorPrefab.GetComponent<Transform>();
        doorRB = doorPrefab.GetComponent<Rigidbody2D>();

        switchStartPos = new Vector2(GetComponent<Transform>().position.x, GetComponent<Transform>().position.y);
        switchPressPos = new Vector2(GetComponent<Transform>().position.x, GetComponent<Transform>().position.y - 0.04f);
        closedPos = doorPos.position;
        openPos = new Vector3(closedPos.x + 0.16f, closedPos.y, 0f);
        tempPos = doorPos.position;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        tempPos = doorPos.position;
        if (tempPos.x > openPos.x || tempPos.x < closedPos.x)
        {
            doorRB.velocity = new Vector3(0, 0, 0);

            if (tempPos.x > openPos.x)
            {
                doorPos.position = openPos;
            }
            else if (tempPos.x < closedPos.x)
            {
                doorPos.position = closedPos;
            }
        }

        
    }

    //triggers when an object collides with the switch
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if(hitInfo.name == "Robo" || (hitInfo.name == "TeleportBall" && !hitInfo.isTrigger))
        {
            GetComponent<Transform>().position = switchPressPos;
            doorRB.velocity = new Vector3(.8f, 0, 0);
               
        }
    }

    void OnTriggerExit2D(Collider2D hitInfo)
    {
        if (hitInfo.name == "Robo" || hitInfo.name == "TeleportBall" && !hitInfo.isTrigger)
        {
            doorRB.velocity = new Vector3(-.8f, 0, 0);
            GetComponent<Transform>().position = switchStartPos;
        }
    }
}
