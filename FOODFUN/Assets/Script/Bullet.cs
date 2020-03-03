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

    private void OnTriggerEnter(Collider other)
    {
        if (!player && other.name == "玩家")                         // 如果碰到.名稱 = "玩家"
        {
            other.GetComponent<Player>().Hit(damage);     // 取得<玩家>().受傷(傷害值)
            Destroy(gameObject);
        }
        else if (player && other.tag == "敵人")
        {
            other.GetComponent<Enemy>().Hit(damage);
            Destroy(gameObject);
        }
    }
}
