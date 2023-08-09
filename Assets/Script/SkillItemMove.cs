using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//목표: 스킬아이템이 아래 방향으로 특정속도로 이동한다.
//속성: 아래 방향, 특정속도, 현재시간
//순서
public class SkillItemMove : MonoBehaviour
{
    //속성: 아래 방향, 특정속도, 현재시간
    Vector3 dir = Vector3.down;
    public float speed = 5;
    float currentTime;

    public GameObject itemEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //목표: 스킬아이템이 아래방향으로 특정 속도로 이동한다.
        transform.position += dir * speed * Time.deltaTime;
    }
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
