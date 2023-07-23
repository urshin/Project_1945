using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEditorInternal;
using UnityEngine;

public class June_PlayerSawn : MonoBehaviour
{
    public GameObject Player ;
    private bool CarryPlayer = true; //�÷��̾ �ʿ� ���� �� false

    void Start()
    {
        Instantiate(Player, new Vector3(0,-6,0), Quaternion.identity); //�÷��̾� ����

        //�÷��̾� �浹, ���� ����
        GameObject.FindGameObjectWithTag("Player").GetComponent<CircleCollider2D>().enabled = false;  
        GameObject.FindGameObjectWithTag("Player").GetComponent<June_PlayerMovement>().enabled = false;
       

        StartCoroutine("playerspawn"); //�÷��̾� �� ������ �鿩����
        Invoke("Stop", 1); 
        
    }
    void Stop()
    {
        CarryPlayer = false; //�ڷ�ƾ�� while�� ���߱�
        //�÷��̾� ����, �浹 Ȱ��
        GameObject.FindGameObjectWithTag("Player").GetComponent<CircleCollider2D>().enabled = true;
        GameObject.FindGameObjectWithTag("Player").GetComponent<June_PlayerMovement>().enabled = true;
        StopCoroutine("playerspawn");

    }
    void Update()
    {
      
    }

    IEnumerator playerspawn()
    {

        
        while (CarryPlayer)
        {
            //1�ʸ���
            yield return new WaitForSeconds(0.01f); //����
            GameObject.FindGameObjectWithTag("Player").transform.Translate(0, 3 * Time.deltaTime, 0); //�÷��̾� ���� ��ġ�κ��� ������ ���� ����.

        }
        yield return new WaitForSeconds(0.5f);
    }


}
