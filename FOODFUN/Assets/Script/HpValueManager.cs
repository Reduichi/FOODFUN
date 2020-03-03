using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HpValueManager : MonoBehaviour
{
    private Image hpBar;
    private Text hpText;
    private RectTransform hpRect;

    private void Start()
    {
        hpBar = transform.GetChild(1).GetComponent<Image>();
        hpText = transform.GetChild(2).GetComponent<Text>();
        hpRect = transform.GetChild(2).GetComponent<RectTransform>();
    }

   
    /// <summary>
    /// 更新血量
    /// </summary>
    /// <param name="hpCurrent">目前血量</param>
    /// <param name="hpMax">最大血量</param>
    public void SetHP(float hpCurrent, float hpMax)
    {
        hpBar.fillAmount = hpCurrent / hpMax;
    }

    /// <summary>
    /// 顯示數值
    /// </summary>
    /// <param name="value">數值</param>
    /// <param name="mark">符號</param>
    /// <param name="color">顏色</param>
    public IEnumerator ShowValue(float value, string mark, Color color)
    {
        hpText.text = mark + value;     // 更新文字
        color.a = 0;                    // 透明度 = 0
        hpText.color = color;           // 更新顏色
        hpRect.anchoredPosition = Vector2.up * (-55);   // 位置還原

        for (int i = 0; i < 20; i++)
        {
            hpText.color += new Color(0, 0, 0, 0.05f);   // 遞增透明度
            hpRect.anchoredPosition += Vector2.up * 5;   // 位置遞增5
            yield return new WaitForSeconds(0.01f);      // 等待
        }

        hpText.color = new Color(0, 0, 0, 0);           // 還原透明度
    }
}
