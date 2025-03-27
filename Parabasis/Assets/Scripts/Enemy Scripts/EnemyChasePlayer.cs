using Unity.VisualScripting;
using UnityEngine;

public class EnemyChasePlayer : MonoBehaviour
{
    public Transform player;
    [SerializeField] private float detectionRange;
    [SerializeField] private float velocity;
    public GameObject pointA;
    public GameObject pointB;
    public EnemyPatrol enemyPatrol;
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 enemyToPlayer = player.position - transform.position;
        Vector2 directionToPlayer = enemyToPlayer.normalized;
        float distance = enemyToPlayer.magnitude;

        if (transform.position.x <= pointA.transform.position.x || transform.position.x >= pointB.transform.position.x)
        {
            enemyPatrol.enabled = true;
        }
        else if (distance < detectionRange)
        {
            enemyPatrol.enabled = false;

            if (directionToPlayer.x == 0)
            {
                _rb.linearVelocityX = 0;
            }
            else if (directionToPlayer.x > 0)
            {
                _rb.linearVelocityX = velocity;
            }
            else
            {
                _rb.linearVelocityX = -velocity;
            }
        }
        else
        {
            enemyPatrol.enabled = true;
        }
    }
}
