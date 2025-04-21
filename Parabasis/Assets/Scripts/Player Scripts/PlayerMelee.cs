using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMelee : MonoBehaviour
{
    public GameObject attackArea;
    public float attackTime = 0.2f;
    public bool isAttacking = false;
    public bool canAttack = true;

    public void Melee(InputAction.CallbackContext context)
    {
        if (!isAttacking && canAttack)
        {
            StartCoroutine(Melee());
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
}
