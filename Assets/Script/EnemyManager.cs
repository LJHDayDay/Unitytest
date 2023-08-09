using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 목표: 적을 생성한다.
// 필요 속성 : 특정 시간, 현재시간, 적 GameObject
//순서1. 현재 시간이 흐른다.
//순서2. 현재 시간이 특정 시간이 되면 
//순서3. 적을 생성해서 EnemyManager위치에 생성한다.
//순서4. 시간을 초기화 해준다.


//추가. 특정시간을 랜덤한 시간으로 설정한다.
public class EnemyManager : MonoBehaviour
{


    //필요속성: 특정 시간, 현재시간, 적 GameObhect
    //특정시간
    float createTime;

    //현재시간
    float currentTime;

    //적 게임오브젝트
    public GameObject enemy;

    //랜덤한 시간의 최소 최댓값
    public float minTime = 0;
    public float maxTime = 10;

    private void Start()
    {
        createTime = Random.Range(minTime, maxTime);
    }

    // Update is called once per frame
    void Update()
    {
        //순서1. 현재 시간이 흐른다.
        currentTime = currentTime + Time.deltaTime;

        //순서2. 현재 시간이 특정 시간이 지나면
        if(currentTime > createTime)
        {
            //순서3. 적을 생성해서 EnemyManager위치에 생성한다.
            GameObject enemyGo = Instantiate(enemy);
            enemyGo.transform.position = transform.position;

            //순서4. 시간을 초기화 해준다.
            currentTime = 0;
        }
    }
}
