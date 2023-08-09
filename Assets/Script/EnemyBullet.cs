using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//목표: 내가 위로 날아간다.
//방향이 필요하다.
//속도가 필요하다/

//목표2 : 총알이 적과 충돌하면 나(총알)와 적이 파괴된다.
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


    //others : 다른 object를 의미함
    private void OnCollisionEnter(Collision others)
    {
        //총알이 적과 충돌하면 - 이름비교, Tag비교, Layer비교
        if (others.gameObject.tag == "Player")
        {
            GameObject player = GameObject.Find("Player");

            if (player != null)
            {
                player.GetComponent<PlayMove>().hp--;

                if (player.GetComponent<PlayMove>().hp < 0)
                {
                    // 부딪힌 상대를 파괴한다.
                    Destroy(others.gameObject);
                }

            }
        }
        // 나를 파괴한다.
        Destroy(gameObject);

        
    }
}
