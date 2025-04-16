using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class FlyingEnemyPatrol : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    public GameObject pointC;
    public GameObject pointD;
    public Transform target;
    public RaycastHit2D hit;
    LayerMask mask;
    public Vector2 currentDestination;
    public Vector2 direction;
    public Vector2 check;
    public Vector2 path;
    [SerializeField] private float correctionVelocity;
    [SerializeField] private float velocity;
    [SerializeField] private float radius;
    public bool trigger;
    private Rigidbody2D _rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        LayerMask layerMask = LayerMask.GetMask("Platform");
        mask = layerMask;
        trigger = false;
        currentDestination = pointB.transform.position;
        target = pointB.transform;
        check = target.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x == pointA.transform.position.x)
        {
            currentDestination = pointB.transform.position;
            target = pointB.transform;
            check = target.position - transform.position;
        }
        if (transform.position.x == pointB.transform.position.x)
        {
            currentDestination = pointC.transform.position;
            target = pointC.transform;
            check = target.position - transform.position;
        }
        if (transform.position.x == pointC.transform.position.x)
        {
            currentDestination = pointD.transform.position;
            target = pointD.transform;
            check = target.position - transform.position;
        }
        if (transform.position.x == pointD.transform.position.x)
        {
            currentDestination = pointA.transform.position;
            target = pointA.transform;
            check = target.position - transform.position;
        }

        direction = check.normalized;

        if (trigger)
        {
            _rb.linearVelocity = path * correctionVelocity;
            StopCoroutine(Coroutine());
        }

        if (Physics2D.CircleCast(transform.position, radius, direction, 0, mask))
        {
            hit = Physics2D.CircleCast(transform.position, radius, direction, 0, mask);
            check = hit.transform.position - transform.position;
            direction = check.normalized;

            float seeX = direction.x;
            float seeY = direction.y;

            if (seeX > 0 && seeY > 0 && !trigger)
            {
                if (seeY > seeX)
                {
                    path = new Vector2(1, -0.5f);
                }
                else
                {
                    path = new Vector2(-0.5f, 1);
                }
            }
            else if (seeX < 0 && seeY < 0 && !trigger)
            {
                if (seeX > seeY)
                {
                    path = new Vector2(1, -0.5f);
                }
                else
                {
                    path = new Vector2(-0.5f, 1);
                }
            }
            else if (seeX < 0 && seeY > 0 && !trigger)
            {
                if (-seeX > seeY)
                {
                    path = new Vector2(0.5f, 1);
                }
                else
                {
                    path = new Vector2(1, -0.5f);
                }
            }
            else if (seeX > 0 && seeY < 0 && !trigger)
            {
                if (seeX > -seeY)
                {
                    path = new Vector2(-0.5f, -1);
                }
                else
                {
                    path = new Vector2(1, 0.5f);
                }
            }

            StartCoroutine(Coroutine());
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, currentDestination, velocity);

            check = target.position - transform.position;
            direction = check.normalized;

            if (direction.x > 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, -180, 0);
            }
        }
    }

    IEnumerator Coroutine()
    {
        trigger = true;

        yield return new WaitForSeconds(1);

        trigger = false;
    }
}
