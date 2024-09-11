using System.Collections.Generic;
using UnityEngine;

public class TurretShopManager : MonoBehaviour
{
    [SerializeField] private GameObject turretCardPrefab;
    [SerializeField] private Transform turretPanelContainer;

    [Header("Turret Settings")]
    [SerializeField] private TurretSettings[] turrets;

    private Node _currentSelectedNode;

    private void Start()
    {
        for (int i = 0; i < turrets.Length; i++)
            CreateTurretCard(turrets[i]);
    }

    private void CreateTurretCard(TurretSettings settings)
    {
        GameObject newInstance = Instantiate(turretCardPrefab, turretPanelContainer.position, Quaternion.identity);
        newInstance.transform.SetParent(turretPanelContainer);
        newInstance.transform.localScale = Vector3.one;

        TurretCard cardButton = newInstance.GetComponent<TurretCard>();
        cardButton.SetupTurretButton(settings);
    }

    private void NodeSelected(Node selectedNode)
    {
        _currentSelectedNode = selectedNode;
    }

    private void PlaceTurret(TurretSettings turretLoaded)
    {
        if (_currentSelectedNode != null)
        {
            GameObject turretInstance = Instantiate(turretLoaded.TurretPrefab);
            turretInstance.transform.localPosition = _currentSelectedNode.transform.position;

            Turret turretPlaced = turretInstance.GetComponent<Turret>();
            _currentSelectedNode.SetTurret(turretPlaced);

            UIManager.Instance.CloseTurretShopPanel();
        }
    }

    private void OnEnable()
    {
        Node.OnNodeSelected += NodeSelected;
        TurretCard.OnPlaceTurret += PlaceTurret;
    }

    private void OnDisable()
    {
        Node.OnNodeSelected -= NodeSelected;
        TurretCard.OnPlaceTurret -= PlaceTurret;
    }
}