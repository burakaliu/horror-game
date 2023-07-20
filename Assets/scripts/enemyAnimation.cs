using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAnimation : MonoBehaviour
{

    public Animator anim;
    public enemyAI enemyAI;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyAI.currentState == enemyAI.MonsterState.Idle)
        {
            anim.SetBool("isIdle", true);
            anim.SetBool("isWalking", false);
            anim.SetBool("isChasing", false);
        }else if (enemyAI.currentState == enemyAI.MonsterState.Alert)
        {
            anim.SetBool("isIdle", false);
            anim.SetBool("isWalking", true);
            anim.SetBool("isChasing", false);
        }
        else if (enemyAI.currentState == enemyAI.MonsterState.Chase)
        {
            anim.SetBool("isIdle", false);
            anim.SetBool("isChasing", true);
            anim.SetBool("isWalking", false);
        }

    }
}
