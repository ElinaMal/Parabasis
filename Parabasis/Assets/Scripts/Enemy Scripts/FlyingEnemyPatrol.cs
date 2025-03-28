using UnityEngine;

public class FlyingEnemyPatrol : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    public GameObject pointC;
    public GameObject pointD;
    public Vector2 currentDestination;
    [SerializeField] private float velocity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentDestination = pointB.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x == pointA.transform.position.x)
        {
            currentDestination = pointB.transform.position;
        }
        if (transform.position.x == pointB.transform.position.x)
        {
            currentDestination = pointC.transform.position;
        }
        if (transform.position.x == pointC.transform.position.x)
        {
            currentDestination = pointD.transform.position;
        }
        if (transform.position.x == pointD.transform.position.x)
        {
            currentDestination = pointA.transform.position;
        }

        transform.position = Vector2.MoveTowards(transform.position, currentDestination, velocity);
    }
}
