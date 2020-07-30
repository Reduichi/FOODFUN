using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    public PlayerData Data;
    [Header("鳳梨")]
    public GameObject pineapple;    // GameObject 可以存放預置物以及場景上的物件
    [Header("音效區域")]
    public AudioSource aud;
    public AudioClip click;
    [Header("實際擁有的金錢")]
    public int RealMoney;
    public Text TheMoneyText1, TheMoneyText2, TheMoneyText3;
    public static Gamemanager instance;
    public int SceneNumber;
    public GameObject Setting;
    //public List<ta

    private void Start()
    {
        RealMoney = Data.RealMoney;
        SceneNumber = Data.Stage;
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
    public void NextStage()
    {
        SceneManager.LoadScene(SceneNumber);
        aud.PlayOneShot(click, 0.5f);          // 音源.播放一次(音效片段，音量)
    }
    /// <summary>
    /// 開啟設定介面
    /// </summary>
    public void OpenSetInteration()
    {
        Setting.SetActive(true);
        aud.PlayOneShot(click, 0.5f);          // 音源.播放一次(音效片段，音量)
    }
    /// <summary>
    /// 關閉設定介面
    /// </summary>
    public void CloseSetInteration()
    {
        Setting.SetActive(false);
        aud.PlayOneShot(click, 0.5f);          // 音源.播放一次(音效片段，音量)
    }
}    
