using UnityEngine;
using UnityEngine.AI;       // 引用 人工智慧 API
using System.Collections;

public class Pet : MonoBehaviour
{
    [Header("寵物資料")]
    public PetData data;                     // 一般欄位才可以獨立使用
    [Header("發射物件")]
    public GameObject bullet;
    [Header("是否正在等人")]
    public bool Wating;                      // 是否正在等人
    [Header("走路速度")]
    public float speed;
    [Header("是否死亡")]
    public bool dead;

    private Rigidbody2D rig;
    private float hp;
    private Animator ani;                    // 動畫控制器
    private float timer;                     // 計時器
    private HpValueManager hpValueManager;   // 血條數值管理器
    private Enemy[] enemys;                  // 敵人陣列 : 存放所有敵人
    private float[] enemysDis;               // 距離陣列 : 存放所有敵人的距離


    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        hpValueManager = GetComponentInChildren<HpValueManager>();    // 取得子物件元件
        hp = data.hpMax; //將Hp獨立儲存
    }

    private void Update()
    {
        Move();     // 呼叫移動方法
    }

    /// <summary>
    /// 移動
    /// </summary>
    private void Move()
    {
        if (Wating) return;
        StartCoroutine(WalkDelay());
        ani.SetBool("走路開關", true);      // 走路
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }

    /// <summary>
    /// 走路延遲
    /// </summary>
    /// <returns></returns>
    private IEnumerator WalkDelay()
    {
        yield return new WaitForSeconds(data.WalkDelay);
    }

    /// <summary>
    /// 等待
    /// </summary>
    private void Wait()
    {
        Wating = true;                          //當開始等待 Wating=true
        ani.SetBool("走路開關", false);         // 等待動畫
        timer += Time.deltaTime;                // 計時器累加

        if (timer >= data.cd)                    // 如果 計時器 >= 資料.冷卻
        {
            Attack();                           // 攻擊
        }
    }

    /// <summary>
    /// 攻擊
    /// </summary>
    protected virtual void Attack()
    {
        timer = 0;                      // 計時器 歸零
        ani.SetTrigger("攻擊開關");     // 攻擊動畫

        StartCoroutine(DelayAttack());
    }

    private IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(data.attackDelay);

        RaycastHit2D hit = Physics2D.Raycast(transform.position + Vector3.up * data.attackY, transform.right, data.attackLength, 256);

        if (hit)
        {
            //GameObject temp = Instantiate(bullet, transform.position + transform.forward, Quaternion.identity);
            //temp.AddComponent<Move>().speed = data.bulletSpeed;
            hit.collider.GetComponent<Enemy>().Hit(data.attack);
        }
    }

    /// <summary>
    /// 受傷
    /// </summary>
    /// <param name="damage">接收玩家給予的傷害值</param>
    public void Hit(float damage)
    {
        if (ani.GetBool("死亡開關")) return;
        StartCoroutine(AttackDelay()); //執行攻擊等待
        hp -= damage;
        hpValueManager.SetHP(hp, data.hpMax);      // 更新血量(目前，最大)
        StartCoroutine(hpValueManager.ShowValue(damage, "-", Color.white));
        if (hp <= 0) Dead(); //如果Hp < 0 執行死亡方法
    }
    /// <summary>
    /// 攻擊延遲
    /// </summary>
    /// <returns></returns>
    private IEnumerator AttackDelay()
    {
        yield return new WaitForSeconds(data.attackDelay);
    }

    /// <summary>
    /// 死亡
    /// </summary>
    private void Dead()
    {
        dead = true;
        gameObject.layer = 0;
        ani.SetBool("死亡開關", true);      // 死亡動畫
        Destroy(gameObject, 3f);
        Destroy(this,0.1f);                      // Destroy(GetComponent<元件>()); 刪除元件
    }
    [Header("現在的敵人")]
    public GameObject tempEnemy;

    /// <summary>
    /// 碰撞器相遇後執行等待
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "敵人" && collision.GetComponent<Enemy>())
        {
            //如果 碰撞器抓到敵人的碰撞器
            if (collision.GetType().Equals(typeof(CapsuleCollider2D)))
            {
                tempEnemy = collision.gameObject;  //現在的敵人變成碰觸到的敵人
                Wait(); //執行等待方法
            }
            //如果 敵人死掉了
            if (collision.GetComponent<Enemy>().dead)
            {
                Wating = false; //就繼續往前走
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position + Vector3.up * data.attackY + transform.right * 3, -transform.right * data.attackLength);
    }
}
