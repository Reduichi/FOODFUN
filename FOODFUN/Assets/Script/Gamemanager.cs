using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    [Header("鳳梨")]
    public GameObject pineapple;    // GameObject 可以存放預置物以及場景上的物件

    private void Start()
    {
        InvokeRepeating("Pineapple", 0, 5f);
    }
    private void Pineapple()
    {
        Vector3 pos = new Vector3(27.63f, -0.44f, 0);
        Quaternion rot = new Quaternion(0, 0, 0, 0);
        Instantiate(pineapple, pos, rot);
    }


}
