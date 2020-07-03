using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountTime : MonoBehaviour
{
    [Header("時間條")]
    public Image TimeBar;
    [Header("現在時間")]
    public float time;
    [Header("關卡總時間")]
    public float Leveltime;
    [Header("火球")]
    public Image FireBall;
    public Button FireBallBtn;
    public float FireCD = 10 ;
    private float FireCoolTime;
    [Header("閃電")]
    public Image LightningBall;
    public Button LightningBtn;
    public float LightningCD = 10 ;
    private float LightningCoolTime;
    public static CountTime instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        FireCoolTime = FireCD;
        LightningCoolTime = LightningCD;
    }

    // Update is called once per frame
    void Update()
    {
        FileBar();
        //火球冷卻圖片
        FireCoolTime += Time.deltaTime;
        if (FireCoolTime >= FireCD)
        {
            FireBallBtn.interactable = true;
        }
        FireBall.fillAmount = FireCoolTime / FireCD;

        //閃電冷卻圖片
        LightningCoolTime += Time.deltaTime;
        if (LightningCoolTime >= LightningCD)
        {
            LightningBtn.interactable = true;
        }
        LightningBall.fillAmount = LightningCoolTime / LightningCD;
    }
    /// <summary>
    /// 控制關卡進度條
    /// </summary>
    public void FileBar()
    {
        if (time == Leveltime) return;
        time += Time.deltaTime;
        TimeBar.fillAmount = time /Leveltime;
    }
    /// <summary>
    /// 火球技能冷卻
    /// </summary>
    public void FireSkillCoolDown()
    {
        FireBallBtn.interactable = false;
        FireCoolTime = 0;
    }
    /// <summary>
    /// 閃電技能冷卻
    /// </summary>
    public void LightningSkillCoolDown()
    {
        LightningBtn.interactable = false;
        LightningCoolTime = 0;
    }
}
