using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    [Header("Attack parameters")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private int damage;

    [Header("Collider parameters")]
    [SerializeField] private float colliderDistance; 
    [SerializeField] private BoxCollider2D boxCollider;

    [Header("Player Layer")]
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;

    private health playerHealth;
    private Animator anim;

    private EnemyPatrol enemyPatrol;

    [SerializeField] private int health;
    /*
    public float startHealth;
    private float hp;

    void Start()
    {
        hp = startHealth;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        GameObject colGO = col.gameObject;
        if (colGO.name == "bullet")
        {
            Debug.Log("levon e");
            hp--;
        }
    }
    */

    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemyPatrol = GetComponentInParent<EnemyPatrol>();
    }


    private void Update()
    {
        cooldownTimer += Time.deltaTime;

       
        //Attack only whe playe in sight
        if (PlayerInSight())
        {
            //Debug.Log("bejut ide");
            if (cooldownTimer >= attackCooldown)
            {
                //Attack
                cooldownTimer = 0;
                //Debug.Log("utes");
                anim.SetTrigger("meleeAttack");
            }
        }

        if (enemyPatrol != null)
            enemyPatrol.enabled = !PlayerInSight();

        /*if(hp==0)
        {
            Destroy(gameObject);
        }*/
    }

    private bool PlayerInSight()
    {
        //Debug.Log("erzekeli h benne van");
        RaycastHit2D hit =
            Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
             0, Vector2.left, 0, playerLayer);

        if (hit.collider != null)
            playerHealth = hit.transform.GetComponent<health>();

        return hit.collider != null;
        //return true;
    }
    
    private void OnDrawGizmos()
    {
        //Debug.Log("piros hitbox");
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    private void DamagePlayer()
    {
        if(PlayerInSight())
        {
            //damage player health
            playerHealth.TakeDamage(damage);
        }
    }

    public void TakeDamage(int mennyivel)
    {
        health -= mennyivel;
        if(health <= 0)
        {
            anim.SetTrigger("die");

            GetComponentInParent<EnemyPatrol>().enabled = false;

            GetComponent<MeleeEnemy>().enabled = false;

            FindObjectOfType<AudioManager>().Play("halal hang");

            this.gameObject.GetComponent<AudioSource>().mute = true;

            //Destroy(gameObject);
        }
    }

}
