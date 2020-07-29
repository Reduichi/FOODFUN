using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountCoin : MonoBehaviour
{
    [Header("金幣文字介面")]
    public Text CoinText;
    [Header("升級文字介面")]
    public Text LevelText;
    [Header("升級按鈕物件")]
    public GameObject LevelUpObject;
    [Header("現在金幣數量")]
    public float Coin = 0;
    [Header("金幣累加的頻率")]
    public float CoinAddtionalTime = 10;
    [Header("目前等級的金幣上限")]
    public int MaxCoin = 500;
    [Header("目前等級")]
    public int Level = 1;
    [Header("金幣價值")]
    public float CoinValue;
    [Header("升級所需金幣")]
    public float LevelUpNeedCoin = 250f;
    [Header("升級所增加金幣")]
    public float LevelUpAddCoin = 250f;
    [Header("寵物一號")]
    public GameObject Pet1;
    [Header("寵物二號")]
    public GameObject Pet2;
    public static CountCoin instance;
    private void Start()
    {
        instance = this;
    }
    /// <summary>
    /// 增加金幣
    /// </summary>
    public void AddCoin()
    {
        //金幣加速度 = 時間流動 * 金幣增加速度
        Coin += Time.deltaTime * CoinAddtionalTime;
        //金幣 = 範圍介於 0 與 最大金幣之間
        Coin = Mathf.Clamp(Coin, 0, MaxCoin);
    }
    public void LevelBtnActive()
    {
        if (Level == 10) return;
        if (Coin > LevelUpNeedCoin)
        {
            LevelUpObject.SetActive(true);
        }
        else LevelUpObject.SetActive(false);
    }
    private void Update()
    {
        AddCoin();
        LevelBtnActive();
        CoinText.text = (int)Coin+"/" + MaxCoin;
    }
    /// <summary>
    /// 等級提升
    /// </summary>
    public void LevelUp()
    {
        if (Coin > LevelUpNeedCoin)
        {
            Level += 1;
            MaxCoin = 500 * Level;
            Coin -= LevelUpNeedCoin;
            LevelUpNeedCoin += LevelUpAddCoin;
        }
        if (Level == 10)
        {
            LevelText.text = "滿等";
        }
    }
    /// <summary>
    /// 扣除金幣並產生寵物一號
    /// </summary>
    public void PetOnePay()
    {
        if (Coin>150)
        {
            Coin -= 150;
            Instantiate(Pet1, new Vector3(-10, -0.4f,0),Quaternion.identity);
        }
    }
    /// <summary>
    /// 扣除金幣並產生寵物二號
    /// </summary>
    public void PetTwoPay()
    {
        if (Coin > 250)
        {
            Coin -= 250;
            Instantiate(Pet2, new Vector3(-10, -0.4f, 0), Quaternion.identity);
        }
    }
}
