using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    [Header("Panels")]
    [SerializeField] private GameObject turretShopPanel;
    [SerializeField] private GameObject nodeUiPanel;
    [SerializeField] private GameObject achievementPanel;

    [Header("Text")]
    [SerializeField] private TextMeshProUGUI upgradeText;
    [SerializeField] private TextMeshProUGUI sellText;
    [SerializeField] private TextMeshProUGUI LevelText;
    [SerializeField] private TextMeshProUGUI TotalCoins;
    [SerializeField] private TextMeshProUGUI Waves;
    [SerializeField] private TextMeshProUGUI Health;

    private int _wave = 1;
    private Node _currentSelectedNode;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
            ShowAchievementPanel();
    }

    #region Show/Close ui
    public void CloseTurretShopPanel()
    {
        turretShopPanel.SetActive(false);
    }
    public void ShowNodeUiPanel()
    {
        nodeUiPanel.SetActive(true);
        UpdateText();
    }
    public void CloseNodeUiPanel()
    {
        nodeUiPanel.SetActive(false);
    }
    public void ShowAchievementPanel()
    {
        if (achievementPanel.active)
            achievementPanel.SetActive(false);
        else
            achievementPanel.SetActive(true);
    }
    #endregion

    #region UnityButtonEvent
    public void Upgrade()
    {
        _currentSelectedNode.Turret.Upgrage();
        UpdateText();
    }
    public void SellTurret()
    {
        _currentSelectedNode.Turret.Sell();
        _currentSelectedNode.Turret = null;
        CloseNodeUiPanel();
    }
    #endregion

    private void NodeSelected(Node selectedNode)
    {
        _currentSelectedNode = selectedNode;
        if (_currentSelectedNode.IsEmpty())
        {
            turretShopPanel.SetActive(true);
        }
        else
        {
            ShowNodeUiPanel();
        }
    }

    public void UpdateText()
    {
        LevelText.text = $"Level - {_currentSelectedNode.Turret.level.ToString()}";
        upgradeText.text = _currentSelectedNode.Turret.upgradeCost.ToString();
        sellText.text = (_currentSelectedNode.Turret.totalValue * .4f).ToString();
    }

    public void UpdateTotalCoins(float coins)
    {
        TotalCoins.text = coins.ToString();
    }

    public void UpdateHealth() => Health.text = LevelManager.instance.lives.ToString();
    public void UpdateWaves() => Waves.text = $"Wave {++_wave}";


    private void OnEnable()
    {
        Node.OnNodeSelected += NodeSelected;
    }

    private void OnDisable()
    {
        Node.OnNodeSelected -= NodeSelected;
    }
}