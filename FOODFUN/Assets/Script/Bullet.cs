﻿using UnityEngine;

public class Bullet : MonoBehaviour
{
    /// <summary>
    /// 子彈的傷害值
    /// </summary>
    public float damage;
    public bool player;
    public float SaveTime = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!player && collision.tag == "我方")              // 如果碰到.名稱 = "我方"
        {
            collision.GetComponent<Player>().Hit(damage);    // 取得<玩家>().受傷(傷害值)
            Destroy(gameObject);
        }
        else if (player && collision.tag == "敵人")          // 如果碰到.名稱 = "敵人"
        {
            if (collision.GetComponent<Enemy>().Fired == false)
            {
                print("有燒到人");
                collision.GetComponent<Enemy>().Hit(damage);     // 取得<敵人>().受傷(傷害值)
                collision.GetComponent<Enemy>().Fired = true;
            }
        }
    }
    private void Update()
    {
        SaveTime += Time.deltaTime;
        if (SaveTime > 1.5f)
        {
            Destroy(gameObject);
        }
    }


}
