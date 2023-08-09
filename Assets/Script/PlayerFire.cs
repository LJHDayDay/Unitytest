using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��ǥ : ����� �Է�(space)�� �޾� �Ѿ��� ����� �ʹ�.
//����1 : �Է��� �ް� �ʹ�.
//����2 : �Ѿ��� ����� �ʹ�.

//��ǥ2: �������� �Ծ��ٸ�, ��ų ������ �ö󰣴�.
//�Ӽ�: ��ų����
public class PlayerFire : MonoBehaviour
{
    public GameObject bullet;
    public GameObject gunPos;
    public int degrees;    
    public int skillLevel;

    // Update is called once per frame
    void Update()
    {
        //����1: �Է��� �ް� �ʹ�.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ExcuteSkill(skillLevel);
        }
    }

    private void ExcuteSkill(int _skillLevel)
    {
        switch(_skillLevel)
        {
            case 0:
                ExcuteSkill1();
                break;
            case 1:
                ExcuteSkill2();
                break;
            case 2:
                ExcuteSkill3();
                break;
            case 3:
                ExcuteSkill4();
                break;
            
        }

        //�� ���� �Ѿ��� �߻� �ȴ�.
        void ExcuteSkill1()
        {
            // ����2: �Ѿ��� ����� �ʹ�.
            GameObject bullets = Instantiate(bullet);

            // ����3: �Ѿ��� ��ġ�� �÷��̾��� ��ġ�� �����ְ� �ʹ�.
            bullets.transform.position = gunPos.transform.position;
        }

        //�ΰ��� �Ѿ��� �߻� �ȴ�.
        void ExcuteSkill2()
        {
            // ����2: �Ѿ��� ����� �ʹ�.
            GameObject bullets = Instantiate(bullet);
            GameObject bullets1 = Instantiate(bullet);

            // ����3: �Ѿ��� ��ġ�� �÷��̾��� ��ġ�� �����ְ� �ʹ�.
            bullets.transform.position = gunPos.transform.position + new Vector3(-1,0,0);
            bullets1.transform.position = gunPos.transform.position + new Vector3(-1, 0, 0);
        }

        //�� ���� �Ѿ��� �߻� �ȴ�.
        //1,2,3 �Ѿ� �� 1, 3 �Ѿ��� ���� Z������ -30��, 30�� ȸ���� �߻� �ȴ�.
        void ExcuteSkill3()
        {
            GameObject bullets = Instantiate(bullet);
            bullets.transform.position = gunPos.transform.position;

            // ����2: �Ѿ��� ����� �ʹ�.
            GameObject bullets2 = Instantiate(bullet);
            GameObject bullets3 = Instantiate(bullet);

            // ����3: �Ѿ��� ��ġ�� �÷��̾��� ��ġ�� �����ְ� �ʹ�. 
            bullets2.transform.position = gunPos.transform.position + new Vector3(-0.3f, 0, 0);
            bullets2.transform.rotation = Quaternion.Euler(0, 0, 15);
            bullets2.GetComponent<Bullet>().dir = bullets2.transform.up;

            bullets3.transform.position = gunPos.transform.position + new Vector3(0.3f, 0, 0);
            bullets3.transform.rotation = Quaternion.Euler(0, 0, -15);
            bullets3.GetComponent<Bullet>().dir = bullets3.transform.up;

            
        }

        void ExcuteSkill4()
        {

            for (int i = 0; i <= 24; i++) 
            {
                GameObject bullets4 = Instantiate(bullet);
                bullets4.transform.position = gunPos.transform.position;
                bullets4.transform.rotation = Quaternion.Euler(0, 0, i * degrees);
                bullets4.GetComponent<Bullet>().dir = bullets4.transform.up;
                //Quaterniton.Euler : 3���� ȸ���� ���� ����
            }
        }
    }

        
    

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Item")
        {
            if (skillLevel < 3)
            {
                skillLevel++;

                Destroy(other.gameObject);
            }

        }
        
    }
}
