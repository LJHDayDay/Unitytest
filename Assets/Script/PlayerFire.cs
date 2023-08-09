using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//목표 : 사용자 입력(space)를 받아 총알을 만들고 싶다.
//순서1 : 입력을 받고 싶다.
//순서2 : 총알을 만들고 싶다.

//목표2: 아이템을 먹었다면, 스킬 레벨이 올라간다.
//속성: 스킬레벨
public class PlayerFire : MonoBehaviour
{
    public GameObject bullet;
    public GameObject gunPos;
    public int degrees;    
    public int skillLevel;

    // Update is called once per frame
    void Update()
    {
        //순서1: 입력을 받고 싶다.
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

        //한 개의 총알이 발사 된다.
        void ExcuteSkill1()
        {
            // 순서2: 총알을 만들고 싶다.
            GameObject bullets = Instantiate(bullet);

            // 순서3: 총알의 위치를 플레이어의 위치로 정해주고 싶다.
            bullets.transform.position = gunPos.transform.position;
        }

        //두개의 총알이 발사 된다.
        void ExcuteSkill2()
        {
            // 순서2: 총알을 만들고 싶다.
            GameObject bullets = Instantiate(bullet);
            GameObject bullets1 = Instantiate(bullet);

            // 순서3: 총알의 위치를 플레이어의 위치로 정해주고 싶다.
            bullets.transform.position = gunPos.transform.position + new Vector3(-1,0,0);
            bullets1.transform.position = gunPos.transform.position + new Vector3(-1, 0, 0);
        }

        //세 개의 총알이 발사 된다.
        //1,2,3 총알 중 1, 3 총알이 각각 Z축으로 -30도, 30도 회전후 발사 된다.
        void ExcuteSkill3()
        {
            GameObject bullets = Instantiate(bullet);
            bullets.transform.position = gunPos.transform.position;

            // 순서2: 총알을 만들고 싶다.
            GameObject bullets2 = Instantiate(bullet);
            GameObject bullets3 = Instantiate(bullet);

            // 순서3: 총알의 위치를 플레이어의 위치로 정해주고 싶다. 
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
                //Quaterniton.Euler : 3차원 회전을 위한 도구
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
