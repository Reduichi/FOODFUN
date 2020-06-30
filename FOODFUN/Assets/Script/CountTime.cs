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
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        FileBar();
    }
    public void FileBar()
    {
        if (time == Leveltime) return;
        time += Time.deltaTime;
        TimeBar.fillAmount = time /Leveltime;
    }
}
