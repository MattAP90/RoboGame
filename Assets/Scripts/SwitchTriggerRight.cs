using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchTriggerRight : MonoBehaviour
{

    private Vector2 switchStartPos;
    private Vector2 switchPressPos;
    private Vector3 newPos;
    private Vector3 oldPos;
    private Rigidbody2D ballRB;
    private Transform doorPos;
    private BoxCollider2D doorColl;
    public GameObject doorPrefab;
    public GameObject ballPrefab;
    
    // Start is called before the first frame update
    void Start()
    {

        ballRB = ballPrefab.GetComponent<Rigidbody2D>();
        doorPos = doorPrefab.GetComponent<Transform>();
        doorColl = doorPrefab.GetComponent<BoxCollider2D>();

        switchStartPos = new Vector2(GetComponent<Transform>().position.x, GetComponent<Transform>().position.y);
        switchPressPos = new Vector2(GetComponent<Transform>().position.x, GetComponent<Transform>().position.y - 0.04f);
        oldPos = doorPos.position;
        newPos = new Vector3(oldPos.x + 0.16f, oldPos.y, 0f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //triggers when an object collides with the switch
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if(hitInfo.name == "Robo" || (hitInfo.name == "TeleportBall" && !hitInfo.isTrigger))
        {
            doorPos.position = newPos;
            GetComponent<Transform>().position = switchPressPos;
            doorColl.enabled = false;
            
        }
    }

    void OnTriggerExit2D(Collider2D hitInfo)
    {
        if (hitInfo.name == "Robo" || hitInfo.name == "TeleportBall" && !hitInfo.isTrigger)
        {
            doorPos.position = oldPos;
            GetComponent<Transform>().position = switchStartPos;
            doorColl.enabled = true;

        }
    }
}
