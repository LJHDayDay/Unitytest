using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//목표1: 아래방향으로 이동한다.
//목표2: 다른 충돌체와 부딪혔으면 나, 상대를 파괴한다.
//목표3: 시작시 30%의 확률로 플레이어를 따라간다.
//필요속성: 30%의 확률
//목표4: 10%의 확률로 플레이어를 따라간다.
public class Enemy : MonoBehaviour
{
    public float speed = 3.0f;
    public Vector3 dir = Vector3.down;


    GameObject player;
    int randValue;

    //필요속성: 플레이어의 방향
    Vector3 playerDir;

    private void Start()
    {

        randValue = Random.Range(0, 10); // 0 ~ 9 사이의 임의 값
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

    //충돌 순간 실행
    private void OnCollisionEnter(Collision otherObject)
    { 
        if(otherObject.gameObject.tag == "Enemy")
        {
            return;
        }
        //나를 파괴한다.
        Destroy(gameObject);

        //부딪힌 상대를 파괴한다.
        Destroy(otherObject.gameObject);
    }

    //충돌 중 실행
    private void OnCollisionStay(Collision collision)
    {
        
    }

    //충돌 종료시 실행
    private void OnCollisionExit(Collision collision)
    {
        
    }
}
