using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;  //主角
    public float speed;  //相机跟随速度

    public float minPosx;  //相机不超过背景边界允许的最小值
    public float maxPosx;  //相机不超过背景边界允许的最大值

    void Update()
    {
        FixCameraPos();
    }

    void FixCameraPos()
    {
        float pPosX = player.transform.position.x;//主角 x轴方向 时实坐标值
        float cPosX = transform.position.x;//相机 x轴方向 时实坐标值

        if (pPosX - cPosX > 3)    // 并不是死死地跟随，是相机和主角之间距离超过某个值时才跟随
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
