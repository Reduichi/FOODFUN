using UnityEngine;
//腳本物件化
[CreateAssetMenu(fileName = "生怪資料", menuName = "RED/生怪資料")]
public class SpawnData : ScriptableObject
{
    public SpawnTime[] spawn;           //生成波數清單
}
//序列化
[System.Serializable]
public class SpawnTime
{
    public string name;                 //波數名稱
    public float StartTime;             //生成時間
    public SpawnEnemy[] Enemy;          //生成單位清單
}
//序列化
[System.Serializable]
public class SpawnEnemy
{
    public GameObject Enemy;            //生成清單內物件
}