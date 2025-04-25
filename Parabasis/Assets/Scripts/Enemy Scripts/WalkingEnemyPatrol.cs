using UnityEngine;

public class WalkingEnemyPatrol : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    public Vector3 currentDestination;
    [SerializeField] private float velocity;

    private void Awake()
    {
        currentDestination = pointB.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= pointA.transform.position.x)
        {
            currentDestination = pointB.transform.position;
        }
        if (transform.position.x >= pointB.transform.position.x)
        {
            currentDestination = pointA.transform.position;
        }

        Vector2 enemyToDestination = currentDestination - transform.position;
        Vector2 directionToDestination = enemyToDestination.normalized;

        if (directionToDestination.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, -180, 0);
        }

        transform.position = Vector2.MoveTowards(transform.position, currentDestination, velocity * Time.deltaTime);
    }
}
