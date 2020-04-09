using UnityEngine;
using UnityEngine.AI;       // 引用 人工智慧 API
using System.Collections;


public class Pineappleattack : MonoBehaviour
{
    public Enemy Enemy;

    public GameObject tempEnemy;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "我方")
        {
            tempEnemy = collision.gameObject;

            Enemy.Wait();
        }
        else Enemy.Wating = false;
    }


}
