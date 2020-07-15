using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gamemanager : MonoBehaviour
{
    [Header("鳳梨")]
    public GameObject pineapple;    // GameObject 可以存放預置物以及場景上的物件
    [Header("實際擁有的金錢")]
    public int RealMoney = 9999999;
    public Text TheMoneyText1, TheMoneyText2, TheMoneyText3;
    public static Gamemanager instance;
    //public List<ta

    private void Start()
    {
        instance = this;
        //InvokeRepeating("Pineapple", 0, 5f);
    }
    private void Pineapple()
    {
        Vector3 pos = new Vector3(27.63f, -0.44f, 0);
        Quaternion rot = new Quaternion(0, 0, 0, 0);
        Instantiate(pineapple, pos, rot);
    }
    private void Update()
    {
        TheMoneyText1.text = RealMoney.ToString();
        TheMoneyText2.text = RealMoney.ToString();
        TheMoneyText3.text = RealMoney.ToString();
    }

}
