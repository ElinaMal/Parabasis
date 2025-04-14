using UnityEngine;
using System.Collections;

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
    [SerializeField] private float correctionVelocity;
    [SerializeField] private float velocity;
    [SerializeField] private float radius;
    private Rigidbody2D _rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

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

            /*
            if (seeX < 0 )
            {
                path.x = -seeX;
            }
            if (seeY < 0)
            {
                path.y = -seeY;
            }
            if (seeX > 0)
            {
                path.x = -seeX;
            }
            if (seeY > 0)
            {
                path.y = -seeY;
            }
            */

            _rb.linearVelocity = path * correctionVelocity;
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, currentDestination, velocity);
        }
    }
}
