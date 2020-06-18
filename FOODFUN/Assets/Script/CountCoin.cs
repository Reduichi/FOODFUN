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
    [Header("升級按鈕")]
    public Button LevelUpBtn;
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
    public void AddCoin()
    {
        Coin += Time.deltaTime * CoinAddtionalTime;
        Coin = Mathf.Clamp(Coin, 0, MaxCoin);
    }
    private void Update()
    {
        AddCoin();
        CoinText.text = (int)Coin+"/" + MaxCoin;
    }
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
            LevelUpBtn.interactable = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "金幣(Clone)")
        {
            Coin += 50;
            Destroy(collision.gameObject);
        }
    }
    public void PetOnePay()
    {
        Coin -= 150;
    }
}
