using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public int lives = 10;

    [SerializeField] private int totalLives;

    private void Start()
    {
        lives = totalLives;
        UIManager.Instance.UpdateHealth();
    }

    private void ReduceLives()
    {
        lives--;
        UIManager.Instance.UpdateHealth();
        if (lives <= 0)
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
