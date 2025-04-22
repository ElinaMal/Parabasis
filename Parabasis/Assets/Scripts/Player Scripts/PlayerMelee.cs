using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMelee : MonoBehaviour
{
    public GameObject attackArea;
    public GameObject stunArea;
    public float attackTime = 0.2f;
    public float stunTime = 0.1f;
    public bool isAttacking = false;
    public bool canAttack = true;
    public bool canStun = true;
    public bool stunUnlocked = false;

    public void Melee(InputAction.CallbackContext context)
    {
        if (!isAttacking && canAttack)
        {
            StartCoroutine(Melee());
        }
    }

    public void Stun(InputAction.CallbackContext context)
    {
        if (!isAttacking && canStun && stunUnlocked)
        {
            StartCoroutine (Stun());
        }
    }

    private IEnumerator Melee()
    {
        isAttacking = true;
        attackArea.SetActive(true);
        yield return new WaitForSeconds(attackTime);
        attackArea.SetActive(false);
        isAttacking = false;
    }

    private IEnumerator Stun()
    {
        isAttacking = true;
        stunArea.SetActive(true);
        yield return new WaitForSeconds(stunTime);
        stunArea.SetActive(false);
        isAttacking = false;
    }
}
