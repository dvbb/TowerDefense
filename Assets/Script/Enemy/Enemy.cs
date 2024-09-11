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
    [SerializeField] protected float defaultSpeed = 3f;
    public float moveSpeed;
    [SerializeField] public float maxHealth;
    public float currentHealth;
    [SerializeField] public int fallingCoin = 5;

    public Waypoint Waypoint { get; set; }

    protected float statTimer;
    public int nextWaypointIndex = 0;
    public Vector3 currentPosition;
    public float facingDir = 1;
    public float distanceToNextPoint;

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
        InitEnemyComponent();
    }

    protected virtual void Start()
    {
        //fx = GetComponent<EntityFx>();

        ResetEnemy();
        StateMachine.Initialize(moveState);
    }

    protected virtual void Update()
    {
        statTimer-= Time.deltaTime;
        if (statTimer < 0)
            DisableSlowStats();

        StateMachine.currentState.Update();

        if (Input.GetKeyDown(KeyCode.E))
        {
            TakeDemage(5);
        }
    }

    public void ResetEnemy()
    {
        StateMachine.Initialize(moveState);
        nextWaypointIndex = 0;
        currentPosition = Waypoint.GetWaypointPosition(nextWaypointIndex);
        currentHealth = maxHealth;
        gameObject.transform.position = Waypoint.Pointes[0] + Waypoint.CurrentPosition;
        DisableSlowStats();
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

    public void InitEnemyComponent()
    {
        sr = GetComponent<SpriteRenderer>();
        Anim = GetComponent<Animator>();

        StateMachine = new EnemyStateMachine();
        moveState = new EnemyMoveState(this, StateMachine, "Move");
        hurtState = new EnemyHurtState(this, StateMachine, "Hurt");
        dieState = new EnemyDieState(this, StateMachine, "Die");

        moveSpeed = defaultSpeed;
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

    public virtual void EnableSlowStats()
    {
        Anim.speed = .5f;
        moveSpeed *= .5f;
        sr.color = Color.blue;
        statTimer = 2f;
    }

    public virtual void DisableSlowStats()
    {
        Anim.speed = 1;
        moveSpeed = defaultSpeed;
        sr.color = Color.white;
    }

    public virtual void AnimationFinishTrigger() => StateMachine.currentState.AnimatorFinishTrigger();
}
