using UnityEngine;
using System.Collections;

public class Stunning : MonoBehaviour
{
    [SerializeField] private float stunTime;
    private bool wait;

    private void Awake()
    {
        wait = false;
    }

    private void Update()
    {
        if (wait)
        {
            if (gameObject.GetComponent<NPCRangedAttack>() != null)
            {
                NPCRangedAttack rangedAttack = gameObject.GetComponent<NPCRangedAttack>();
                rangedAttack.enabled = false;
            }
            if (gameObject.GetComponent<EnemyAttacking>() != null)
            {
                EnemyAttacking enemyAttacking = gameObject.GetComponent<EnemyAttacking>();
                enemyAttacking.enabled = false;
            }
            if (gameObject.GetComponent<FlyingEnemyPatrol>() != null)
            {
                FlyingEnemyPatrol flyingEnemyPatrol = gameObject.GetComponent<FlyingEnemyPatrol>();
                flyingEnemyPatrol.enabled = false;
            }
            if (gameObject.GetComponent<FlyingEnemyPlayer>() != null)
            {
                FlyingEnemyPlayer flyingEnemyPlayer = gameObject.GetComponent<FlyingEnemyPlayer>();
                flyingEnemyPlayer.enabled = false;
            }
            if (gameObject.GetComponent<EnemyChasePlayer>() != null)
            {
                EnemyChasePlayer enemyChasePlayer = gameObject.GetComponent<EnemyChasePlayer>();
                enemyChasePlayer.enabled = false;
            }
            if (gameObject.GetComponent<WalkingEnemyPatrol>() != null)
            {
                WalkingEnemyPatrol walkingEnemyPatrol = gameObject.GetComponent<WalkingEnemyPatrol>();
                walkingEnemyPatrol.enabled = false;
            }
        }
        else
        {
            if (gameObject.GetComponent<NPCRangedAttack>() != null)
            {
                NPCRangedAttack rangedAttack = gameObject.GetComponent<NPCRangedAttack>();
                rangedAttack.enabled = true;
            }
            if (gameObject.GetComponent<EnemyAttacking>() != null)
            {
                EnemyAttacking enemyAttacking = gameObject.GetComponent<EnemyAttacking>();
                enemyAttacking.enabled = true;
            }
            if (gameObject.GetComponent<FlyingEnemyPatrol>() != null)
            {
                FlyingEnemyPatrol flyingEnemyPatrol = gameObject.GetComponent<FlyingEnemyPatrol>();
                flyingEnemyPatrol.enabled = true;
            }
            if (gameObject.GetComponent<FlyingEnemyPlayer>() != null)
            {
                FlyingEnemyPlayer flyingEnemyPlayer = gameObject.GetComponent<FlyingEnemyPlayer>();
                flyingEnemyPlayer.enabled = true;
            }
            if (gameObject.GetComponent<EnemyChasePlayer>() != null)
            {
                EnemyChasePlayer enemyChasePlayer = gameObject.GetComponent<EnemyChasePlayer>();
                enemyChasePlayer.enabled = true;
            }
            if (gameObject.GetComponent<WalkingEnemyPatrol>() != null)
            {
                WalkingEnemyPatrol walkingEnemyPatrol = gameObject.GetComponent<WalkingEnemyPatrol>();
                walkingEnemyPatrol.enabled = true;
            }
        }
    }

    public void Stunned()
    {
        StartCoroutine(Coroutine());
    }

    IEnumerator Coroutine()
    {
        wait = true;

        yield return new WaitForSeconds(stunTime);

        wait = false;
    }
}
