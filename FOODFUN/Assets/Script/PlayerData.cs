using UnityEngine;

[CreateAssetMenu(fileName = "玩家資料", menuName = "RED/玩家資料")]
public class PlayerData : ScriptableObject
{
    [Header("血量"), Range(200, 10000)]
    public float hp;
    public float hpMax;
    [Header("攻擊冷卻時間"), Range(0, 1.5f)]
    public float cd = 1f;
    [Header("攻擊力"), Range(10, 1000)]
    public float attack;
    [Header("近距離單位")]
    public float attackY;
    public float attackLength;
    public float attackDelay;

}
