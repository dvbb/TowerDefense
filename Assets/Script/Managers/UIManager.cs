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

    [Header("Text")]
    [SerializeField] private TextMeshProUGUI upgradeText;
    [SerializeField] private TextMeshProUGUI sellText;
    [SerializeField] private TextMeshProUGUI LevelText;

    private Node _currentSelectedNode;

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
    #endregion

    private void NodeSelected(Node selectedNode)
    {
        Debug.Log(_currentSelectedNode?.Turret?.name);
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

    public void Upgrade()
    {
        _currentSelectedNode.Turret.Upgrage();
        UpdateText();
    }

    public void UpdateText()
    {
        LevelText.text = _currentSelectedNode.Turret.level.ToString();
        upgradeText.text = _currentSelectedNode.Turret.upgradeCost.ToString();
        sellText.text = (_currentSelectedNode.Turret.totalValue * .4f).ToString();
    }

    private void OnEnable()
    {
        Node.OnNodeSelected += NodeSelected;
    }

    private void OnDisable()
    {
        Node.OnNodeSelected -= NodeSelected;
    }
}