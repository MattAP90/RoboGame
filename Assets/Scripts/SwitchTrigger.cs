using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchTrigger : MonoBehaviour
{

    private Vector2 switchStartPos;
    private Vector2 switchPressPos;
    private Vector3 newPos;
    private Vector3 oldPos;
    private Transform tilePos;
    public GameObject tilePrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        switchStartPos = new Vector2(GetComponent<Transform>().position.x, GetComponent<Transform>().position.y);
        switchPressPos = new Vector2(GetComponent<Transform>().position.x, GetComponent<Transform>().position.y - 0.04f);
        tilePos = tilePrefab.GetComponent<Transform>();
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
        if(hitInfo.name == "Robo" || hitInfo.name == "TeleportBall")
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
