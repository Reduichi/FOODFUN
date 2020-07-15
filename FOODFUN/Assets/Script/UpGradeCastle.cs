using UnityEngine;
using UnityEngine.UI;

public class UpGradeCastle : MonoBehaviour
{
    [Header("城堡資料")]
    public CastleData data;                     // 一般欄位才可以獨立使用
    public Text UpGradeNeedText;
    public Text HpText;

    /// <summary>
    /// 升級
    /// </summary>
    public void Upgrade()
    {
        if (Gamemanager.instance.RealMoney > data.Need)
        {
            Gamemanager.instance.RealMoney -= data.Need;
            data.Need *= 2;
            data.hpMax *= 2f;
            UpGradeNeedText.text = data.Need.ToString();
            HpText.text = "生命力   " + data.hpMax.ToString();
        }
    }
    private void Start()
    {
        UpGradeNeedText.text = data.Need.ToString();
        HpText.text = "生命力   " + data.hpMax.ToString();
    }
}
