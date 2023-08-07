using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//목표 : 사용자 입력(space)를 받아 총알을 만들고 싶다.
//순서1 : 입력을 받고 싶다.
//순서2 : 총알을 만들고 싶다.
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
