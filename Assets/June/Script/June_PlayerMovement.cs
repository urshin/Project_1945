using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class June_PlayerMovement : MonoBehaviour
{
    Animator ani; //�ִϸ����� ������ ����
    public float moveSpeed = 5;
    
    [SerializeField]
    



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
            transform.GetChild(0).gameObject.SetActive(true); //�ڽİ�ü 0�� �ҷ��ͼ� ���ֱ�


        }
        else
        {
            moveX = moveSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
            moveY = moveSpeed * Time.deltaTime * Input.GetAxis("Vertical");
            transform.GetChild(0).gameObject.SetActive(false);

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