using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRow : MonoBehaviour
{
    public float rowSpeed = 1.0f;

    private Vector3 originalPosition;

    void Start()
    {
        originalPosition = transform.position;
    }

    public void MoveLeft(float distance)
    {
        transform.position += Vector3.left * distance;
    }

    public void MoveRight(float distance)
    {
        transform.position += Vector3.right * distance;
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, originalPosition.y - Time.time * rowSpeed, transform.position.z);
    }
}
