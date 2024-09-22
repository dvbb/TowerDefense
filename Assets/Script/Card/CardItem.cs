using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardItem : MonoBehaviour
{
    public string imgPath;
    public string name;
    public int cost;

    private Button button;
    private TextMeshProUGUI textMeshPro;

    private void Awake()
    {
        textMeshPro = GetComponentInChildren<TextMeshProUGUI>();
        button = GetComponentInChildren<Button>();
    }

    private void Start()
    {
        button.GetComponent<Image>().sprite = Resources.Load<Sprite>(imgPath);
        textMeshPro.text = cost.ToString();
    }
}
