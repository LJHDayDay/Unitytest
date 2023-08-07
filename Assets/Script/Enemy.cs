using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��ǥ1: �Ʒ��������� �̵��Ѵ�.
//��ǥ2: �ٸ� �浹ü�� �ε������� ��, ��븦 �ı��Ѵ�.
//��ǥ3: ���۽� 30%�� Ȯ���� �÷��̾ ���󰣴�.
//�ʿ�Ӽ�: 30%�� Ȯ��
//��ǥ4: 10%�� Ȯ���� �÷��̾ ���󰣴�.
public class Enemy : MonoBehaviour
{
    public float speed = 3.0f;
    public Vector3 dir = Vector3.down;


    GameObject player;
    int randValue;

    //�ʿ�Ӽ�: �÷��̾��� ����
    Vector3 playerDir;

    private void Start()
    {

        randValue = Random.Range(0, 10); // 0 ~ 9 ������ ���� ��
        player = GameObject.Find("Player");

        if (Random.Range(0, 10) < 3)
        {
            dir = (player.transform.position - gameObject.transform.position).normalized;
            //dir.Normalize();
            //
        }

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + dir * speed * Time.deltaTime;
        //transform.position += dir * speed * Time.deltaTime;


        if (randValue < 1)
        {

            dir = (player.transform.position - gameObject.transform.position).normalized;
            dir = playerDir;
            //dir.Normalize();
            //
        }
    }

    //�浹 ���� ����
    private void OnCollisionEnter(Collision otherObject)
    { 
        if(otherObject.gameObject.tag == "Enemy")
        {
            return;
        }
        //���� �ı��Ѵ�.
        Destroy(gameObject);

        //�ε��� ��븦 �ı��Ѵ�.
        Destroy(otherObject.gameObject);
    }

    //�浹 �� ����
    private void OnCollisionStay(Collision collision)
    {
        
    }

    //�浹 ����� ����
    private void OnCollisionExit(Collision collision)
    {
        
    }
}
