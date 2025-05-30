using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Rendering.Universal;

public class Health : MonoBehaviour
{
    public SoundEffects audioManager;

    [SerializeField] public float health = 100;

    [SerializeField] public float MAX_HEALTH = 100;

    [SerializeField] public int defense = 1;

    //[SerializeField] public GameObject attackArea;

    [SerializeField] public bool pierceRes = false;
    [SerializeField] public bool slashRes = false;
    [SerializeField] public bool bluntRes = false;
    [SerializeField] public bool burnRes = false;

    //public bool isBurning = false;

    public int burnTicks = 0;
    //public float burnDelta = 0;
    public float burnDamage = 0;

    private float finalDamage;

    public Knockback knockback;

    public PlayerMovement playerMovement;



    public Animator anim;


    public bool isDead = false;

    /*
    // Update is called once per frame
    void Update()
    {

        burnDelta -= Time.deltaTime;

        if (burnTicks > 0 && burnDelta <= 0)
        {
            burnDelta = 1;
            burnTicks -= 1;
            Damage(burnDamage, AN: true);
        }
    }
    */

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<SoundEffects>();
    }

    public void Damage(float amount, Vector2 hitDirection, bool Pierce = false, bool Slash = false, bool Blunt = false, bool AN = false, bool Burn = false, int burnAmount = 0, float burnDamage = 0)
    {
        /*
        anim.SetTrigger("isHurt");
        */

        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot Have Negative Damage");
        }

        finalDamage = amount;

        if (slashRes && Slash)
        {
            finalDamage = amount / 2;
        }

        if (pierceRes && Pierce)
        {
            finalDamage = amount / 2;
        }

        if (bluntRes && Blunt)
        {
            finalDamage = amount / 2;
        }

        Debug.Log(finalDamage);

        if (AN == false)
        {
            if (finalDamage - defense > 0)
            {
                this.health -= finalDamage - defense;
            }
        }

        if (AN == true)
        {
            this.health -= finalDamage;
        }

        if (finalDamage - defense <= 0)
        {
            Debug.Log("Armor fully negated damage");
            audioManager.PlaySoundEffect(audioManager.blockSound);
        }
        else if (gameObject.name == "Hercules")
        {
            audioManager.PlaySoundEffect(audioManager.damageSound);
        }

        if (Burn && burnRes == false)
        {
            burnTicks += burnAmount;
            //burnDelta = 1;
            this.burnDamage = burnDamage;
        }

        //if (GetComponent<Hearts>() != null)
        //{
        //    Hearts hearts = GetComponent<Hearts>();
        //    hearts.Damage(1);
        //}

        if (health <= 0 && isDead == false)
        {
            Die();
        }

        if (knockback != null)
        {
            knockback.CallKnockback(hitDirection, Vector2.up, playerMovement.movementX);
        }
    }

    public void Burning(int burnAmount)
    {
        Debug.Log("I am on fire!");
        for (int i = 0; i < burnAmount; i++)
        {
            Damage(1, new Vector2 (0, 0), AN: true);
        }
    }

    public void Heal(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot Have Negative Healing");
        }

        bool wouldOverheal = health + amount > MAX_HEALTH;

        if (wouldOverheal)
        {
            this.health = MAX_HEALTH;
        }

        this.health += amount;
    }

    private void Die()
    {
        Debug.Log("I am Dead!");

        //anim.ResetTrigger("isHurt");
        anim.SetTrigger("isDead");

        isDead = true;
        //gameObject.tag = "Dead";

        if (GetComponent<BoxCollider2D>() != null)
        {
            GetComponent<BoxCollider2D>().enabled = false;
        }
        if (GetComponent<CapsuleCollider2D>() != null)
        {
            GetComponent<CapsuleCollider2D>().enabled = false;
        }
        if (GetComponent<EnemyAttacking>() != null)
        {
            GetComponent<EnemyAttacking>().enabled = false;
        }
        if (GetComponent<FlyingEnemyPatrol>() != null)
        {
            GetComponent<FlyingEnemyPatrol>().enabled = false;
        }
        if (GetComponent<FlyingEnemyPlayer>() != null)
        {
            GetComponent<FlyingEnemyPlayer>().enabled = false;
        }
        if (GetComponent<WalkingEnemyPatrol>() != null)
        {
            GetComponent<WalkingEnemyPatrol>().enabled = false;
        }
        if (GetComponent<EnemyChasePlayer>() != null)
        {
            GetComponent<EnemyChasePlayer>().enabled = false;
        }
        if (GetComponent<Boar>() != null)
        {
            GetComponent<Boar>().enabled = false;
        }
        if (GetComponent<MonsterMovement>() != null)
        {
            GetComponent<MonsterMovement>().enabled = false;
        }
        if (GetComponent<PlayerMovement>() != null)
        {
            GetComponent<PlayerMovement>().enabled = false;
        }
        if (GetComponent<PlayerMelee>() != null)
        {
            GetComponent<PlayerMelee>().enabled = false;
        }
        if (GetComponent<PlayerBlock>() != null)
        {
            GetComponent<PlayerBlock>().enabled = false;
        }

        //Destroy(gameObject);
    }
}
