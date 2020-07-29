using UnityEngine;
using System.Collections;

public class PetRange : Pet
{
    private Vector3 posBullet;               
    [Header("發射物件")]
    public GameObject bullet;
    public float ShootPosY;
    protected override void Attack()
    {
        timer = 0;                      // 計時器 歸零
        ani.SetTrigger("攻擊開關");     // 攻擊動畫
        BulletMove();
        StartCoroutine(DelayAttack());
    }
    public void BulletMove()
    {
        posBullet = transform.position+transform.right * ShootPosY;                                                       // 火球座標 = 玩家.座標 + 玩家右方 * Y
        Vector3 angle = transform.eulerAngles;                                                // 三維向量 玩家角度 = 變形.歐拉角度(0 - 360度)
        Quaternion qua = Quaternion.Euler(angle.x + 180, angle.y, angle.z);                   // 四元角度 = 四元.歐拉() - 歐拉轉為四元角度
        GameObject temp = Instantiate(bullet, posBullet, qua);                                // 區域變數 = 生成(物件，座標，角度)
        temp.GetComponent<Rigidbody2D>().AddForce(transform.right* data.bulletSpeed);                      // 取得鋼體.推力(玩家右方 * 力道)
        temp.AddComponent<Bullet>();                                                          // 暫存.添加元件<泛型>
        temp.GetComponent<Bullet>().damage = data.attack;                                             // 暫存.取得元件<泛型>.傷害值 = 火球.攻擊力
        temp.GetComponent<Bullet>().player = true;
    }
}
