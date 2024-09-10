using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TurretCard : MonoBehaviour
{
    [SerializeField] private Image turretImage;
    [SerializeField] private TextMeshProUGUI turretCost;


    public void SetupTurretButton(TurretSettings settings)
    {
        turretImage.sprite = settings.TurretShopSprite;
        turretCost.text = settings.TurretShopCost.ToString();
    }
}
