using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    public Vector2 currentDestination;
    [SerializeField] private float velocity;

    private void Awake()
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
            currentDestination = pointA.transform.position;
        }

        transform.position = Vector2.MoveTowards(transform.position, currentDestination, velocity);
    }
}
