using UnityEngine;
using UnityEngine.UI;

public class Pet2 : MonoBehaviour
{
    [Header("寵物資料")]
    public PetData data;                     // 一般欄位才可以獨立使用
    [Header("寵物二號")]
    public Text UpGradeNeedText;
    public Text Pet2AtkText;
    public Text Pet2HpText;
    public GameObject Lock;


    /// <summary>
    /// 寵物2號升級
    /// </summary>
    public void Upgrade()
    {
        if (Gamemanager.instance.SceneNumber > 0)
        {
            if (Gamemanager.instance.RealMoney > data.Need)
            {
                Gamemanager.instance.RealMoney -= data.Need;
                data.Need *= 2;
                data.attack *= 1.5f;
                data.hpMax *= 1.5f;
                UpGradeNeedText.text = data.Need.ToString();
                Pet2HpText.text = "生命力  "+data.hpMax.ToString();
                Pet2AtkText.text = "攻擊力  "+data.attack.ToString();
            }
        }
    }
    private void Start()
    {
        UpGradeNeedText.text = data.Need.ToString();
        Pet2HpText.text = "生命力  " + data.hpMax.ToString();
        Pet2AtkText.text = "攻擊力  " + data.attack.ToString();
        if (Gamemanager.instance.SceneNumber > 0)
        {
            Lock.SetActive(false);
        }
    }
}
