using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    Vector2 startPos = new Vector2(0,0);
    public GameObject roboPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.name == "Robo")
        {

            Transform roboPos = roboPrefab.GetComponent<Transform>();

            roboPos.position = startPos;

        }
    }
}
