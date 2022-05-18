using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rengedenemy : MonoBehaviour
{
    [Header("Attack parameters")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private int damage;

    [Header("Ranged Attacks")]
    [SerializeField] private Transform firepoint;
    [SerializeField] private GameObject[] arrows;


    [Header("Collider parameters")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;

    [Header("Player Layer")]
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;

    private EnemyPatrol enemyPatrol;

    private void Awake()
    {
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
            }
        }

        if (enemyPatrol != null)
            enemyPatrol.enabled = !PlayerInSight();

        /*if(hp==0)
        {
            Destroy(gameObject);
        }*/
    }
    private void RangedAttack()
    {
        cooldownTimer = 0;
        arrows[FindArrow()].transform.position = firepoint.position;
        arrows[FindArrow()].GetComponent<EnemyProjectile>().ActivateProjectile();
    }
    private int FindArrow()
    {
        for (int i = 0; i < arrows.Length; i++)
        {
            if (!arrows[i].activeInHierarchy)
            {
                return i;
            }
        }
        return 0;
    }

    private bool PlayerInSight()
    {
        //Debug.Log("erzekeli h benne van");
        RaycastHit2D hit =
            Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
             0, Vector2.left, 0, playerLayer);


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
}
