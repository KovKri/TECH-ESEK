using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletDie : MonoBehaviour
{
    public float dieTime, damage;

    public GameObject diePEffect;
    void Start()
    {
        StartCoroutine(Timer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collisonGameObject = collision.gameObject;

        if(collisonGameObject.name != "Player")
        {
            if(collisonGameObject.GetComponent<Enemyhit>() != null)
            {
                collisonGameObject.GetComponent<Enemyhit>().TakeDamag(damage);
            }
            Die();
        }

        
    }




    IEnumerator Timer()
    {
        yield return new WaitForSeconds(dieTime);
        Die();

    }
    void Die()
    {
        if(diePEffect != null)
        {
            Instantiate(diePEffect, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int asd = 1;
        Debug.Log("bejut");
        if (collision.tag == "Enemy")
            collision.GetComponent<MeleeEnemy>().TakeDamage(asd);
    }

}
