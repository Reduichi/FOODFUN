using UnityEngine;
using System.Linq;      // 引用 查詢 API - MinMax 與 ToList
using System.Collections;


public class Player : MonoBehaviour
{
    [Header("速度"), Range(0, 1500)]
    public float speed = 1.5f;
    [Header("玩家資料")]
    public PlayerData data;

    private Rigidbody2D rig;
    private Animator ani;                    // 動畫控制器元件
    private HpValueManager hpValueManager;   // 血條數值管理器
    private float timer;                     // 計時器
    private Enemy[] enemys;                  // 敵人陣列 : 存放所有敵人
    private float[] enemysDis;               // 距離陣列 : 存放所有敵人的距離

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();     // 動畫控制器 = 取得文件<動畫控制器>()
        hpValueManager = GetComponentInChildren<HpValueManager>();    // 取得子物件元件
    }

    // 固定更新 : 一秒執行50次，處理物理行為
    private void FixedUpdate()
    {
        Move();
    }

    /// <summary>
    /// 移動
    /// </summary>
    private void Move()
    {
        ani.SetBool("走路開關", Input.GetAxisRaw("Horizontal") != 0);  // 動畫控制器.設定布林植("參數名稱",布林值)
        rig.AddForce(transform.right * Input.GetAxisRaw("Horizontal") * speed);

        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            Attack();
        }
    }

    /// <summary>
    /// 受傷
    /// </summary>
    /// <param name="damage"></param>
    public void Hit(float damage)
    {
        if (ani.GetBool("死亡開關")) return;
        data.hp -= damage;
        hpValueManager.SetHP(data.hp, data.hpMax);      // 更新血量(目前，最大)
        StartCoroutine(hpValueManager.ShowValue(damage, "-", Color.white));
        if (data.hp <= 0) Dead();
    }

    /// <summary>
    /// 死亡
    /// </summary>
    private void Dead()
    {
        ani.SetBool("死亡開關", true);          // 死亡動畫
        enabled = false;                        // 關閉此腳本 (this 可省略)
    }

    /// <summary>
    /// 攻擊
    /// </summary>
    private void Attack()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + Vector3.up * data.attackY, transform.right, data.attackLength, 256);

        if (hit)                // 如果 計時器 < 冷卻時間
        {
            if (timer < data.cd)                // 如果 計時器 < 冷卻時間
            {
                timer += Time.deltaTime;        // 計時器 累加
            }
            else
            {
                timer = 0;                      // 計時器 歸零
                ani.SetTrigger("攻擊開關");     // 攻擊動畫
                
                hit.collider.GetComponent<Enemy>().Hit(data.attack);
            }
        }
        
    }

    /// <summary>
    /// 恢復血量
    /// </summary>
    /// <returns></returns>
    private IEnumerator HpRecover()
    {
        yield return new WaitForSeconds(1f);
        data.hp += 50;
        hpValueManager.SetHP(data.hp, data.hpMax);      // 更新血量(目前，最大)
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position + Vector3.up * data.attackY, transform.right * data.attackLength);

    }
}

