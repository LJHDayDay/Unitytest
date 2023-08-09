using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//목표: 스킬아이템을 특정시간 마다 만든다.
//필요속성: 스킬아이템, 특정시간, 현재시간
//단계1: 시간이 흐른다.
//단계2: 현재 시간이 특정시간을 넘으면
//단계3: 스킬아이템을 생성한다.

public class SkillManager : MonoBehaviour
{
    //필요속성: 스킬아이템, 특정시간, 현재시간
    public GameObject skillItem;
    public float createTime;
    public float minCreateTime;
    public float maxCreateTime;
    float currentTime;
    public GameObject itemEffect;

    private void Start()
    {
        createTime = Random.Range(minCreateTime, maxCreateTime);
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime > createTime)
        {
            GameObject skillItemGo = Instantiate(skillItem);

            skillItemGo.transform.position = transform.position;

            currentTime = 0;

            createTime = Random.Range(minCreateTime, maxCreateTime);
        }
    }

    // 목표2: 스킬이 죽을 때 
    private void OnDestroy()
    {
        // 아이템 이펙트를 생성한다.
        GameObject itemEffGO = Instantiate(itemEffect);
        itemEffGO.transform.position = transform.position;

        // 목표3. 폭발시 사운드 이펙트를 생성한다.
        // 순서1. 사운드 매니저를 불러온다.
        GameObject soundManager = GameObject.Find("SoundManager");

        AudioSource audioSource = soundManager.GetComponent<SoundManager>().effAudioSource;
        // 순서2. 사운드 매니저에서 오디오 소스의 오디오 클립을 변경해준다.
        audioSource.clip = soundManager.GetComponent<SoundManager>().itemAudioClips[0];

        // 순서3. 사운드 매니저의 오디오 소스를 재생시킨다.
        audioSource.Play();


    }
}
