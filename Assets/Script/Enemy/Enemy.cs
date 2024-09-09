using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using static UnityEngine.EventSystems.EventTrigger;

public class Enemy : MonoBehaviour
{
    public static Action OnEndReached;

    [SerializeField] public Transform demageTextPosition;

    [Header("Basic info")]
    [SerializeField] public float moveSpeed = 3f;
    [SerializeField] public float maxHealth;
    public float currentHealth;

    public Waypoint Waypoint { get; set; }

    public int nextWaypointIndex = 0;
    public Vector3 currentPosition;
    public float facingDir = 1;

    #region Components
    public Animator Anim { get; private set; }
    public EntityFx fx { get; private set; }
    public SpriteRenderer sr { get; private set; }
    #endregion

    #region States
    public EnemyStateMachine StateMachine;
    public EnemyMoveState moveState { get; private set; }
    public EnemyHurtState hurtState { get; private set; }
    public EnemyDieState dieState { get; private set; }
    #endregion

    protected virtual void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        Anim = GetComponent<Animator>();

        StateMachine = new EnemyStateMachine();
        moveState = new EnemyMoveState(this, StateMachine, "Move");
        hurtState = new EnemyHurtState(this, StateMachine, "Hurt");
        dieState = new EnemyDieState(this, StateMachine, "Die");

    }

    protected virtual void Start()
    {
        //fx = GetComponent<EntityFx>();

        ResetEnemy();
        StateMachine.Initialize(moveState);
    }

    protected virtual void Update()
    {
        StateMachine.currentState.Update();

        if (Input.GetKeyDown(KeyCode.E))
        {
            TakeDemage(5);
        }
    }

    public void ResetEnemy()
    {
        nextWaypointIndex = 0;
        currentPosition = Waypoint.GetWaypointPosition(nextWaypointIndex);
        currentHealth = maxHealth;
        gameObject.transform.position = Waypoint.Pointes[0];
    }

    public virtual void TakeDemage(float demage)
    {
        currentHealth -= demage;
        Bullet.OnEnemyHit?.Invoke(demageTextPosition, demage);
        StateMachine.ChangeState(hurtState);
        if (currentHealth <= 0)
        {
            StateMachine.ChangeState(dieState);
        }
    }

    public virtual void Die()
    {
        ReturnEnemyToPool();
    }

    public virtual void ReturnEnemyToPool()
    {
        if (OnEndReached != null)
            OnEndReached.Invoke();
        ObjectPooler.ReturnToPool(gameObject);
    }

    public virtual void Flip()
    {
        sr.flipX = sr.flipX ? false : true;
        facingDir *= -1;
    }

    public virtual void AnimationFinishTrigger() => StateMachine.currentState.AnimatorFinishTrigger();
}
