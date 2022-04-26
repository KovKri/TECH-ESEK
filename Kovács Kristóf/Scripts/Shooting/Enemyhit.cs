using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyhit : MonoBehaviour
{
    [SerializeField] private float movementDistance;
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    private bool movingLeft;
    private float leftEdge;
    private float rightEdge;

    public float startHealth, chanceToSpawnFood;
    private float hp;

    public GameObject diePEffect, ammoDrop;
    void Start()
    {
        hp = startHealth;
    }
    private void Awake()
    {

        leftEdge = transform.position.x - movementDistance;
        rightEdge = transform.position.x + movementDistance;
    }

    void Update()
    {
        if (movingLeft)
        {
            if (transform.position.x > leftEdge)
            {
                transform.localEulerAngles = new Vector3(0, 0, 0);
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
            {
                movingLeft = false;
            }
        }
        else
        {
            if (transform.position.x < rightEdge)
            {
                transform.localEulerAngles = new Vector3(0, 180, 0);
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
            {
                movingLeft = true;
            }
        }
    }

    public void TakeDamag(float damage)
    {
        hp -= damage;

        if (hp <= 0f)
        {
            Die();
        }
    }
    void Die()
    {
        if (diePEffect != null)
        {
            Instantiate(diePEffect, transform.position, Quaternion.identity);
        }
        float spawnRate = Random.Range(0, 100f);
        if (spawnRate <= chanceToSpawnFood)
        {
            Instantiate(ammoDrop, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("sebez");
            collision.GetComponent<health>().TakeDamage(damage);
        }
    }
}
