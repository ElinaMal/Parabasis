using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAttacking : MonoBehaviour
{
    public RaycastHit2D hit;
    public Transform player;
    public bool attacking;
    [SerializeField] private float attackRange;
    [SerializeField] private float timer;
    [SerializeField] private float attackLimit;
    [SerializeField] private float damage;
    [SerializeField] private bool Pierce;
    [SerializeField] private bool Slash;
    [SerializeField] private bool Blunt;
    [SerializeField] private bool AN;
    [SerializeField] private bool Burn;
    [SerializeField] private int burnAmount;
    [SerializeField] private int burnDamage;

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
            attacking = true;
        }
        else
        {
            attacking = false;
        }

        if (attacking)
        {
            timer += Time.deltaTime;

            if (timer >= attackLimit)
            {
                attacking = false;
                timer = 0;
            }
        }

        if (attacking)
        {
            if (hit.collider.GetComponent<Health>() != null)
            {
                Health health = hit.collider.GetComponent<Health>();
                health.Damage(damage, Pierce, Slash, Blunt, AN, Burn, burnAmount, burnDamage);
            }
        }
    }
}
