using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAttacking : MonoBehaviour
{
    public RaycastHit2D hit;
    LayerMask mask;
    public Transform player;
    public bool attacking;
    [SerializeField] private float attackRange;
    [SerializeField] private float timer;
    [SerializeField] private float attackLimit;
    [SerializeField] private float attackTime;
    [SerializeField] private float delay;
    [SerializeField] private float damage;
    [SerializeField] private bool canAttack;
    [SerializeField] private bool Pierce;
    [SerializeField] private bool Slash;
    [SerializeField] private bool Blunt;
    [SerializeField] private bool AN;
    [SerializeField] private bool Burn;
    [SerializeField] private int burnAmount;
    [SerializeField] private int burnDamage;

    private void Awake()
    {
        LayerMask layerMask = LayerMask.GetMask("Platform", "Floor", "Player");
        mask = layerMask;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 enemyToPlayer = player.position - transform.position;
        Vector2 directionToPlayer = enemyToPlayer.normalized;

        hit = Physics2D.Raycast(transform.position, directionToPlayer, attackRange, mask);

        if (player.position.y < transform.position.y + 0.5f && Physics2D.Raycast(transform.position, directionToPlayer, attackRange, mask))
        {
            if (hit.collider.GetComponent<Health>() != null && canAttack)
            {
                canAttack = false;
                attackTime = 0;
                attacking = true;

                Health health = hit.collider.GetComponent<Health>();
                health.Damage(damage, Pierce, Slash, Blunt, AN, Burn, burnAmount, burnDamage);
            }
        }

        // time for the attack
        if (attacking)
        {
            timer += Time.deltaTime;

            if (timer >= attackLimit)
            {
                attacking = false;
                timer = 0;
            }
        }

        attackTime += Time.deltaTime;

        //cooldown
        if (attackTime >= delay)
        {
            canAttack = true;
        }
    }
}
