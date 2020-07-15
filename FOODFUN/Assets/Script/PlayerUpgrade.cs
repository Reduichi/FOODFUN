using UnityEngine;
using UnityEngine.UI;

public class PlayerUpgrade : MonoBehaviour
{
    [Header("玩家資料")]
    public PlayerData data;                     // 一般欄位才可以獨立使用
    public Text PlayerAtkText;
    public Text PlayerHpText;
    public Text UpGradeNeedText;
    [Header("閃電")]
    public Text LightningText;
    public Text LightningUpGradeNeedText;
    [Header("火球")]
    public Text FireBallText;
    public Text FireBallUpGradeNeedText;

    public void UpgradePlayer()
    {
        if (Gamemanager.instance.RealMoney > data.PlayerNeed)
        {
            Gamemanager.instance.RealMoney -= data.PlayerNeed;
            data.PlayerNeed *= 2;
            data.attack *= 2;
            data.hpMax *= 2;
            UpGradeNeedText.text = data.PlayerNeed.ToString();
            PlayerHpText.text = "生命力   " + data.hpMax.ToString();
            PlayerAtkText.text = "攻擊力   " + data.attack.ToString();
        }
    }
    public void UpgradeFireBall()
    {
        if (Gamemanager.instance.RealMoney > data.FireNeed)
        {
            Gamemanager.instance.RealMoney -= data.FireNeed;
            data.FireNeed *= 2;
            data.FireBall *= 2;
            FireBallUpGradeNeedText.text = data.FireNeed.ToString();
            FireBallText.text = "攻擊力   " + data.FireBall;
        }
    }
    public void UpgradeLightning()
    {
        if (Gamemanager.instance.RealMoney > data.LightningNeed)
        {
            Gamemanager.instance.RealMoney -= data.LightningNeed;
            data.LightningNeed *= 2;
            data.Lightning *= 2;
            LightningUpGradeNeedText.text = data.LightningNeed.ToString();
            LightningText.text = "攻擊力   " + data.Lightning;
        }
    }
    private void Start()
    {
        LightningUpGradeNeedText.text = data.LightningNeed.ToString();
        LightningText.text = "攻擊力   " + data.Lightning;
        FireBallUpGradeNeedText.text = data.FireNeed.ToString();
        FireBallText.text = "攻擊力   " + data.FireBall;
        UpGradeNeedText.text = data.PlayerNeed.ToString();
        PlayerHpText.text = "生命力   " + data.hpMax.ToString();
        PlayerAtkText.text = "攻擊力   " + data.attack.ToString();
    }
}
