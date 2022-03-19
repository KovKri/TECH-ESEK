using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoting : MonoBehaviour
{
    public float shootspeed, shootTimer;
    private bool IsShooting;    
    public Transform shootpos;
    public GameObject bullet;
    void Start()
    {
        IsShooting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !IsShooting)
        {
            StartCoroutine(Shoot());
        }
    }
    IEnumerator Shoot()
    {
        int direction() 
        {
            if (transform.localScale.x < 0f)
            {
                return -1;
            }
            else
            {
                return +1;
            }
        }
        IsShooting = true;
        GameObject newBullet = Instantiate(bullet, shootpos.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(shootspeed * direction() * Time.fixedDeltaTime, 0f);
        //animácio helye....talán vidi azt mondta....... ne engem hibáztass ha nem jó......pls...... :(
        yield return new WaitForSeconds(shootTimer);
        IsShooting = false;

    }
}
