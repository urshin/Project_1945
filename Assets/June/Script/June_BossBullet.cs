using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class June_BossBullet : MonoBehaviour
{
    private float BossHP; //���� HP     
    private float BossOrginHP; //���� ����HP     

    public float Speed = 3; //���� ������ �ӵ�

    public float Delay = 2f; //�Ѿ� �ֱ�
    public Transform ms; //�Ѿ� ������ ��

    public GameObject Bullet1; //�׳� ������ �Ѿ�
    public GameObject Bullet2; //�÷��̾� Ÿ���� �Ѿ�

    float lastShootTime;

    public int patternNum; //���� ��ȣ


    void Start()
    {
        
        BossOrginHP = gameObject.GetComponent<June_Enemy>().Hp; //�������� Hp���� ==> ���� ��ȭ�� ���ؼ�
        Invoke("CreateBullte", Delay);

    }

    void CreateBullte()
    {
            Invoke("CreateBullte", Delay);
    }


    void  FixedUpdate()
    {
        attackPattern();
    }


    void attackPattern()
    {
        BossHP = gameObject.GetComponent<June_Enemy>().Hp;

        if (Time.time > lastShootTime + 2.0f)
        {
            lastShootTime = Time.time;
            patternNum = Random.Range(1, 4);  //���� ����
            if (BossHP <= BossOrginHP / 2) //50%ü�� ���ϸ� ������ ���� ����
            {
                StartCoroutine(attack(4));
                if(BossHP <= BossOrginHP / 5) 
                {
                    StartCoroutine (attack(5));
                }
            }
            else
                StartCoroutine(attack(patternNum));
        }
    }


    IEnumerator attack(int p)
    {
        if (p == 1)  //3���� ������ 5����
        {
            for (int i = 0; i < 5; i++)
            {
                Instantiate(Bullet1, ms.position, ms.transform.rotation);
                Instantiate(Bullet1, ms.position, Quaternion.Euler(0, 0, 35));
                Instantiate(Bullet1, ms.position, Quaternion.Euler(0, 0, -35));

                yield return new WaitForSeconds(0.2f);
            }
        }
        if (p == 2)  //3���� ������ 10��
        {
            for (int i = 0; i < 10; i++) 
            {
                Instantiate(Bullet2, ms.position, ms.transform.rotation);
                Instantiate(Bullet2, ms.position, Quaternion.Euler(0, 0, 35));
                Instantiate(Bullet2, ms.position, Quaternion.Euler(0, 0, -35));

                yield return new WaitForSeconds(0.2f);
            }
        }

        if (p == 3) //360�� ������ ����
        {

            for (int i = 0; i < 3; i++)
            {

                for (int j = 0; j < 360; j += 10)
                    Instantiate(Bullet1, ms.position, Quaternion.Euler(0, 0, j));

                yield return new WaitForSeconds(0.2f);
            }
        }

        if (p == 4) //360�� 1�� , 3���� 5�� ����
        {
            for (int j = 0; j < 360; j += 10)
            {
                yield return new WaitForSeconds(0.025f);
                Instantiate(Bullet1, ms.position, Quaternion.Euler(0, 0, j));

            }
            
            for (int j = 0; j < 360; j += 10)
            {
                yield return new WaitForSeconds(0.02f);
                Instantiate(Bullet1, ms.position, Quaternion.Euler(0, 0, j));

            }


        }
        if (p == 5) //360�� 5�� �÷��̾� �߰�
        {

            for (int i = 0; i < 5; i++)
            {

                for (int j = 0; j < 360; j += 10)
                    Instantiate(Bullet2, ms.position, Quaternion.Euler(0, 0, j));

                yield return new WaitForSeconds(0.2f);
            }
        }
    }

























}
