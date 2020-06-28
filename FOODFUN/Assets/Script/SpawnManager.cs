using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public SpawnData spawnData;
    [Header("敵人相鄰時間差")]
    public float ReferenceTime;
    [Header("波數計數器")]
    public int Count;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        Count = 0;
    }
    private void Update()
    {
        time = CountTime.instance.time;
        SpawnManage();
    }

    /// <summary>
    /// 生成時間管理
    /// </summary>
    public void SpawnManage()
    {
        if (Count == spawnData.spawn.Length) return;

        if (time >= spawnData.spawn[Count].StartTime)
        {
            StartCoroutine(WaveSpawn(Count));
            print(spawnData.spawn[Count].name);
            Count++;
        }
    }
    /// <summary>
    /// 生成波數內容管理
    /// </summary>
    /// <param name="i"></param>
    /// <returns></returns>
    public IEnumerator WaveSpawn(int i)
    {
        for (int m = 0; m < spawnData.spawn[i].Enemy.Length; m++)
        {
            Vector3 pos = new Vector3(27.63f, -0.44f, 0);
            Quaternion qua = Quaternion.identity;
            Instantiate(spawnData.spawn[i].Enemy[m].Enemy, pos, qua);
            yield return new WaitForSeconds(ReferenceTime);
        }
    }
}
