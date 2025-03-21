using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private Vector2 movement;
    [SerializeField] private float velocity;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = movement * velocity;
    }

    public void HandleMovement(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }
}
