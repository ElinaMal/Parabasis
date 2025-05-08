using UnityEngine;

public class Boar : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Hercules")
        {
            Health health = collision.gameObject.GetComponent<Health>();

            health.Damage(1, Vector2.zero);
        }
    }
}
