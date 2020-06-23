using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountTime : MonoBehaviour
{
    [Header("時間條")]
    public Image TimeBar;
    [Header("時間")]
    public float time;
    private float Percent;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
        FileBar();
    }
    public void FileBar()
    {
        if (time == 60) return;
        time += Time.deltaTime;
        TimeBar.fillAmount = time /60;
    }
}
