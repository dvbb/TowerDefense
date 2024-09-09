using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Turret : MonoBehaviour
{
    [SerializeField] private float attackRange = 3f;
    [SerializeField] private Transform spawnPosition;


    #region Component
    private ObjectPooler pooler;
    #endregion

    [Header("Attack info")]
    [SerializeField] private float coldDown;
    private float timer;

    private bool _isGameStarted;
    [SerializeField] public List<Enemy> EnemyTargets { get; private set; }

    private void Start()
    {

        pooler = GetComponent<ObjectPooler>();

        _isGameStarted = true;
        EnemyTargets = new List<Enemy>();
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0 && EnemyTargets.Count != 0)
        {
            timer = coldDown;
            LoadBullet();
        }
    }

    private float GetRotateAngle(Enemy enemy)
    {
        Vector3 targetPosition = enemy.transform.position - transform.position;
        float angle = Vector3.SignedAngle(transform.up, targetPosition, transform.forward);
        return angle; 
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

    private void LoadBullet()
    {
        GameObject newInstance = pooler.GetInstanceFromPool();
        newInstance.transform.localPosition = spawnPosition.position;

        Bullet bullet = newInstance.GetComponent<Bullet>();
        bullet.InitBullet(EnemyTargets.First());
        bullet.canMove = true;
        bullet.transform.Rotate(0, 0, 0);
        bullet.transform.Rotate(0, 0, GetRotateAngle(EnemyTargets.First()));

        newInstance.SetActive(true);
    }
}
