using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tank : MonoBehaviour
{
    public float speed;//车体速度
    public float street;//车体转速

    public Transform turret;//炮塔
    private float turretRotSpeed = 0.5f;//转速
    private float turretRotTarget = 0;

    public Transform gun;//炮管
    private float maxRoll = 10f;//俯角  炮管俯仰角受到摄像机俯仰角限制
    private float minRoll = -20f;//仰角
    private float turretRollTarget = 0;

    public GameObject bullet;
    public float lastShootTime = 0;//上一次开炮的时间
    private float shootInterval = 0.5f;//炮弹装填时间

    private float maxHp;//最大生命值
    private float hp;//当前生命值

    void Start()
    {
        turret = transform.Find("turret");//导弹锁定也可以用这个方法，自动将目标设置为追踪目标
                                          // gun = transform.Find("gun");
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        transform.Rotate(0, x * street * Time.deltaTime, 0);

        float y = Input.GetAxis("Vertical");
        Vector3 s = y * transform.forward * speed * Time.deltaTime;
        transform.transform.position += s;
        //车体前进后退与旋转

        turretRotTarget = Camera.main.transform.eulerAngles.y;
        TurretRotation();//炮塔旋转

        turretRollTarget = Camera.main.transform.eulerAngles.x;
        TurretRoll();//炮管俯仰
        
        PlayerCtrl();

    }

    public void PlayerCtrl()
    {
        if (Input.GetMouseButton(0))
            Shoot();
        if (ctrlType != CtrlType.player)
            return;
    }

    public enum CtrlType
    {
        none,player,computer
    }
    public CtrlType ctrlType = CtrlType.player;

    public void TurretRotation()//炮塔旋转
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

    /*public void PlayerCtrl()
    {
        if (Input.GetMouseButton(0))
            Shoot();
    }*/

    public void TurretRoll()//炮管俯仰
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

     public void Shoot()//射击
    {
        if (Time.time - lastShootTime < shootInterval)
            return;
        if (bullet == null)
            return;
        Vector3 pos = gun.position + gun.forward * 10;
        Instantiate(bullet, pos, gun.rotation);
        lastShootTime = Time.time;
    }
}
