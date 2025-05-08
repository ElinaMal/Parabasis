using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBlock : MonoBehaviour
{
    public Health health;
    public PlayerMovement playerMovement;
    public PlayerMelee playerMelee;
    public int blockAmount = 1;
    public int storedDefense;
    public float slowMoveAmount = 2;
    public float slowJumpAmount = 2f;
    public float slowdJumpAmount = 2f;
    public float slowDashAmount = 12f;
    public float originalMoveSpeed;
    public float originalJumpSpeed;
    public float originaldJumpSpeed;
    public float originalDashPower;
    public Animator anim;

    private void Start()
    {
        originalMoveSpeed = playerMovement.movementSpeed;
        originalJumpSpeed = playerMovement.jumpSpeed;
        originaldJumpSpeed = playerMovement.dJumpSpeed;
        originalDashPower = playerMovement.dashingPower;
    }

    public void Block(InputAction.CallbackContext ctx)
    {
        if (ctx.ReadValue<float>() == 1)
        {
            playerMovement.movementSpeed = slowMoveAmount;
            playerMovement.jumpSpeed = slowJumpAmount;
            playerMovement.dJumpSpeed = slowdJumpAmount;
            playerMovement.dashingPower = slowDashAmount;
            playerMelee.canAttack = false;
            playerMelee.canStun = false;
            health.defense = blockAmount;
            anim.SetBool("isBlocking", true);
        }

        if (ctx.ReadValue<float>() == 0)
        {
            health.defense = 0;
            playerMovement.movementSpeed = originalMoveSpeed;
            playerMovement.jumpSpeed = originalJumpSpeed;
            playerMovement.dJumpSpeed = originaldJumpSpeed;
            playerMovement.dashingPower = originalDashPower;
            playerMelee.canAttack = true;
            playerMelee.canStun = true;
            anim.SetBool("isBlocking", false);
        }
    }
}
