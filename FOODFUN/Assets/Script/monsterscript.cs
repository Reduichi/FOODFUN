using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterscript : MonoBehaviour
{
    [Header("血量")]
    public int Hp = 100;
    public int attack;
    private Animator ani;           // 動畫控制器元件
    private bool monattack, dead ;
    [Header("移動速度"), Range(0f, 100f)]
    public float speed = 1.5f;
    private Rigidbody2D rig;
    [Header("變形")]
    public Transform move;

    private void Dead()
    {
        if (Hp <= 0)
        {
            dead = true;
            ani.SetBool("怪物死亡開關", dead);  // 沒有生命播放死亡動畫
            Destroy(gameObject, 2);  //  刪除(物件，延遲事件) gameObject 此物件
            return;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "劍")  // 如果碰到武器執行
        {
            monattack = true;
            ani.SetBool("怪物攻擊開關", monattack);
            Hp = Hp - 5;
        }
    }

    /// <summary>
    /// 移動
    /// </summary>
    private void Move()
    {
        move.Translate(-speed * Time.deltaTime, 0, 0);
        // Time.deltaTime 一幀的時間
    }
    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();     // 動畫控制器 = 取得文件<動畫控制器>()
    }
    private void Update()
    {
        Dead();
    }
    private void FixedUpdate()
    {
        Move();
    }
}
