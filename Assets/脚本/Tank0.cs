using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank0 : MonoBehaviour
{
    public float movespeed;//移动速度
    public float rotatespeed;//转弯速度

    public Transform turret;//炮塔
    private float turretRotSpeed = 0.5f;//转速
    private float turretRotTarget = 0;//炮塔目标角度

    public Transform gun;//炮管
    private float maxRoll = 20f;//俯角
    private float minRoll = -30f;//仰角
    private float turretRollTarget = 0;

    public Texture2D centerSight;//中央准星
    public Texture2D tankSight;//鼠标准星

    public void TargetSignPos()
    {
        Vector3 hitPoint = Vector3.zero;
        RaycastHit raycastHit;
        Vector3 centerVec = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        Ray ray = Camera.main.ScreenPointToRay(centerVec);
        if(Physics.Raycast(ray,out raycastHit, 400.0f))
        {
            hitPoint = raycastHit.point;
        }
        else
        {
            hitPoint = ray.GetPoint(400);
        }
        Vector3 dir = hitPoint - turret.position;
        Quaternion angle = Quaternion.LookRotation(dir);
        turretRotTarget = angle.eulerAngles.y;
        turretRollTarget = angle.eulerAngles.x;
        Transform targetCube = GameObject.Find("TargetCube").transform;
        targetCube.position = hitPoint;
    }

    void Start()
    {
        turret = transform.Find("turret");//导弹锁定，自动将目标设置为追踪目标
       // gun = transform.Find("gun");
        
    }

    void Update()
    {
        turretRotTarget = Camera.main.transform.eulerAngles.y;
        TurretRotation();

        turretRollTarget = Camera.main.transform.eulerAngles.x;
        turretRoll();

    }

    //炮塔旋转
    public void TurretRotation()
    {
        if (Camera.main == null)
            return;
        if (turret == null)
            return;
        float angle = turret.eulerAngles.y - turretRotTarget;
        if (angle < 0) angle += 360;
        if (angle > turretRotSpeed && angle < 180)
            turret.Rotate(0f, -turretRotSpeed, 0f);
        else if (angle > 180 && angle < 360 - turretRotSpeed)
            turret.Rotate(0f, turretRotSpeed, 0f);
    }

    //炮管俯仰
    public void turretRoll()
    {
        if (Camera.main == null)
            return;
        if (turret == null)
            return;

        Vector3 worldEuler = gun.eulerAngles;
        Vector3 localEuler = gun.localEulerAngles;

        worldEuler.x = turretRollTarget;
        gun.eulerAngles = worldEuler;

        Vector3 euler = gun.localEulerAngles;

        if (euler.x > 180)
            euler.x -= 360;
        if (euler.x > maxRoll)
            euler.x = maxRoll;
        if (euler.x < minRoll)
            euler.x = minRoll;

        gun.localEulerAngles = new Vector3(euler.x, localEuler.y, localEuler.z);

    }

    public void playCtrl()
    {
        TargetSignPos();
    }

    public Vector3 CalExplodePoint()//计算实际射击位置
    {
        Vector3 hitPoint = Vector3.zero;
        RaycastHit hit;
        Vector3 pos = gun.position + gun.forward * 5;
        Ray ray = new Ray(pos, gun.forward);
        if(Physics.Raycast(ray,out hit, 400.0f))
        {
            hitPoint = hit.point;
        }
        else
        {
            hitPoint = ray.GetPoint(400);
        }
        Transform explodeCube = GameObject.Find("ExplodeCube").transform;
        explodeCube.position = hitPoint;
        return hitPoint;
    }


    public void DrawSight()
    {
        Vector3 explodePoint = CalExplodePoint();
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(explodePoint);
        Rect tankRect = new Rect(screenPoint.x - tankSight.width / 2, Screen.height - screenPoint.y - tankSight.height / 2, tankSight.width, tankSight.height);
        GUI.DrawTexture(tankRect, tankSight);
        Rect centerRect = new Rect(Screen.width / 2 - centerSight.width / 2, Screen.height / 2 - centerSight.height / 2, centerSight.width, centerSight.height);
        GUI.DrawTexture(centerRect, centerSight);
    }
   private void OnGUI()
    {
        /*if (ctrlType != ctrlType.player)
            return;*/
        DrawSight();
    }
    
    private void FixedUpdate()
    {
        
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * movespeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * movespeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.down * rotatespeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * rotatespeed * Time.deltaTime);
        }
    }
}
