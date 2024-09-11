using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TurretCard : MonoBehaviour
{
    public static Action<TurretSettings> OnPlaceTurret;

    [SerializeField] private Image turretImage;
    [SerializeField] private TextMeshProUGUI turretCost;

    public TurretSettings turretLoaded { get; private set; }

    public void SetupTurretButton(TurretSettings settings)
    {
        turretLoaded = settings;
        turretImage.sprite = settings.TurretShopSprite;
        turretCost.text = settings.TurretShopCost.ToString();
    }

    public void PlaceTurret()
    {
        if (CurrencySystem.instance.TotalCoins >= turretLoaded.TurretShopCost)
        {
            CurrencySystem.instance.RemoveCoins(turretLoaded.TurretShopCost);
            OnPlaceTurret?.Invoke(turretLoaded);
        }
    }
}
