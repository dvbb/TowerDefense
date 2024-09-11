using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencySystem : MonoBehaviour
{
    public static CurrencySystem instance;

    [SerializeField] private int coinTest;
    private string CURRENCY_SAVE_KEY = "MYGAME_CURRENCY";

    public int TotalCoins { get; private set; }

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        Debug.Log("start: " + coinTest);
        AddCoins(coinTest);
        LoadCoins();
        Debug.Log("start end: " + TotalCoins);
    }

    private void LoadCoins()
    {
        TotalCoins = PlayerPrefs.GetInt(CURRENCY_SAVE_KEY);
    }

    public void AddCoins(int amount)
    {
        TotalCoins += amount;
        PlayerPrefs.SetInt(CURRENCY_SAVE_KEY, TotalCoins);
        PlayerPrefs.Save();
    }

    public void RemoveCoins(int amount)
    {
        if (TotalCoins >= amount)
        {
            TotalCoins -= amount;
            PlayerPrefs.SetInt(CURRENCY_SAVE_KEY, TotalCoins);
            PlayerPrefs.Save();
        }
    }
}
