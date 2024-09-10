using UnityEngine;

public class Bullet_Wizard : Bullet
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
        Target.EnableSlowStats();
    }
}
