using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateBalls : MonoBehaviour
{
    [SerializeField] GameObject ball;
    private Transform playerPos;
    public static List<List<GameObject>> balls = new List<List<GameObject>>();
    Vector3 firstBallOfSecondLine;
    Vector3 nextPosition;
    Vector3 distanceInLine = new Vector3(1, 0, 0);
    public float spawnTime;
    public float spawnDelay;
    public float stayTime;
    public float pauseTime;

    private bool isPaused = false;
    private Vector3 distanceBtw2ballsin2lines = new Vector3(0.5f, Mathf.Sqrt(3) / 2, 0f);
    // Start is called before the first frame update
    private void Awake()
    {
        playerPos = gameObject.GetComponent<Transform>();
    }
    void Start()
    {
        InvokeRepeating(nameof(BallInstantiation), spawnTime, spawnDelay);
        InvokeRepeating(nameof(Pause), spawnTime + 2, spawnDelay);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Down();
    }

    public void BallInstantiation()
    {
        nextPosition = playerPos.transform.position;
        List<GameObject> rowballs1 = new List<GameObject>();
        List<GameObject> rowballs2 = new List<GameObject>();
        for (int i = 0; i < 10; i++)
        {
            rowballs1.Add(Instantiate(ball, nextPosition, Quaternion.identity));
            nextPosition = nextPosition + distanceInLine;
        }
        balls.Add(rowballs1);
        firstBallOfSecondLine = playerPos.transform.position - distanceBtw2ballsin2lines;
        nextPosition = firstBallOfSecondLine;
        for (int i = 0; i < 11; i++)
        {
            rowballs2.Add(Instantiate(ball, nextPosition, Quaternion.identity));
            nextPosition = nextPosition + distanceInLine;
        }
        balls.Add(rowballs2);
    }
    public void Down()
    {
        foreach (var row in balls)
        {
            foreach (var egg in row)
            {
                if (!isPaused)
                {
                    egg.transform.Translate(new Vector2(0, -(Mathf.Sqrt(3) * Time.deltaTime) / 2), Space.Self);
                }
                else egg.transform.Translate(new Vector2(0, 0), Space.Self);
            }
        }
    }

    public void Pause()
    {
        isPaused = true;
        Invoke(nameof(Pause), stayTime);
        Invoke(nameof(Resume), stayTime + pauseTime);
    }
    public void Resume()
    {
        isPaused = false;
    }
}
