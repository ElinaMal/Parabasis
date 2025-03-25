using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5;
    public float jumpHeight = 10;
    private Rigidbody2D rb;
    private Vector2 _moveDirection;

    public InputActionReference jump;

    private float movementX;
    private float movementY;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
    }

    private void OnEnable()
    {
        jump.action.started += Jump;
    }

    private void OnDisable()
    {
        jump.action.started -= Jump;
    }

    private void Jump(InputAction.CallbackContext context)
    {
        movementY = jumpHeight;
    }

    private void FixedUpdate()
    {
        rb.linearVelocityX = (movementX * movementSpeed);
        rb.AddForceY(movementY);
    }
}
