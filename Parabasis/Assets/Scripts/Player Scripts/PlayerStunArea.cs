using UnityEngine;

public class PlayerStunArea : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<Stunning>() != null)
        {
            Stunning stunning = collider.GetComponent<Stunning>();
            stunning.Stunned();
        }
    }
}
