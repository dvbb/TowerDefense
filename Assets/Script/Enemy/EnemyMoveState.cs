using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class EnemyMoveState : EnemyState
{
    private Vector3 from;
    private Vector3 to;

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
        if (enemy.nextWaypointIndex == enemy.Waypoint.Pointes.Length)
        {
            enemy.ReturnEnemyToPool();
            return;
        }
        to = enemy.Waypoint.GetWaypointPosition(enemy.nextWaypointIndex);

        if (enemy.transform.position.x > to.x && enemy.facingDir == 1)
            enemy.Flip();
        else if (enemy.transform.position.x < to.x && enemy.facingDir == -1)
            enemy.Flip();

        enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, to, enemy.moveSpeed * Time.deltaTime);
        enemy.distanceToNextPoint = Vector3.Distance(enemy.transform.position, to);
        if (enemy.distanceToNextPoint < .1f && enemy.nextWaypointIndex < enemy.Waypoint.Pointes.Length)
        {
            enemy.nextWaypointIndex++;
        }
    }
}
