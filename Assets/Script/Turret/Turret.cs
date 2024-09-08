using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private float attackRange = 3f;

    [SerializeField] public List<Enemy> EnemyTargets { get; private set; }

    private bool _isGameStarted;

    private void Start()
    {
        _isGameStarted = true;
        EnemyTargets = new List<Enemy>();
    }

    private void Update()
    {

    }

    private void RotateTowardsTarget(Enemy enemy)
    {
        Vector3 targetPosition = enemy.transform.position - transform.position;
        float angle = Vector3.SignedAngle(transform.up, targetPosition, transform.forward);
        transform.Rotate(0, 0, angle);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Enemy target = collision.GetComponent<Enemy>();
            EnemyTargets.Add(target);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>() != null)
        {
            Enemy target = collision.GetComponent<Enemy>();
            if (EnemyTargets.Contains(target))
                EnemyTargets.Remove(target);
        }
    }

    private void OnDrawGizmos()
    {
        if (_isGameStarted)
            GetComponent<CircleCollider2D>().radius = attackRange;
    }
}
