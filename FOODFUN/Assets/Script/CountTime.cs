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
    public static CountTime instance;
    public Image FireBall;
    public Button FireBallBtn;
    public float CD = 10 ;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        FileBar();
        CD += Time.deltaTime;
        if (CD >= 10)
        {
            FireBallBtn.interactable = true;
        }
        FireBall.fillAmount = CD / 10;
    }
    public void FileBar()
    {
        if (time == Leveltime) return;
        time += Time.deltaTime;
        TimeBar.fillAmount = time /Leveltime;
    }
    public void SkillCoolDown()
    {
        FireBallBtn.interactable = false;
        CD = 0;
    }
}
