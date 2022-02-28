using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    bool jumpTime;


    // Start is called before the first frame update
    void Start()
    {
        jumpTime = false;
    }

    // Update is called once per frame
    void Update()
    {
        var dx = Input.GetAxisRaw("Horizontal"); // x irányba történõ elmozdulás
        var jump = Input.GetAxisRaw("Jump");

        if(dx != 0)
        {
            transform.Translate(new Vector2(Time.deltaTime * 10 * dx, 0));
        }
        if (jump > 0 && !jumpTime)
        {
            var rb = GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(0, 10);
            jumpTime = true;

        }
        /*
        if(jumpTime > 0)
        {
            jumpTime = jumpTime - Time.deltaTime;
        }
        */

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "solid")
        {
            jumpTime = false;
        }
        


    }
}
