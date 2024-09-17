using UnityEngine;

public class EnemyDieState : EnemyState
{
    public EnemyDieState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
    {
    }

    public override void AnimatorFinishTrigger()
    {
        base.AnimatorFinishTrigger();
    }

    public override void Enter()
    {
        CurrencySystem.instance.AddCoins(enemy.fallingCoin);
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

    }
}
