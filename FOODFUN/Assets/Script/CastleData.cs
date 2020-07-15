using UnityEngine;

[CreateAssetMenu(fileName = "城堡資料", menuName = "RED/城堡資料")]

public class CastleData : ScriptableObject
{
    [Header("血量")]
    public float hp;
    public float hpMax;
    [Header("升級需求金錢")]
    public int Need;
}
