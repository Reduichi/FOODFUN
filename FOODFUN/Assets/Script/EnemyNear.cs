using UnityEngine;
using System.Collections;

public class EnemyNear : Enemy
{
    protected override void Attack()
    {
        // 父類別原本的敘述或演算法
        base.Attack();
        // print("近距離單位的複寫攻擊方法。");

        StartCoroutine(AttackDelay());

    }

    private IEnumerator AttackDelay()
    {
        yield return new WaitForSeconds(data.attackDelay);

        RaycastHit2D hit = Physics2D.Raycast(transform.position + Vector3.up * data.attackY, -transform.right, data.attackLength, 512);     
        // 區域變數 碰撞資訊 : 用來存放射線打到的物件

        // out 參數修飾詞 : 保存方法的資訊在區域變數內
        // 物理.射線(起點，方向，碰撞資訊，長度)
        if (hit)
        {
            hit.collider.GetComponent<Player>().Hit(data.attack);
        }
    }

    // 繪製圖示 : 只會在場景內顯示，開發者觀看
    private void OnDrawGizmos()
    {
        // 圖示.顏色 = 顏色
        Gizmos.color = Color.red;
        // 圖示.繪製射線 (起點，方向)
        // 前方 Z transform.forward
        // 右方 X transform.right
        // 上方 Y transform.up

        // Vector3.up = new Vector3(0, 1, 0)
        // Vector3.right = new Vector3(1, 0, 0)
        // Vector3.foeward = new Vector3(0, 0, 1)
        Gizmos.DrawRay(transform.position + Vector3.up * data.attackY, -transform.right * data.attackLength);

    }
}
