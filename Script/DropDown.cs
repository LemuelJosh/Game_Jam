using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropDown : MonoBehaviour
{
    public GameObject spawnee; // Assign the prefab for the object you want to spawn in the Inspector
    public float speed = 1f; // Adjust the speed of the movement in the Inspector
    public float spawnTime;
    public float spawnDelay;
    public bool stopSpawning = false;

    void Start()
    {
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
    }

    public void SpawnObject()
    {
        GameObject newObj = Instantiate(spawnee, transform.position, transform.rotation);
        if (stopSpawning)
        {
            CancelInvoke("SpawnObject");
        }
        // Add a script to the spawned object to move it down
        newObj.AddComponent<MoveDown>().speed = speed;
    }
}
