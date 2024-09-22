using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEditor;
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
        button = GetComponentInChildren<Button>();
        textMeshPro = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Start()
    {
        button.GetComponent<Image>().sprite = Resources.Load<Sprite>(imgPath);
        textMeshPro.text = cost.ToString();
    }

    private void CardSelected()
    {
        var CardShowWindow = UIManager.Instance.ShowUI<CardShowWindow>();
        Image image = UIManager.Instance.FindUIWindowComponentInChildren<Image>(CardShowWindow);
        image.sprite = Resources.Load<Sprite>(imgPath);
    }

    private void OnEnable()
    {
        button.onClick.AddListener(CardSelected);
    }
}
