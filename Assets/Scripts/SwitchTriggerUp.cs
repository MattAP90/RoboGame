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
    private Transform tilePos;
    public GameObject tilePrefab;
    public GameObject ballPrefab;
    
    // Start is called before the first frame update
    void Start()
    {

        ballRB = ballPrefab.GetComponent<Rigidbody2D>();
        tilePos = tilePrefab.GetComponent<Transform>();

        switchStartPos = new Vector2(GetComponent<Transform>().position.x, GetComponent<Transform>().position.y);
        switchPressPos = new Vector2(GetComponent<Transform>().position.x, GetComponent<Transform>().position.y - 0.04f);
        oldPos = tilePos.position;
        newPos = new Vector3(oldPos.x, oldPos.y + 0.16f, 0f);

    }

    // Update is called once per frame
    void Update() { }

    //triggers when an object collides with the switch
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.name == "Robo" || (hitInfo.name == "TeleportBall" && !hitInfo.isTrigger && ballRB.velocity.x == 0.0f))
        {
            tilePos.position = newPos;
            GetComponent<Transform>().position = switchPressPos;
            tilePos.Rotate(0f,0f,180f);
        }
    }

    void OnTriggerExit2D(Collider2D hitInfo)
    {
        if (hitInfo.name == "Robo" || hitInfo.name == "TeleportBall" && !hitInfo.isTrigger)
        {
            tilePos.position = oldPos;
            GetComponent<Transform>().position = switchStartPos;
            tilePos.Rotate(0f, 0f, 180f);
        }
    }
}
