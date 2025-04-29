using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5;
    public float jumpSpeed = 5f;
    public float dJumpSpeed = 5f;
    public Animator anim;
    private Rigidbody2D rb;
    private Vector2 _moveDirection;
    public float gravityScale = 5f;
    public float fallingGravityScale = 30f;
    private float currentGravityScale;
    private bool isFacingRight = true;

    public float movementX;
    private float movementY;

    public bool readyJump;
    public bool jumpUnlocked;

    public bool dashUnlocked;
    private bool canDash;
    private bool isDashing;
    public bool isWalking;
    public bool moveHorizontal;
    //private bool dashReady = true;
    public float dashingPower = 24f;
    public float dashingTime = 0.2f;
    //private float dashingCooldown = 1f;

    public Knockback knockback;

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
        return Physics2D.Raycast(transform.position, Vector2.down, 1.5f, Floor); 
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        if (!isDashing)
        {
            Vector2 movementVector = ctx.ReadValue<Vector2>();

            movementX = movementVector.x;

            moveHorizontal = true;

            if (IsGrounded())
            {
                isWalking = true;
            }
            else
            {
                isWalking = false;
            }
        }

        if (ctx.ReadValue<Vector2>().x == 0)
        {
            isWalking = false;
            moveHorizontal = false;
        }
    }

    private void Update()
    {
        if(rb.linearVelocity.y >= 0 && !isDashing)
        {
            currentGravityScale = gravityScale;
        }
        else
        {
            currentGravityScale = fallingGravityScale;
        }

        if (!isDashing)
        {
            Flip();
        }

        if(IsGrounded() && jumpUnlocked)
        {
            readyJump = true;
        }

        if(IsGrounded() && dashUnlocked)
        {
            canDash = true;
        }

        if (!IsGrounded())
        {
            isWalking = false;
        }

        if (IsGrounded() && moveHorizontal)
        {
            isWalking = true;
        }

        anim.SetBool("isWalking", isWalking);
    }

    public void Jump(InputAction.CallbackContext ctx)
    {
        if (!isDashing && !knockback.IsBeingKnockedBack && IsGrounded() && ctx.ReadValue<float>() == 1)
        {
            rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
        }

        if (!isDashing && readyJump && !knockback.IsBeingKnockedBack && IsGrounded() == false && ctx.ReadValue<float>() == 1)
        {
            rb.linearVelocityY = 0;
            rb.AddForce(Vector2.up * dJumpSpeed, ForceMode2D.Impulse);
            readyJump = false;
        }
    }

    public void Dash(InputAction.CallbackContext ctx)
    {
        if (canDash && !isDashing && !knockback.IsBeingKnockedBack)
        {
            StartCoroutine(Dash());
        }
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        //dashReady = false;
        float originalGravity = rb.gravityScale;
        float originalGravityMult = currentGravityScale;
        rb.gravityScale = 0f;
        currentGravityScale = 0;
        rb.linearVelocityX = transform.localScale.x * dashingPower;
        yield return new WaitForSeconds(dashingTime);
        rb.gravityScale = originalGravity;
        currentGravityScale = originalGravityMult;
        isDashing = false;
        //yield return new WaitForSeconds(dashingCooldown);
        //dashReady = true;
    }

    private void Flip()
    {
        if (isFacingRight && rb.linearVelocityX < 0f || !isFacingRight && rb.linearVelocityX > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }
        if (!knockback.IsBeingKnockedBack)
        {
            rb.linearVelocityX = (movementX * movementSpeed);
            rb.AddForce(Physics2D.gravity * (currentGravityScale - 1) * rb.mass);
        }
    }
}
