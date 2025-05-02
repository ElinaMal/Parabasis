using UnityEngine;

public class ObjectsFunctions : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Hercules")
        {
            if (gameObject.name == "Heal")
            {
                Health health = collision.GetComponent<Health>();

                if (health.health < health.MAX_HEALTH)
                {
                    health.Heal(1);
                    Destroy(gameObject);
                }
            }
            else if (gameObject.name == "JumpMask")
            {
                PlayerMovement playerMovement = collision.GetComponent<PlayerMovement>();
                playerMovement.jumpUnlocked = true;
                Destroy(gameObject);
            }
            else if (gameObject.name == "DashMask")
            {
                PlayerMovement playerMovement = collision.GetComponent<PlayerMovement>();
                playerMovement.dashUnlocked = true;
                Destroy(gameObject);
            }
            else if (gameObject.name == "StunMask")
            {
                PlayerMelee playerMelee = collision.GetComponent<PlayerMelee>();
                playerMelee.stunUnlocked = true;
                Destroy(gameObject);
            }
            else if (gameObject.name == "thorns")
            {
                Health health = collision.GetComponent<Health>();
                health.health = 0;
                Destroy(collision.gameObject);
            }
            else if (gameObject.name == "boar")
            {
                Health health = collision.GetComponent<Health>();

                health.Damage(1, Vector2.zero);
            }
        }
    }
}
