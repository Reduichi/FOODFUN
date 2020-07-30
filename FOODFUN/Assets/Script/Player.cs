using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;      // 引用 查詢 API - MinMax 與 ToList
using System.Collections;


public class Player : MonoBehaviour
{
    [Header("速度"), Range(0, 1500)]
    public float speed = 1.5f;
    [Header("玩家資料")]
    public PlayerData data;
    [Header("是否等待")]
    public bool Wating;
    [Header("是否死亡")]
    public bool dead;
    [Header("火球")]
    public GameObject bullet;
    [Header("閃電")]
    public GameObject Lightning1, Lightning2;
    [Header("音效區域")]
    public AudioSource aud;
    public AudioClip skilllight, pickcoin, skillfire, attacksound, click;
    [Header("回血冷卻時間")]
    public float RecoveryCd = 1;                 // 回血冷卻時間
    public float RecoveryTimer;             // 回血計時器
    public static Player instance;                     //實體化腳本物件
    public float Hp;
    private Enemy Enemy;
    private Rigidbody2D rig;
    private Animator ani;                    // 動畫控制器元件
    private HpValueManager hpValueManager;   // 血條數值管理器
    private float timer;                     // 計時器
    private Enemy[] enemys;                  // 敵人陣列 : 存放所有敵人
    private float[] enemysDis;               // 距離陣列 : 存放所有敵人的距離
    private Vector3 LightningPos1, LightningPos2;            // 閃電座標
    private Vector3 posBullet;               // 子彈座標
    public GameObject LostSprite;

    private void Start()
    {
        instance = this;
        Hp = data.hpMax;
        rig = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();                               // 動畫控制器 = 取得文件<動畫控制器>()
        hpValueManager = GetComponentInChildren<HpValueManager>();    // 取得子物件元件
        // Physics2D.IgnoreLayerCollision(8, 10);
        Physics2D.IgnoreLayerCollision(9, 12);
    }

    // 固定更新 : 一秒執行50次，處理物理行為
    private void FixedUpdate()
    {
        Move();
        HpRecoverSystem();
        ClampPlayer();
    }

    /// <summary>
    /// 限制玩家走位
    /// </summary>
    public void ClampPlayer()
    { 
        Vector3 posP = gameObject.transform.position;         // 玩家
        transform.position = new Vector2( posP.x = Mathf.Clamp(posP.x, -10, 25),transform.position.y);    // 玩家.x 夾住 左方限制 ~ 右方限制
    }

    /// <summary>
    /// 移動
    /// </summary>
    private void Move()
    {
        ani.SetBool("走路開關", Input.GetAxisRaw("Horizontal") != 0);  // 動畫控制器.設定布林植("參數名稱",布林值)
        rig.AddForce(transform.right * Input.GetAxisRaw("Horizontal") * speed);
        //當沒有在移動時 
        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            Attack(); //執行攻擊方法
        }
    }

    /// <summary>
    /// 受傷
    /// </summary>
    /// <param name="damage"></param>
    public void Hit(float damage)
    {
        if (dead) return;
        Hp -= damage;
        hpValueManager.SetHP(Hp, data.hpMax);      // 更新血量(目前，最大)
        StartCoroutine(hpValueManager.ShowValue(damage, "-", Color.white));
        if (Hp <= 0) Dead(); //如果Hp < 0 執行死亡方法
    }

    /// <summary>
    /// 死亡
    /// </summary>
    public void Dead()
    {
        dead = true;
        ani.SetBool("死亡開關", true);          // 死亡動畫 = true
        Lose();
    }
    public void Lose()
    {
        enabled = false;                        // 關閉此腳本 (this 可省略)
        LostSprite.SetActive(true);
    }
    /// <summary>
    /// 成功並進入升級介面
    /// </summary>
    public void SucGetInUpgrade()
    {
        Player.instance.data.Stage++;
        SceneManager.LoadScene("升級介面");

    }
    /// <summary>
    /// 進入升級介面
    /// </summary>
    public void GetInUpgrade()
    {
        SceneManager.LoadScene("升級介面");
        aud.PlayOneShot(click, 0.5f);          // 音源.播放一次(音效片段，音量)
    }

    [Header("現在的敵人")]
    public GameObject tempEnemy;
    /// <summary>
    /// 攻擊
    /// </summary>
    private void Attack()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, data.attackLength2, 256);

        if (hit)        //如果 此射線觸碰       
        {
            tempEnemy = hit.collider.gameObject;// 現在的敵人是最先接觸的敵人
            RecoveryTimer = 0;                  // 回血計數器歸零
            if (timer < data.cd)                // 如果 計時器 < 冷卻時間
            {
                timer += Time.deltaTime;        // 計時器 累加
            }
            //如果 時間到了 並且 射線觸碰的物體和主角距離小於3
            else if (timer >= data.cd && hit.collider.gameObject.transform.position.x - gameObject.transform.position.x < 3)
            {
                print("近距離攻擊");
                timer = 0;                      // 計時器 歸零
                ani.SetTrigger("攻擊開關2");    // 攻擊動畫
                tempEnemy.GetComponent<Enemy>().Hit(data.attack);
                aud.PlayOneShot(attacksound, 0.3f);          // 音源.播放一次(音效片段，音量)
            }
            else if (timer >= data.cd && hit.collider.gameObject.transform.position.x - gameObject.transform.position.x < 6)
            {
                print("遠距離攻擊");
                timer = 0;                      // 計時器 歸零
                ani.SetTrigger("攻擊開關");     // 攻擊動畫
                tempEnemy.GetComponent<Enemy>().Hit(data.attack);
                tempEnemy.GetComponent<Enemy>().HurtBack();
                aud.PlayOneShot(attacksound, 0.3f);          // 音源.播放一次(音效片段，音量)
            }
        }

    }

    /// <summary>
    /// 自動回血系統
    /// </summary>
    public void HpRecoverSystem()
    {
        RecoveryTimer += Time.deltaTime;
        if (RecoveryTimer >= RecoveryCd) 
        {
            RecoveryTimer = 0;
            StartCoroutine(HpRecover());
        }
    }

    /// <summary>
    /// 生成火球
    /// </summary>
    public void FireBullet()
    {
        ani.SetTrigger("攻擊開關");                                                           // 攻擊動畫
        posBullet = transform.position + transform.right * data.attackfireY;                  // 火球座標 = 玩家.座標 + 玩家右方 * Y
        Vector3 angle = transform.eulerAngles;                                                // 三維向量 玩家角度 = 變形.歐拉角度(0 - 360度)
        Quaternion qua = Quaternion.Euler(angle.x + 180, angle.y, angle.z);                   // 四元角度 = 四元.歐拉() - 歐拉轉為四元角度
        GameObject temp = Instantiate(bullet, posBullet, qua);                                // 區域變數 = 生成(物件，座標，角度)
        temp.GetComponent<Rigidbody2D>().AddForce(transform.right * data.bulletPower);        // 取得鋼體.推力(玩家右方 * 力道)
        temp.AddComponent<Bullet>();                                                          // 暫存.添加元件<泛型>
        temp.GetComponent<Bullet>().damage = data.attackfire;                                 // 暫存.取得元件<泛型>.傷害值 = 火球.攻擊力
        temp.GetComponent<Bullet>().player = true;
        CountTime.instance.FireSkillCoolDown();
        aud.PlayOneShot(skillfire,0.5f);          // 音源.播放一次(音效片段，音量)
    }
    public void CreateLightning()
    {
        StartCoroutine(LightingBall());
    }
    /// <summary>
    /// 生成閃電
    /// </summary>
    public IEnumerator LightingBall()
    {
        ani.SetTrigger("攻擊開關");
        LightningPos1 = transform.position + transform.up * 6 + transform.right * 5f;
        LightningPos2 = transform.position + transform.up * 3 + transform.right * 5f;
        Quaternion qua = Quaternion.Euler(0, 0, -36.84f);
        GameObject Temp1 = Instantiate(Lightning1, LightningPos1, qua);
        Destroy(Temp1, 0.5f);
        yield return new WaitForSeconds(0.2f);
        GameObject Temp2 = Instantiate(Lightning2, LightningPos2, qua);
        Temp2.AddComponent<Lightning>();                                                            // 暫存.添加元件<泛型>
        CountTime.instance.LightningSkillCoolDown();
        aud.PlayOneShot(skilllight, 0.5f);          // 音源.播放一次(音效片段，音量)
    }
    /// <summary>
    /// 恢復血量
    /// </summary>
    /// <returns></returns>
    private IEnumerator HpRecover()
    {
        Hp += 50;
        hpValueManager.SetHP(Hp, data.hpMax);      // 更新血量(目前，最大)
        yield return null;
    }

    /// <summary>
    /// 繪製射線
    /// </summary>
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position + Vector3.up * data.attackY, transform.right * data.attackLength);
        // 火球座標 = 玩家.座標 + 玩家右方 * Y
        posBullet = transform.position + transform.right * data.attackfireY;
        // 圖示.繪製球體(中心點，半徑)
        Gizmos.DrawSphere(posBullet, 0.1f);

        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position + Vector3.up * data.attackY2, transform.right * data.attackLength2);
        // 火球座標 = 玩家.座標 + 玩家右方 * Y
        posBullet = transform.position + transform.right * data.attackfireY2;
        // 圖示.繪製球體(中心點，半徑)
        Gizmos.DrawSphere(posBullet, 0.1f);
    }
    /// <summary>
    /// 撿到錢 增加金幣
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "金幣(Clone)")
        {
            CountCoin.instance.Coin += 100;
            data.RealMoney += 100;
            Destroy(collision.gameObject);
            aud.PlayOneShot(pickcoin, 0.1f);          // 音源.播放一次(音效片段，音量)
        }
    }

}

