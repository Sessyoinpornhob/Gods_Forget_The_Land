using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;  //����
    public float speed;  //��������ٶ�

    public float minPosx;  //��������������߽��������Сֵ
    public float maxPosx;  //��������������߽���������ֵ

    void Update()
    {
        FixCameraPos();
    }

    void FixCameraPos()
    {
        float pPosX = player.transform.position.x;//���� x�᷽�� ʱʵ����ֵ
        float cPosX = transform.position.x;//��� x�᷽�� ʱʵ����ֵ

        if (pPosX - cPosX > 3)    // �����������ظ��棬�����������֮����볬��ĳ��ֵʱ�Ÿ���
        {
            transform.position = new Vector3(cPosX + speed, transform.position.y, transform.position.z);
        }

        if (pPosX - cPosX < -3)
        {
            transform.position = new Vector3(cPosX - speed, transform.position.y, transform.position.z);
        }

        float realPosX = Mathf.Clamp(transform.position.x, minPosx, maxPosx);

        transform.position = new Vector3(realPosX, transform.position.y, transform.position.z);
    }
}
