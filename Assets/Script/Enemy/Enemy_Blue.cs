using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBlue : Enemy
{
    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();
        moveSpeed = 4f;
    }

    protected override void Update()
    {
        base.Update();
    }
}
