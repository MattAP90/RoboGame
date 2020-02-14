using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLeft : MonoBehaviour
{
    private Vector3 openPos;
    private Vector3 closedPos;
    private Vector3 tempPos;
    private Vector3 doorOpenVel;
    private Vector3 doorCloseVel;
    private Vector3 resetVel;
    private Rigidbody2D doorRB;
    private Transform doorPos;
    private SwitchPressed swiPress;
    public GameObject switchPrefab;


    // Start is called before the first frame update
    void Start()
    {
        doorRB = GetComponent<Rigidbody2D>();
        doorPos = GetComponent<Transform>();
        swiPress = switchPrefab.GetComponent<SwitchPressed>();

        openPos = new Vector3(doorPos.position.x - 0.16f, doorPos.position.y, doorPos.position.z);
        closedPos = doorPos.position;
        tempPos = doorPos.position;
        doorOpenVel = new Vector3(-.8f, 0, 0);
        doorCloseVel = new Vector3(.8f, 0, 0);
        resetVel = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        tempPos = doorPos.position;

        if (swiPress.getPressed() && tempPos.x > openPos.x)
        {
            doorRB.velocity = doorOpenVel;
        }
        else if (!swiPress.getPressed() && tempPos.x < closedPos.x)
        {
            doorRB.velocity = doorCloseVel;
        }
        else
        {
            doorRB.velocity = resetVel;
        }

        if (tempPos.x > closedPos.x)
        {
            doorPos.position = closedPos;
        }
        else if (tempPos.x < openPos.x)
        {
            doorPos.position = openPos;
        }


    }
}
