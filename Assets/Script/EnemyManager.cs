using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ��ǥ: ���� �����Ѵ�.
// �ʿ� �Ӽ� : Ư�� �ð�, ����ð�, �� GameObject
//����1. ���� �ð��� �帥��.
//����2. ���� �ð��� Ư�� �ð��� �Ǹ� 
//����3. ���� �����ؼ� EnemyManager��ġ�� �����Ѵ�.
//����4. �ð��� �ʱ�ȭ ���ش�.


//�߰�. Ư���ð��� ������ �ð����� �����Ѵ�.
public class EnemyManager : MonoBehaviour
{


    //�ʿ�Ӽ�: Ư�� �ð�, ����ð�, �� GameObhect
    //Ư���ð�
    float createTime;

    //����ð�
    float currentTime;

    //�� ���ӿ�����Ʈ
    public GameObject enemy;

    //������ �ð��� �ּ� �ִ�
    public float minTime = 0;
    public float maxTime = 10;

    private void Start()
    {
        createTime = Random.Range(minTime, maxTime);
    }

    // Update is called once per frame
    void Update()
    {
        //����1. ���� �ð��� �帥��.
        currentTime = currentTime + Time.deltaTime;

        //����2. ���� �ð��� Ư�� �ð��� ������
        if(currentTime > createTime)
        {
            //����3. ���� �����ؼ� EnemyManager��ġ�� �����Ѵ�.
            GameObject enemyGo = Instantiate(enemy);
            enemyGo.transform.position = transform.position;

            //����4. �ð��� �ʱ�ȭ ���ش�.
            currentTime = 0;
        }
    }
}
