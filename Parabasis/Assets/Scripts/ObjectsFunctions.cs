using UnityEngine;

public class ObjectsFunctions : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Hercules")
        {
            Health health = collision.GetComponent<Health>();
            //if (health.health < health.MAX)
        }
    }
}
