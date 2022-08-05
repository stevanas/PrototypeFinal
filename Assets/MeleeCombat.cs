using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeCombat : MonoBehaviour
{
    public bool isAttacking;
    Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            StartAttackAnimation();
        }
    }
    //attack animation start. while swinging the hitbox trigger is enabled(check swing animation)
    void StartAttackAnimation()
    {
        anim.SetTrigger("Swing");
    }
    //method to handle hitbox
    public void StartAttack()
    {
        if(!isAttacking)
        {
            isAttacking = true;
        }
    }
}
