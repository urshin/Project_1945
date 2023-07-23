using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    Animator ani; //애니메이터 가져올 변수
    public float moveSpeed = 5;
 


    void Start()
    {
        ani = GetComponent<Animator>();
    }


    private void FixedUpdate()
    {
        Movement();

    }


    void Movement()
    {
        float moveX = moveSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        float moveY = moveSpeed * Time.deltaTime * Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveX = (moveSpeed * Time.deltaTime * Input.GetAxis("Horizontal")) / 2;
            moveY = (moveSpeed * Time.deltaTime * Input.GetAxis("Vertical")) / 2;
        }
        else
        {
            moveX = moveSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
            moveY = moveSpeed * Time.deltaTime * Input.GetAxis("Vertical");
        }

        if (Input.GetAxis("Horizontal") >= 0.1f)
        {
            ani.SetBool("MoveRight", true);
        }
        else
        {
            ani.SetBool("MoveRight", false);
        }

        if (Input.GetAxis("Horizontal") <= -0.1f)
        {
            ani.SetBool("MoveLeft", true);
        }
        else
        {
            ani.SetBool("MoveLeft", false);
        }


      
        transform.Translate(moveX, moveY, 0);
    }



}