using UnityEngine;

public class FlyingEnemyPatrol : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    public GameObject pointC;
    public GameObject pointD;
    public Vector2 currentDestination;
    public Vector2 check;
    public Vector2 path;
    [SerializeField] private float detectionRange;
    [SerializeField] private float velocity;
    [SerializeField] private float radius;

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
            check = pointB.transform.position - transform.position;
        }
        if (transform.position.x == pointB.transform.position.x)
        {
            currentDestination = pointC.transform.position;
            check = pointC.transform.position - transform.position;
        }
        if (transform.position.x == pointC.transform.position.x)
        {
            currentDestination = pointD.transform.position;
            check = pointD.transform.position - transform.position;
        }
        if (transform.position.x == pointD.transform.position.x)
        {
            currentDestination = pointA.transform.position;
            check = pointA.transform.position - transform.position;
        }

        Vector2 direction = check.normalized;

        if (Physics2D.CircleCast(transform.position, radius, direction, detectionRange))
        {
            float seeX = direction.x;
            float seeY = direction.y;

            if ((seeX == 1 && seeY > 0) || (seeX < 0 && seeY == -1))
            {
                path = new Vector2(-1, 1);
            }
            else if ((seeX > 0 && seeY == 1) || (seeX == -1 && seeY < 0))
            {
                path = new Vector2(1, -1);
            }
            else if ((seeX < 0 && seeY == 1) || (seeX == 1 && seeY < 0))
            {
                path = new Vector2(-1, -1);
            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, currentDestination, velocity);
        }
    }
}
