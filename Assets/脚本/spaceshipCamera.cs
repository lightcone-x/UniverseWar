using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaceshipCamera : MonoBehaviour
{
    public float disatnce;
    public float rot = 0;
    private float roll = 30f * Mathf.PI * 2 / 360;

    private float maxRoll = 90f * Mathf.PI * 2 / 360;//摄像机最大俯角
    private float minRoll = -90f * Mathf.PI * 2 / 360;//摄像机最大仰角
    private float rollSpeed = 0.2f;

    private GameObject target;
    public GameObject cameraPoint;




    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Cube1");
    }

    private void LateUpdate()
    {
        if (target == null)
            return;
        if (Camera.main == null)
            return;
        Vector3 targetPos = target.transform.position;
        Vector3 cameraPos;
        float d = disatnce * Mathf.Cos(roll);
        float height = disatnce * Mathf.Sin(roll);
        cameraPos.x = targetPos.x + d * Mathf.Cos(rot);
        cameraPos.z = targetPos.z + d * Mathf.Sin(rot);
        cameraPos.y = targetPos.y + height;
        Camera.main.transform.position = cameraPos;
        Camera.main.transform.LookAt(target.transform);

        SetTarget(cameraPoint);

        if (target == null)
            return;
        if (Camera.main == null)
            return;
        Rotate();

        Roll();

        Zoom();

    }
    public void SetTarget(GameObject target)//相机瞄准cameraPoint
    {
        if (target.transform.Find("cameraPoint") != null)
            this.target = target.transform.Find("cameraPoint").gameObject;
        else
            this.target = target;
    }

    public float rotSpeed = 0.2f;//鼠标水平方向转速

    void Rotate()//相机横向旋转
    {
        float w = Input.GetAxis("Mouse X") * rotSpeed;
        rot -= w;
    }



    void Roll()//相机纵向旋转
    {
        float w = Input.GetAxis("Mouse Y") * rollSpeed * 0.5f;
        roll -= w;
        if (roll > maxRoll)
            roll = maxRoll;
        if (roll < minRoll)
            roll = minRoll;
    }

    public float maxDistance = 22f;
    public float minDistance = 5f;
    public float zoomSpeed = 0.2f;
    void Zoom()//滚轮调节距离
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (disatnce > minDistance)
                disatnce -= zoomSpeed;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (disatnce < maxDistance)
                disatnce += zoomSpeed;
        }
    }
}
