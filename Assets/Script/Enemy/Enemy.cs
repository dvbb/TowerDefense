using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Enemy : MonoBehaviour
{
    public static Action OnEndReached;

    [SerializeField] protected float moveSpeed = 3f;
    [SerializeField] protected Waypoint waypoint;

    protected int _currentWaypointIndex = 0;
    protected Vector3 _currentPosition;

    protected virtual void Awake()
    {

    }

    protected virtual void Start()
    {
        _currentWaypointIndex = 0;
        _currentPosition = waypoint.GetWaypointPosition(_currentWaypointIndex);
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        Move();
    }

    protected virtual void Move()
    {
        if (_currentWaypointIndex == waypoint.Pointes.Length)
        {
            ReturnEnemyToPool();
            return;
        }
        _currentPosition = waypoint.GetWaypointPosition(_currentWaypointIndex); 
        transform.position = Vector3.MoveTowards(transform.position, _currentPosition, moveSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, _currentPosition) < .1f && _currentWaypointIndex < waypoint.Pointes.Length)
        {
            Debug.Log(_currentWaypointIndex);
            Debug.Log("waypoint.Pointes.Length:" + waypoint.Pointes.Length);
            _currentWaypointIndex++;
        }
    }

    protected virtual void ReturnEnemyToPool()
    {
        if (OnEndReached != null)
            OnEndReached.Invoke();
        ObjectPooler.ReturnToPool(gameObject);
    }
}
