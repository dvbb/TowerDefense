using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.EventSystems.EventTrigger;

public class UI_HealthBar : MonoBehaviour
{
    private Enemy enemy;
    private RectTransform myTransform;
    private Slider slider;

    private void Start()
    {
        myTransform = GetComponent<RectTransform>();
        enemy = GetComponentInParent<Enemy>();
        slider = GetComponentInChildren<Slider>();

        UpdateHealthUI();
    }

    private void Update()
    {
        UpdateHealthUI();
    }

    private void UpdateHealthUI()
    {
        slider.maxValue = enemy.maxHealth;
        slider.value = enemy.currentHealth;
    }

    /// <summary>
    /// when character flip, also flip UI
    /// </summary>
    private void FlipUI()
    {
        myTransform.Rotate(0, 180, 0);
    }

    //private void OnDisable()
    //{
    //    entity.OnFlipped -= FlipUI;
    //    myStats.onHealthChanged -= UpdateHealthUI;
    //}
}
