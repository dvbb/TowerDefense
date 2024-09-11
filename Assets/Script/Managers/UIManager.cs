using System.Collections.Generic;
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

    private Node _currentSelectedNode;

    public void CloseTurretShopPanel()
    {
        turretShopPanel.SetActive(false);
    }

    private void NodeSelected(Node selectedNode)
    {

        _currentSelectedNode = selectedNode;
        if (_currentSelectedNode.IsEmpty())
        {
            turretShopPanel.SetActive(true);
        }
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