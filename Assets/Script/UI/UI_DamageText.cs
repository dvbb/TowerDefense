using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.EventSystems.EventTrigger;

public class UI_DamageText : MonoBehaviour
{
    public TextMeshProUGUI text => GetComponentInChildren<TextMeshProUGUI>();

    public void ReturnToPool()
    {
        transform.SetParent(null);
        ObjectPooler.ReturnToPool(gameObject);
    }

}
