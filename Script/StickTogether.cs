using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickTogether : MonoBehaviour
{

    private bool isStuck = false;
    private GameObject otherObject;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<StickTogether>() != null)
        {
            isStuck = true;
            otherObject = other.gameObject;
            otherObject.AddComponent<MoveDown>();
        }
    }

    void Update()
    {
        if (isStuck)
        {
            transform.position = otherObject.transform.position;
            GetComponent<MoveDown>().speed = otherObject.GetComponent<MoveDown>().speed;
        }
    }
}

