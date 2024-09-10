using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Turret : MonoBehaviour
{
    #region Component
    protected ObjectPooler pooler;
    #endregion

    [SerializeField] protected Transform spawnPosition;

    [Header("Attack info")]
    [SerializeField] protected float coldDown;
    [SerializeField] protected float attackRange = 3f;

    [SerializeField] public List<Enemy> EnemyTargets { get; private set; }

    protected float timer;
    protected bool _isGameStarted;

    protected virtual void Start()
    {
        pooler = GetComponent<ObjectPooler>();

        _isGameStarted = true;
        EnemyTargets = new List<Enemy>();
    }

    protected virtual void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0 && EnemyTargets.Count != 0)
        {
            timer = coldDown;
            LoadBullet();
        }
    }

    protected virtual float GetRotateAngle(Enemy enemy)
    {
        Vector3 targetPosition = enemy.transform.position - transform.position;
        float angle = Vector3.SignedAngle(transform.up, targetPosition, transform.forward);
        return angle;
    }

    protected virtual void LoadBullet()
    {
        GameObject newInstance = pooler.GetInstanceFromPool();
        newInstance.transform.localPosition = spawnPosition.position;

        Bullet bullet = newInstance.GetComponent<Bullet>();

        Enemy target = EnemyTargets.First();
        float distance = target.distanceToNextPoint;
        for (int i = 0; i < EnemyTargets.Count; i++)
        {
            if (EnemyTargets[i].distanceToNextPoint <= distance)
            {
                target = EnemyTargets[i];
            }
        }

        bullet.InitBullet(target);
        bullet.canMove = true;
        bullet.transform.Rotate(0, 0, 0);
        bullet.transform.Rotate(0, 0, GetRotateAngle(target));

        newInstance.SetActive(true);
    }

    #region Gizmos
    private void OnDrawGizmos()
    {
        if (_isGameStarted)
            GetComponent<CircleCollider2D>().radius = attackRange;
    }
    #endregion
    #region Collision
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>() != null)
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
    #endregion

}
