using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��ǥ1: �Ʒ��������� �̵��Ѵ�.
//��ǥ2: �ٸ� �浹ü�� �ε������� ��, ��븦 �ı��Ѵ�.
//��ǥ3: ���۽� 30%�� Ȯ���� �÷��̾ ���󰣴�.
//�ʿ�Ӽ�: 30%�� Ȯ��
//��ǥ4: 10%�� Ȯ���� �÷��̾ ���󰣴�.

//��ǥ5: ���� �÷��̾ ���� Ư�� �ð��� �ѹ��� ���� ���.
//�ʿ�Ӽ�: �Ѿ�, Ư�� �ð�

//��ǥ6: �浹�� ���� ȿ���� �����Ѵ�.
//�ʿ�Ӽ� :

//��ǥ7: �浹�� hp�� �����ϰ� 0�� �� ��� �����Ѵ�.
public class Enemy : MonoBehaviour
{
    public float speed = 3.0f;
    public Vector3 dir = Vector3.down;
    public GameObject explosion;

    public int hp = 3;

    GameObject player;
    int randValue;

    //�ʿ�Ӽ�: �÷��̾��� ����
    Vector3 playerDir;

    private void Start()
    {

        randValue = Random.Range(0, 10); // 0 ~ 9 ������ ���� ��
        player = GameObject.Find("Player");

        if (randValue < 3)
        {
            dir = (player.transform.position - gameObject.transform.position).normalized;
            //dir.Normalize();
        }

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + dir * speed * Time.deltaTime;
        //transform.position += dir * speed * Time.deltaTime;


        if (randValue < 1)
        {
            if(player != null)
            {
                dir = (player.transform.position - gameObject.transform.position).normalized;
                dir = playerDir;
                //dir.Normalize();
            }

        }
    }

    //�浹 ���� ����
    private void OnCollisionEnter(Collision otherObject)
    {
        hp--;

        if (otherObject.gameObject.tag == "Player")
        {
            player.GetComponent<PlayMove>().hp--;

            if (player.GetComponent<PlayMove>().hp < 0)
            {
                Destroy(gameObject);
            }

            // ���� �ı��Ѵ�.
            Destroy(gameObject);

            // ��ǥ6: �浹�� ���� ȿ���� �����Ѵ�.
            GameObject explosionGO = Instantiate(explosion);
            explosionGO.transform.position = gameObject.transform.position;
        }
        else if(hp < 0)
        {
            //��ǥ6: �浹�� ���� ȿ���� �����Ѵ�.
            GameObject explosionGo = Instantiate(explosion);
            explosionGo.transform.position = transform.position;

            // ���� �ı��Ѵ�.
            Destroy(gameObject);

            // �ε��� ��븦 �ı��Ѵ�.
            Destroy(otherObject.gameObject);
        }

        

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
