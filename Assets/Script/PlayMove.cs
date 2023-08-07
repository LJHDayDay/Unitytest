using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMove : MonoBehaviour
{

    public float clampX;
    public float clampY;
    public Camera mainCamera;
    public float speed = 5;
    Vector3 playerPos = new Vector3(0,0,0);
    Vector3 enemyPos = new Vector3(5,5,0);
    

    // Start is called before the first frame update
    void Start()
    {
        Vector3 direction = enemyPos - playerPos;
        float distance = direction.magnitude;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 clampPos = mainCamera.ViewportToWorldPoint(Vector3.one);

        clampX = Mathf.Abs(clampPos.x - 0.5f);
        clampY = Mathf.Abs(clampPos.y - 0.5f);
        //카메라 범위 인식

        float h = Input.GetAxis("Horizontal"); //수평
        float v = Input.GetAxis("Vertical"); //수직

        Vector3 dir = Vector3.right * h + Vector3.up * v;
        //transform.Translate(dir * speed * Time.deltaTime);
        transform.position = transform.position + dir * speed * Time.deltaTime;
        //기본적인 계산 형태

        if(Mathf.Abs(transform.position.x) > clampX)
        {
            int minus = transform.position.x > 0f ? 1 : -1;
            //? : 앞의 값이 참이면은 A:B였을때 A을 실행하겠다. 거짓이면 B를 실행하겠다.

            transform.position = new Vector3(clampX * minus, transform.position.y, transform.position.z);

        }
        if (Mathf.Abs(transform.position.y) > clampY)
        {
            int minus = transform.position.y > 0f ? 1 : -1;
            //? : 앞의 값이 참이면은 A:B였을때 A을 실행하겠다. 거짓이면 B를 실행하겠다.

            transform.position = new Vector3(transform.position.x, clampY * minus , transform.position.z);

        }
        //실질적 영역 제한
    }
}
