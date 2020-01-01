using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("移動速度"), Range(0f, 100f)]
    public float speed = 1.5f;

    private Rigidbody2D rig;
    private Animator ani;           // 動畫控制器元件
    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();     // 動畫控制器 = 取得文件<動畫控制器>()
    }

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
    }
}
