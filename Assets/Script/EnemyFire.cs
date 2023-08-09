using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// ��ǥ: Ư�� �ð��� �ѹ��� �Ѿ��� ����� �÷��̾ ���� �߻��Ѵ�.
// �ʿ�Ӽ�: �Ѿ�, ����ð�, Ư���ð�, �÷��̾�, �÷��̾����
public class EnemyFire : MonoBehaviour
{
    public GameObject bullet;
    float currentTime;
    public float createTime = 1;
    GameObject player;
    Vector3 playerDir;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {

            currentTime += Time.deltaTime;

            if (currentTime > createTime)
            {
                // ����2: �Ѿ��� ����� �ʹ�.
                GameObject bulletGO = Instantiate(bullet);
                

                // ����3: �Ѿ��� ��ġ�� �÷��̾��� ��ġ�� �����ְ� �ʹ�.
                bulletGO.transform.position = transform.position;

                playerDir = (player.transform.position - gameObject.transform.position).normalized;
                bulletGO.GetComponent<EnemyBullet>().dir = playerDir;

                currentTime = 0;
            }
        }
    }
}
