using System.Threading;
using UnityEngine;

public class EnemyAttacking : MonoBehaviour
{
    public RaycastHit2D hit;
    public Transform player;
    [SerializeField] private float attackRange;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 enemyToPlayer = player.position - transform.position;
        Vector2 directionToPlayer = enemyToPlayer.normalized;

        hit = Physics2D.Raycast(transform.position, directionToPlayer, attackRange);

        if (Physics2D.Raycast(transform.position, directionToPlayer, attackRange))
        {
            
        }
    }
}
