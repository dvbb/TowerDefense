using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectedCard : MonoBehaviour
{
    private Image image;
    private TextMeshProUGUI TMP_ATK;
    private TextMeshProUGUI TMP_ASPD;
    private TextMeshProUGUI TMP_AtkType;

    private void Awake()
    {
        image = GetComponent<Image>();
        TextMeshProUGUI[] tmps = GetComponentsInChildren<TextMeshProUGUI>();
        TMP_ATK = tmps[0];
        TMP_ASPD = tmps[1];
        TMP_AtkType = tmps[2];
    }

    public void Init(string imgPath, string atk, string aspd, string atkType)
    {
        image.sprite = Resources.Load<Sprite>(imgPath);
        TMP_ATK.text = "攻击力: " + atk;
        TMP_ASPD.text = "攻速: " + aspd;
        TMP_AtkType.text = "伤害类型: " + atkType;
    }
}
