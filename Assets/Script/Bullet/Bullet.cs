using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;
using static UnityEngine.GraphicsBuffer;

public class Bullet : MonoBehaviour
{
    public static Action<Transform, float> OnEnemyHit;

    [Header("Bullet info")]
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float damage = 10;

    public Enemy Target { get; private set; }

    public bool canMove;

    protected virtual void Start()
    {

    }

    protected virtual void Update()
    {
        if (canMove)
            Move();
    }

    protected virtual void Move()
    {
        if (Target == null)
            return;
        transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, moveSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, Target.transform.position) < .1)
        {
            HitTarget();
        }
    }

    protected virtual void HitTarget()
    {
        Target.TakeDemage(damage);
        ObjectPooler.ReturnToPool(gameObject);
        RestBullet();
    }


    public void InitBullet(Enemy enemy)
    {
        Target = enemy;
    }

    public void RestBullet()
    {
        transform.localEulerAngles = Vector3.zero;
        canMove = false;
    }
}
