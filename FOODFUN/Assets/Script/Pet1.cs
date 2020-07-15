using UnityEngine;
using UnityEngine.UI;

public class Pet1 : MonoBehaviour
{
    [Header("寵物資料")]
    public PetData data;                     // 一般欄位才可以獨立使用
    [Header("寵物一號")]
    public Text UpGradeNeedText;
    public Text Pet1AtkText;
    public Text Pet1HpText;

    /// <summary>
    /// 寵物1號升級
    /// </summary>
    public void Upgrade()
    {
        if (Gamemanager.instance.RealMoney > data.Need)
        {
            Gamemanager.instance.RealMoney -= data.Need;
            data.Need *= 2;
            data.attack *= 1.5f;
            data.hpMax *= 1.5f;
            UpGradeNeedText.text = data.Need.ToString();
            Pet1HpText.text = "生命力  "+data.hpMax.ToString();
            Pet1AtkText.text = "攻擊力  "+data.attack.ToString();
        }
    }
    private void Start()
    {
        UpGradeNeedText.text = data.Need.ToString();
        Pet1HpText.text = "生命力  " + data.hpMax.ToString();
        Pet1AtkText.text = "攻擊力  " + data.attack.ToString();
    }
}
