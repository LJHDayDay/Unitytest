using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��ǥ : ����� �Է�(space)�� �޾� �Ѿ��� ����� �ʹ�.
//����1 : �Է��� �ް� �ʹ�.
//����2 : �Ѿ��� ����� �ʹ�.
public class PlayerFire : MonoBehaviour
{
    public GameObject bullet;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullets = Instantiate(bullet);
            bullets.transform.position = transform.position;
        }
    }
}
