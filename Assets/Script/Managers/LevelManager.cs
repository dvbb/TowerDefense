using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private int lives = 10;

    public int totalLive { get; private set; }

    private void Start()
    {
        totalLive = lives;
    }

    private void ReduceLives()
    {
        totalLive--;
        if (totalLive <= 0)
        {
            Debug.Log("Game over");
        }
    }

    private void OnEnable()
    {
        Enemy.OnEndReached += ReduceLives;
    }

    private void OnDisable()
    {
        Enemy.OnEndReached -= ReduceLives;
    }
}
