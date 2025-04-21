using Unity.VisualScripting;
using UnityEngine;

public class EnemyChasePlayer : MonoBehaviour
{
    public Transform player;
    [SerializeField] private float detectionRange;
    [SerializeField] private float velocity;
    LayerMask mask;
    public GameObject pointA;
    public GameObject pointB;
    public WalkingEnemyPatrol enemyPatrol;
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        LayerMask layerMask = LayerMask.GetMask("Platform", "Player", "Floor");
        mask = layerMask;
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

        else if (Physics2D.Raycast(transform.position, directionToPlayer, detectionRange, mask))
        {
            enemyPatrol.enabled = false;

            if (transform.position.x + 1 > player.position.x && transform.position.x - 1 < player.position.x)
            {
                _rb.linearVelocityX = 0;
            }
            else if (directionToPlayer.x > 0)
            {
                _rb.linearVelocityX = velocity;
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                _rb.linearVelocityX = -velocity;
                transform.rotation = Quaternion.Euler(0, -180, 0);
            }
        }
        else
        {
            enemyPatrol.enabled = true;
        }
    }
}
