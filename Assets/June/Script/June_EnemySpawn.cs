using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class June_EnemySpawn : MonoBehaviour
{
   

    public float Xleft = -2.5f; //�� ���� ��
    public float XRight = 2.5f; //�� ���� ��

    //�� 1
    public float StartTime1; //����
    public float SpawnStop1; //���� ������ �ð�

    //��2
    public float StartTime2; //����
    public float SpawnStop2; //���� ������ �ð�

    //����Ʈ ��
    public float StartTime3; //����
    public float SpawnStop3; //���� ������ �ð�

    //����
    public float BossStart; //����
    public float BossStop; //���� ������ �ð�


    public GameObject Enemy1;
    public GameObject Enemy2;
    public GameObject EnemyMiddle;
    public GameObject Boss;


    bool swi1 = true;
    bool swi2 = true;
    bool swi3 = true;


    void Start()
    {
        StartCoroutine("RandomSpawn1");   //���� ���� �ڷ�ƾ
        StartCoroutine("RandomSpawn2");   //���� ���� �ڷ�ƾ
        StartCoroutine("RandomSpawn3");   //���� ���� �ڷ�ƾ
        
        Invoke("Stop1", SpawnStop1);// 
        Invoke("Stop2", SpawnStop2);// 
        Invoke("Stop3", SpawnStop3);// 

        Invoke("Boss1Spawn", BossStart);
    }



    void Stop1()
    {
        swi1 = false; //�ڷ�ƾ�� while�� ���߱�
        StopCoroutine("RandomSpawn");

    }
    void Stop2()
    {
        swi2 = false; // �ڷ�ƾ�� while�� ���߱�
        StopCoroutine("RandomSpawn2");
        
    }
    void Stop3()
    {
        swi3 = false; // �ڷ�ƾ�� while�� ���߱�
        StopCoroutine("RandomSpawn3");

    }
    Vector3 B = new Vector3(0, 1.5f, 0);

    //�� 1
    IEnumerator RandomSpawn1()
    {
        yield return new WaitForSeconds(StartTime1);
        while (swi1)
        {
            //1�ʸ���
            yield return new WaitForSeconds(1);
            //x�� ����
            float X = Random.Range(Xleft, XRight);
            //x�� ������ y�� �ڱ��ڽŰ�
            Vector3 r = new Vector3(X, transform.position.y, 0);
            //���� ����
            Instantiate(Enemy1, r, Quaternion.identity);
        }
    }

    //��2
    IEnumerator RandomSpawn2()
    {
        yield return new WaitForSeconds(StartTime2);
        while (swi2) 
        {
            //1�ʸ���
            yield return new WaitForSeconds(2);

            //x�� ����
            float X = Random.Range(Xleft, XRight);
            //x�� ������ y�� �ڱ��ڽŰ�
            Vector3 r = new Vector3(X, transform.position.y, 0);
            //���� ����
            Instantiate(Enemy2, r, Quaternion.identity);
        }
    }

    //����Ʈ ��
    IEnumerator RandomSpawn3()
    {
        yield return new WaitForSeconds(StartTime3);
        while (swi3) 
        {
            //1�ʸ���
            yield return new WaitForSeconds(2);

            //x�� ����
            float X = Random.Range(Xleft, XRight);
            //x�� ������ y�� �ڱ��ڽŰ�
            Vector3 r = new Vector3(X, transform.position.y, 0);
            //���� ����
            Instantiate(EnemyMiddle, r, Quaternion.identity);
        }
    }
    public void Boss1Spawn()
    {
       // Instantiate(Boss, B, Quaternion.identity);

    }












}
