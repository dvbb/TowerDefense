using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencySystem : MonoBehaviour
{
    public static CurrencySystem instance;

    [SerializeField] private float cofloatest;
    private string CURRENCY_SAVE_KEY = "MYGAME_CURRENCY";

    public float TotalCoins { get; private set; }

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        AddCoins(cofloatest);
        LoadCoins();
        UIManager.Instance.UpdateTotalCoins(TotalCoins);
    }

    private void LoadCoins()
    {
        TotalCoins = PlayerPrefs.GetFloat(CURRENCY_SAVE_KEY);
    }

    public void AddCoins(float amount)
    {
        TotalCoins += amount;
        PlayerPrefs.SetFloat(CURRENCY_SAVE_KEY, TotalCoins);
        PlayerPrefs.Save();
        UIManager.Instance.UpdateTotalCoins(TotalCoins);
    }

    public void RemoveCoins(float amount)
    {
        if (TotalCoins >= amount)
        {
            TotalCoins -= amount;
            PlayerPrefs.SetFloat(CURRENCY_SAVE_KEY, TotalCoins);
            PlayerPrefs.Save();
            UIManager.Instance.UpdateTotalCoins(TotalCoins);
        }
    }
}
