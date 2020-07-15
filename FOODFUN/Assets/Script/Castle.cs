using UnityEngine;
using UnityEngine.UI;

public class Castle : MonoBehaviour
{
    public Text CastleLife;
    public int CastleMaxLife;
    private HpValueManager hpValueManager;   // 血條數值管理器
    public float Hp;
    // Start is called before the first frame update
    void Start()
    {
        hpValueManager = GetComponentInChildren<HpValueManager>();    // 取得子物件元件
    }
    /// <summary>
    /// 受傷
    /// </summary>
    /// <param name="damage"></param>
    public void Hit(float damage)
    {
        Hp -= damage;
        CastleLife.text = "Castle : " + Hp + " / " +CastleMaxLife;
        hpValueManager.SetHP(Hp, CastleMaxLife);      // 更新血量(目前，最大)
        StartCoroutine(hpValueManager.ShowValue(damage, "-", Color.white));
        if (Hp <= 0) Player.instance.Lose(); //如果Hp < 0 執行戰敗方法
    }
}
