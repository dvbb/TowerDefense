using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_AnimationTrigger : MonoBehaviour
{
    private Enemy enemy => GetComponent<Enemy>();

    private void AnimationTrigger()
    {
        enemy.AnimationFinishTrigger();
    }

    private IEnumerator HurtAnimationTrigger()
    {
        yield return new WaitForSeconds(.1f);
        enemy.StateMachine.ChangeState(enemy.moveState);
    }

    private IEnumerator DeadAnimationTrigger()
    {
        yield return new WaitForSeconds(.1f);
        enemy.Die();
    }
}
