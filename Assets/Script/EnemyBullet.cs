using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��ǥ: ���� ���� ���ư���.
//������ �ʿ��ϴ�.
//�ӵ��� �ʿ��ϴ�/

//��ǥ2 : �Ѿ��� ���� �浹�ϸ� ��(�Ѿ�)�� ���� �ı��ȴ�.
public class EnemyBullet : MonoBehaviour
{
    public float speed = 4.0f;
    public Vector3 dir = Vector3.down;
    public GameObject bulletExplosion;

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + dir * speed * Time.deltaTime;
    }


    //others : �ٸ� object�� �ǹ���
    private void OnCollisionEnter(Collision others)
    {
        //�Ѿ��� ���� �浹�ϸ� - �̸���, Tag��, Layer��
        if (others.gameObject.tag == "Player")
        {
            GameObject player = GameObject.Find("Player");

            if (player != null)
            {
                player.GetComponent<PlayMove>().hp--;

                if (player.GetComponent<PlayMove>().hp < 0)
                {
                    // �ε��� ��븦 �ı��Ѵ�.
                    Destroy(others.gameObject);
                }

            }
        }
        // ���� �ı��Ѵ�.
        Destroy(gameObject);

        
    }
}
