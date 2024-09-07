using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class EnemyMoveState : EnemyState
{
    public EnemyMoveState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
    {
    }

    public override void AnimatorFinishTrigger()
    {
        base.AnimatorFinishTrigger();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (enemy.currentWaypointIndex == enemy.Waypoint.Pointes.Length)
        {
            enemy.ResetEnemy();
            enemy.ReturnEnemyToPool();
            return;
        }
        enemy.currentPosition = enemy.Waypoint.GetWaypointPosition(enemy.currentWaypointIndex);
        enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, enemy.currentPosition, enemy.moveSpeed * Time.deltaTime);
        if (Vector3.Distance(enemy.transform.position, enemy.currentPosition) < .1f && enemy.currentWaypointIndex < enemy.Waypoint.Pointes.Length)
        {
            enemy.currentWaypointIndex++;
        }
    }
}
