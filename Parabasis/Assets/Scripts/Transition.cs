using UnityEngine;

public class Transition : MonoBehaviour
{
    public Transform cam;
    public Transform destination;
    public float displacement;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            Vector2 player = new Vector2(destination.position.x + displacement, destination.position.y);
            collider.transform.position = player;
            cam.position = player;
        }
    }
}
