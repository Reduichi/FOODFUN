using UnityEngine;

public class Lightning : MonoBehaviour
{
    public PlayerData Data;
    public float SaveTime = 0;

    private void Start()
    {
        Data = Player.instance.data;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "敵人")          // 如果碰到.名稱 = "敵人"
        {
            collision.GetComponent<Enemy>().Hit(Data.Lightning);
        }
    }
    private void Update()
    {
        SaveTime += Time.deltaTime;
        if (SaveTime > 1.5f)
        {
            Destroy(gameObject);
        }
    }


}
