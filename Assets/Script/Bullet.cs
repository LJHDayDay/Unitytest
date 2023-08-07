using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��ǥ: ���� ���� ���ư���.
//������ �ʿ��ϴ�.
//�ӵ��� �ʿ��ϴ�/

//��ǥ2 : �Ѿ��� ���� �浹�ϸ� ��(�Ѿ�)�� ���� �ı��ȴ�.
public class Bullet : MonoBehaviour
{
    public float speed = 10.0f;
    public Vector3 dir = Vector3.up;

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + dir * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision others)
    {
        //�Ѿ��� ���� �浹�ϸ� - �̸���, Tag��, Layer��
        if(others.gameObject.tag == "Enemy")
        {
            //��(�Ѿ�)�� �ı��ȴ�.
            Destroy(gameObject);

            //���� �ı��ȴ�.
            Destroy(others.gameObject);
        }
    }
}
