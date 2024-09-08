using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;

    public Enemy Target { get; private set; }

    private void Update()
    {
        
    }

    private void OnAnimatorMove()
    {
        
    }

    public void SetEnemy(Enemy enemy)
    {
        Target = enemy;
    }
}
