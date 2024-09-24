using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BattleAreaUIManager : MonoBehaviour
{
    public static BattleAreaUIManager Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        CurrencySystem.instance.AddCoins(500);
    }

    [Header("Buttom")]
    [SerializeField] private GameObject SpeedButton;
    private TextMeshProUGUI speedText;
    [SerializeField] private GameObject StartButton;

    [Header("Text")]
    [SerializeField] private TextMeshProUGUI TotalCoins;
    [SerializeField] private TextMeshProUGUI Waves;
    [SerializeField] private TextMeshProUGUI Health;

    private int _wave = 1;
    private Node _currentSelectedNode;

    private void Update()
    {
    }

    #region UnityButtonEvent
    public void SpeedButtonClickEvent()
    {
        switch (Time.timeScale)
        {
            case 0:
                Time.timeScale = 1;
                speedText.text = "X1";
                break;
            case 1:
                Time.timeScale = 2;
                speedText.text = "X2";
                break;
            case 2:
                Time.timeScale = 1;
                speedText.text = "X1";
                break;
            default:
                break;
        }
    }
    public void StopButtonClickEvent()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            speedText.text = "X1";
        }
        else
        {
            Time.timeScale = 0;
            speedText.text = "0";
        }
    }
    #endregion

    private void Start()
    {
        speedText = SpeedButton.GetComponentInChildren<TextMeshProUGUI>();
    }

    public void UpdateTotalCoins(float coins)
    {
        TotalCoins.text = coins.ToString();
    }

    public void UpdateHealth() => Health.text = LevelManager.instance.lives.ToString();
    public void UpdateWaves() => Waves.text = $"Wave {++_wave}";
    public void ResetSpeed()
    {
        Time.timeScale = 1;
        speedText.text = "X1";
    }

    private void OnEnable()
    {
    }

    private void OnDisable()
    {
    }
}