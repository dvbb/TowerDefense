using UnityEngine;


public class Bullet_Archer : Bullet
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void HitTarget()
    {
        base.HitTarget();
        AudioManager.Instance.EnemyHitted(SEs.bow);
    }
}
