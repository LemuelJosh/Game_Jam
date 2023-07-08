using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float distance = 1.0f; // adjust the distance of each movement in the Inspector
    public MoveRow moveRow;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            moveRow.MoveLeft(distance);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            moveRow.MoveRight(distance);
        }
    }
}
