using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ��ǥ: Background�� MAterial�� offset�� Y�� ���� �ӵ��� ��ȭ��Ű�� �ʹ�.
// �Ӽ�: ���� �ð�, �ӵ�
public class BackGroundRoller : MonoBehaviour
{
    // �Ӽ�: ���� �ð�, �ӵ�, ���͸���
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
