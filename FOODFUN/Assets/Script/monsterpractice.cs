using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterpractice : MonoBehaviour
{
    public static float speed = 3f;
    [Header("變形")]
    public Transform move;
    private Rigidbody2D rig;
    private Animator ani;           // 動畫控制器元件

    /// <summary>
    /// 鳳梨移動功能
    /// </summary>
    private void Move()
    {
        move.Translate(-speed * Time.deltaTime, 0, 0);
        // Time.deltaTime 一幀的時間
    }

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();     // 動畫控制器 = 取得文件<動畫控制器>()
    }

    private void Update()
    {
        Move();
    }
}
