using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��ǥ: ��ų�������� Ư���ð� ���� �����.
//�ʿ�Ӽ�: ��ų������, Ư���ð�, ����ð�
//�ܰ�1: �ð��� �帥��.
//�ܰ�2: ���� �ð��� Ư���ð��� ������
//�ܰ�3: ��ų�������� �����Ѵ�.

public class SkillManager : MonoBehaviour
{
    //�ʿ�Ӽ�: ��ų������, Ư���ð�, ����ð�
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

    // ��ǥ2: ��ų�� ���� �� 
    private void OnDestroy()
    {
        // ������ ����Ʈ�� �����Ѵ�.
        GameObject itemEffGO = Instantiate(itemEffect);
        itemEffGO.transform.position = transform.position;

        // ��ǥ3. ���߽� ���� ����Ʈ�� �����Ѵ�.
        // ����1. ���� �Ŵ����� �ҷ��´�.
        GameObject soundManager = GameObject.Find("SoundManager");

        AudioSource audioSource = soundManager.GetComponent<SoundManager>().effAudioSource;
        // ����2. ���� �Ŵ������� ����� �ҽ��� ����� Ŭ���� �������ش�.
        audioSource.clip = soundManager.GetComponent<SoundManager>().itemAudioClips[0];

        // ����3. ���� �Ŵ����� ����� �ҽ��� �����Ų��.
        audioSource.Play();


    }
}
