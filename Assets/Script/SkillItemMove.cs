using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��ǥ: ��ų�������� �Ʒ� �������� Ư���ӵ��� �̵��Ѵ�.
//�Ӽ�: �Ʒ� ����, Ư���ӵ�, ����ð�
//����
public class SkillItemMove : MonoBehaviour
{
    //�Ӽ�: �Ʒ� ����, Ư���ӵ�, ����ð�
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
        //��ǥ: ��ų�������� �Ʒ��������� Ư�� �ӵ��� �̵��Ѵ�.
        transform.position += dir * speed * Time.deltaTime;
    }
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
