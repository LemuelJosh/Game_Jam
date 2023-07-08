using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    public float speed = 1f;
    public float stayTime = 1f;
    public float pauseTime = 1f;
    public int numPauses = 10;

    private bool isPaused = false;
    private int pauseCount = 0;

    void Update()
    {
        if (!isPaused)
        {
            transform.position -= Vector3.up * speed * Time.deltaTime;
        }
    }

    void Start()
    {
        pauseCount = 0;
        Invoke("Pause", pauseTime);
    }

    void Pause()
    {
        pauseCount++;
        if (pauseCount <= numPauses)
        {
            isPaused = true;
            Invoke("Resume", stayTime);
            Invoke("Pause", stayTime + pauseTime);
        }
        else
        {
            isPaused = false;
        }
    }

    void Resume()
    {
        isPaused = false;
    }
}
