using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 목표: Background의 MAterial의 offset의 Y를 일정 속도로 변화시키고 싶다.
// 속성: 현재 시간, 속도
public class BackGroundRoller : MonoBehaviour
{
    // 속성: 현재 시간, 속도, 매터리얼
    float currentTime;
    public float speed = 1;
    public Material material;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += speed * Time.deltaTime;

        material.mainTextureOffset = Vector3.down * currentTime;
    }
}
