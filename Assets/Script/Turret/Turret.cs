using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.SubsystemsImplementation;
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
    [SerializeField] protected float damage = 10;

    [Header("Upgrade info")]
    [SerializeField] public float level = 1;
    [SerializeField] protected float upgradeAttackRange = .3f;
    [SerializeField] protected float upgradeColdDown = .2f;
    [SerializeField] protected float upgradeDamage = 5;
    [SerializeField] public float totalValue;
    [SerializeField] public float upgradeCost = 50;


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
            timer = GetColdDown();
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

        // Get target
        Enemy target = EnemyTargets.First();
        float distance = target.distanceToNextPoint;
        int flag = -1;
        for (int i = 0; i < EnemyTargets.Count; i++)
        {
            //Debug.Log("i  " + i +  "  "  + EnemyTargets[i].distanceToNextPoint);
            if (EnemyTargets[i].distanceToNextPoint <= distance && EnemyTargets[i].currentHealth > 0)
            {
                flag = i;
                target = EnemyTargets[i];
                distance = EnemyTargets[i].distanceToNextPoint;
            }
        }
        if (target.currentHealth <= 0)
            return;

        bullet.InitBullet(target, GetDamage());
        bullet.canMove = true;
        bullet.transform.Rotate(0, 0, 0);
        bullet.transform.Rotate(0, 0, GetRotateAngle(target));

        newInstance.SetActive(true);
    }

    public void Upgrage()
    {
        if (CurrencySystem.instance.TotalCoins >= upgradeCost)
        {
            CurrencySystem.instance.RemoveCoins(upgradeCost);
            level += 1;
            attackRange += upgradeAttackRange;
            upgradeCost += 20 * (level - 1);
            totalValue += upgradeCost;
        }
    }

    public void Sell()
    {
        CurrencySystem.instance.AddCoins(totalValue * .4f);
        Destroy(gameObject);
    }

    public float GetDamage() => damage + (level - 1) * upgradeDamage;
    public float GetColdDown() => coldDown - (level - 1) * upgradeColdDown;

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
