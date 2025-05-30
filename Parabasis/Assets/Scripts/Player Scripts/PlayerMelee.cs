using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMelee : MonoBehaviour
{
    public GameObject attackArea;
    public GameObject stunArea;
    public float attackTime = 0.2f;
    public float stunTime = 0.2f;
    public float stunCooldown = 2f;
    public bool isAttacking = false;
    public bool canAttack = true;
    public bool canStun = true;
    public bool stunUnlocked = false;
    public bool stunReady = true;
    public SoundEffects audioManager;
    public Animator anim;

    void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<SoundEffects>();
    }

    public void Melee(InputAction.CallbackContext context)
    {
        if (!isAttacking && canAttack)
        {
            StartCoroutine(Melee());
            audioManager.PlaySoundEffect(audioManager.attackSound);
        }
    }

    public void Stun(InputAction.CallbackContext context)
    {
        if (!isAttacking && canStun && stunUnlocked && stunReady)
        {
            stunReady = false;
            StartCoroutine (Stun());
            StartCoroutine (StunCooldown());
            audioManager.PlaySoundEffect(audioManager.stunSound);
        }
    }

    private IEnumerator Melee()
    {
        isAttacking = true;
        anim.SetTrigger("isAttacking");
        attackArea.SetActive(true);
        yield return new WaitForSeconds(attackTime);
        attackArea.SetActive(false);
        isAttacking = false;
    }

    private IEnumerator Stun()
    {
        isAttacking = true;
        anim.SetTrigger("isStunning");
        stunArea.SetActive(true);
        yield return new WaitForSeconds(stunTime);
        stunArea.SetActive(false);
        isAttacking = false;
    }

    private IEnumerator StunCooldown()
    {
        yield return new WaitForSeconds(stunCooldown);
        stunReady = true;
    }
}
