using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchInteratable : MonoBehaviour
{
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
    }
    public void OpenPlayer()
    {
        Player.SetActive(true);
        chooce.SetActive(false);
    }
    public void ClosePet()
    {
        chooce.SetActive(true);
        Pet.SetActive(false);
    }
    public void OpenPet()
    {
        Pet.SetActive(true);
        chooce.SetActive(false);
    }
    public void CloseCastle()
    {
        chooce.SetActive(true);
        Castle.SetActive(false);
    }
    public void OpenCastle()
    {
        Castle.SetActive(true);
        chooce.SetActive(false);
    }
}
