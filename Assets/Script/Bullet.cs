using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//목표: 내가 위로 날아간다.
//방향이 필요하다.
//속도가 필요하다/

//목표2 : 총알이 적과 충돌하면 나(총알)와 적이 파괴된다.
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
        //총알이 적과 충돌하면 - 이름비교, Tag비교, Layer비교
        if(others.gameObject.tag == "Enemy")
        {
            //내(총알)가 파괴된다.
            Destroy(gameObject);

            //적이 파괴된다.
            Destroy(others.gameObject);
        }
    }
}
