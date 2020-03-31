using UnityEngine;

public class Bullet : MonoBehaviour
{
    /// <summary>
    /// 子彈的傷害值
    /// </summary>
    public float damage;

    /// <summary>
    /// 是否為玩家的武器，true 玩家的 ， false 敵人的
    /// </summary>
    public bool player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!player && collision.tag == "我方")              // 如果碰到.名稱 = "我方"
        {
            collision.GetComponent<Player>().Hit(damage);    // 取得<玩家>().受傷(傷害值)
            Destroy(gameObject, 3);
        }
        else if (player && collision.tag == "敵人")          // 如果碰到.名稱 = "敵人"
        {
            collision.GetComponent<Enemy>().Hit(damage);     // 取得<敵人>().受傷(傷害值)
            Destroy(gameObject, 3);
        }
    }

   
}
