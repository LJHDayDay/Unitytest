using System.Collections;
using System.Collections.Generic;
using UnityEditor.Networking.PlayerConnection;
using UnityEngine;

//��ǥ: ���� ���� ���ư���.
//������ �ʿ��ϴ�.
//�ӵ��� �ʿ��ϴ�/

//��ǥ2 : �Ѿ��� ���� �浹�ϸ� ��(�Ѿ�)�� ���� �ı��ȴ�.
//��ǥ3: �浹�� ���� ȿ���� �����Ѵ�.
public class Bullet : MonoBehaviour
{
    public float speed = 10.0f;
    public Vector3 dir = Vector3.up;
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
        if(others.gameObject.tag == "Enemy")
        {
            GameObject player = GameObject.Find("Enemy");

            if(player != null)
            {

                player.GetComponent<Enemy>().hp--;

                if (player.GetComponent<Enemy>().hp < 0)
                {
                    //��(�Ѿ�)�� �ı��ȴ�.
                    Destroy(gameObject);

                    //���� �ı��ȴ�.
                    Destroy(others.gameObject);

                    //��ǥ3: �浹�� ���� ȿ���� �����Ѵ�.
                    GameObject bulletExplosionGo = Instantiate(bulletExplosion);
                    bulletExplosionGo.transform.position = transform.position;
                }
            }
            
        }
    }
}
