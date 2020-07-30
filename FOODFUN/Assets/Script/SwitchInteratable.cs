using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchInteratable : MonoBehaviour
{
    [Header("音效區域")]
    public AudioSource aud;
    public AudioClip click;
    public GameObject chooce,Player,Pet,Castle;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ClosePlayer()
    {
        chooce.SetActive(true);
        Player.SetActive(false);
        aud.PlayOneShot(click, 0.5f);          // 音源.播放一次(音效片段，音量)
    }
    public void OpenPlayer()
    {
        Player.SetActive(true);
        chooce.SetActive(false);
        aud.PlayOneShot(click, 0.5f);          // 音源.播放一次(音效片段，音量)
    }
    public void ClosePet()
    {
        chooce.SetActive(true);
        Pet.SetActive(false);
        aud.PlayOneShot(click, 0.5f);          // 音源.播放一次(音效片段，音量)
    }
    public void OpenPet()
    {
        Pet.SetActive(true);
        chooce.SetActive(false);
        aud.PlayOneShot(click, 0.5f);          // 音源.播放一次(音效片段，音量)
    }
    public void CloseCastle()
    {
        chooce.SetActive(true);
        Castle.SetActive(false);
        aud.PlayOneShot(click, 0.5f);          // 音源.播放一次(音效片段，音量)
    }
    public void OpenCastle()
    {
        Castle.SetActive(true);
        chooce.SetActive(false);
        aud.PlayOneShot(click, 0.5f);          // 音源.播放一次(音效片段，音量)
    }
}
