using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5;
    public float jumpSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 _moveDirection;
    public float gravityScale = 5f;
    public float fallingGravityScale = 30f;
    private float currentGravityScale;

    private float movementX;
    private float movementY;

    public LayerMask Floor;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        currentGravityScale = gravityScale;
    }

    bool IsGrounded() 
    { 
        return Physics2D.Raycast(transform.position, Vector2.down, 1.1f, Floor); 
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        Vector2 movementVector = ctx.ReadValue<Vector2>();

        movementX = movementVector.x;
    }

    private void Update()
    {
        if(rb.linearVelocity.y >= 0)
        {
            currentGravityScale = gravityScale;
        }
        else
        {
            currentGravityScale = fallingGravityScale;
        }
    }

    public void Jump(InputAction.CallbackContext ctx)
    {
        if (IsGrounded() && ctx.ReadValue<float>() == 1)
        {
            rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocityX = (movementX * movementSpeed);
        rb.AddForce(Physics2D.gravity * (currentGravityScale - 1) * rb.mass);
    }
}
