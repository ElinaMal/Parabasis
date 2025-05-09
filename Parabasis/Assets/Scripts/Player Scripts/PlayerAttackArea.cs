using UnityEngine;

public class PlayerAttackArea : MonoBehaviour
{
    [SerializeField] private float damage = 3;

    [SerializeField] private bool Pierce;
    [SerializeField] private bool Slash;
    [SerializeField] private bool Blunt;
    [SerializeField] private bool AN;
    [SerializeField] private bool Burn;
    [SerializeField] private int burnAmount;
    [SerializeField] private int burnDamage;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Vector2 projectileToTarget = transform.position - collider.transform.position;
        Vector2 directionToImpact = projectileToTarget.normalized;

        if (collider.GetComponent<Health>() != null)
        {
            Health health = collider.GetComponent<Health>();
            health.Damage(damage, directionToImpact, Pierce, Slash, Blunt, AN, Burn, burnAmount, burnDamage);
        }
    }
}