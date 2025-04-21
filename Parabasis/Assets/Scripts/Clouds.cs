using UnityEngine;

public class Clouds : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Transform initial;
    [SerializeField] float velocity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        _rb.linearVelocityX = -velocity;
    }
}
