using UnityEngine;

public class Move : MonoBehaviour
{
    [Header("移動速度"), Range(0.1f, 30f)]
    public float speed;

    /// <summary>
    /// 移動方法
    /// </summary>
    private void MoveMethod()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }

    private void Update()
    {
        MoveMethod();
    }
}