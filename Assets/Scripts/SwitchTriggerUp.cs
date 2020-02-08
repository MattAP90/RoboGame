using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchTriggerUp : MonoBehaviour
{

    private Vector2 switchStartPos;
    private Vector2 switchPressPos;
    private Vector3 newPos;
    private Vector3 oldPos;
    private Rigidbody2D ballRB;
    private Transform doorPos;
    private BoxCollider2D doorColl;
    private Vector3 addVector;
    public GameObject doorPrefab;
    public GameObject ballPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        addVector = new Vector3(0f, 0.01f, 0f);
        ballRB = ballPrefab.GetComponent<Rigidbody2D>();
        doorPos = doorPrefab.GetComponent<Transform>();
        doorColl = doorPrefab.GetComponent<BoxCollider2D>();

        switchStartPos = new Vector2(GetComponent<Transform>().position.x, GetComponent<Transform>().position.y);
        switchPressPos = new Vector2(GetComponent<Transform>().position.x, GetComponent<Transform>().position.y - 0.04f);
        oldPos = doorPos.position;
        newPos = new Vector3(oldPos.x, oldPos.y + 0.16f, 0f);

    }

    // Update is called once per frame
    void Update() { }

    //triggers when an object collides with the switch
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.name == "Robo" || (hitInfo.name == "TeleportBall" && !hitInfo.isTrigger))
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
