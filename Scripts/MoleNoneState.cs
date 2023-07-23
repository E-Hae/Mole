using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleNoneState : StateMachineBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetInteger("Moletype", 0);
        animator.gameObject.GetComponent<Hole>().StartCoroutine(SetMoleTypeCoroutine(animator));
    }

    private IEnumerator SetMoleTypeCoroutine(Animator animator)
    {
        if (!GameManager.instance.IsGameOver)
        {
            float waitTime = Random.Range(0.5f, 4.5f);
            yield return new WaitForSeconds(waitTime);
            animator.SetInteger("Moletype", Random.Range(1, 5));
        }
    }
}