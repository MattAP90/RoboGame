using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchTrigger : MonoBehaviour
{

    private Vector2 switchStartPos;
    private Vector2 switchPressPos;
    private Vector3 newPos;
    private Vector3 oldPos;
    private Vector2 stillBall;
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
        stillBall = new Vector2(0,0);
        oldPos = tilePos.position;
        newPos = new Vector3(oldPos.x, oldPos.y - 0.16f, 0f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //triggers when an object collides with the switch
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if(hitInfo.name == "Robo" || (hitInfo.name == "TeleportBall" && ballRB.velocity == stillBall))
        {
            tilePos.position = newPos;
            GetComponent<Transform>().position = switchPressPos;            
        }
    }

    void OnTriggerExit2D(Collider2D hitInfo)
    {
        if (hitInfo.name == "Robo" || hitInfo.name == "TeleportBall")
        {
            tilePos.position = oldPos;
            GetComponent<Transform>().position = switchStartPos;

        }
    }
}
