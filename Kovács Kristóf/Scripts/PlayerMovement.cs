using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlyerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    

    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove)); //ANimator-ba létrehozott Speed jon ide //Mivel a Speed mindig pozitiv lehet abszolut ertekbe kell tenni

      
            

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }
    }

    public void OnLanding() //ha foldet er az ugras aimacio megszunjon
    {
        animator.SetBool("IsJumping", false);
    }

    void FixedUpdate()
    {
        //Karakter mozgatas
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
