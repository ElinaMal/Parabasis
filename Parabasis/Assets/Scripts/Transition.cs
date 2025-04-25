using UnityEngine;

public class Transition : MonoBehaviour
{
    public Transform cam;
    public Transform destination;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            collider.transform.position = destination.position;
            cam.position = destination.position;
        }
    }
}
