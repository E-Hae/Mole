using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hole : MonoBehaviour
{
    public Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnMouseDown()
    {
        if (!GameManager.instance.IsGameOver)
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("A_open") ||
                animator.GetCurrentAnimatorStateInfo(0).IsName("A_idle") ||
                animator.GetCurrentAnimatorStateInfo(0).IsName("B_open") ||
                animator.GetCurrentAnimatorStateInfo(0).IsName("B_idle") ||
                animator.GetCurrentAnimatorStateInfo(0).IsName("C_open") ||
                animator.GetCurrentAnimatorStateInfo(0).IsName("C_idle"))
            {
                GameManager.instance.badMoleCount++;
                animator.SetTrigger("Catch");
            }
            else if (animator.GetCurrentAnimatorStateInfo(0).IsName("D_open") ||
                     animator.GetCurrentAnimatorStateInfo(0).IsName("D_idle"))
            {
                GameManager.instance.goodMoleCount++;
                animator.SetTrigger("Catch");
            }
        }
    }
}