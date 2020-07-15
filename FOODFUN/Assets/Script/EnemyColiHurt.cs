using UnityEngine;

public class EnemyColiHurt : MonoBehaviour
{
    public EnemyData Data;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "我方" && collision.GetComponent<Player>())
        {
            print("撞到玩家了");
            collision.GetComponent<Player>().Hit(Data.attack);
        }
    }
}
