using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterattack : MonoBehaviour
{
    private Transform player;
    public float attackDistance = 2;        //這是攻擊目標的距離，也是尋路的目標距離
    private Animator animator;
    public float speed;
    private CharacterController cc;
    public float attackTime = 3;        //設定定時器時間 3秒攻擊一次
    private float attackCounter = 0;    //計時器變數

    private void Start () 
    {
        player = GameObject.Find("玩家").transform;
        cc = this.GetComponent<CharacterController>();
        animator = this.GetComponent<Animator>();       //控制動畫狀態機中的奔跑動作呼叫
        attackCounter = attackTime;         //一開始只要抵達目標立即攻擊

    }

    private void Update () 
    {
        Vector3 targetPos = player.position;

        targetPos.y = transform.position.y;     //此處的作用將自身的Y軸值賦值給目標Y值
        // transform.LookAt(targetPos);            //旋轉的時候就保證已自己Y軸為軸心旋轉

        float distance = Vector3.Distance(targetPos,transform.position);

        if (distance <= attackDistance)
        {
            attackCounter += Time.deltaTime;
            if (attackCounter > attackTime)      //定時器功能實現
            {
                animator.SetTrigger("monsterAttack");
                attackCounter = 0;
            }

            else
            {
                animator.SetBool("monsterWalk", false);
            }

        }

        else
        {
        attackCounter = attackTime;     //每次移動到最小攻擊距離時就會立即攻擊
        
            if(animator.GetCurrentAnimatorStateInfo(0).IsName("EnimyWalk"))
            //  EnimyWalk是動畫狀態機中的行走的狀態
                cc.SimpleMove(transform.forward*speed);

                animator.SetBool("monsterWalk ",true);     
                //移動的時候播放跑步動畫
        }

    }

}

