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
    [Header("Card info")]
    public string imgPath;
    public string name;
    public int cost;
    public int atk;
    public int aspd;
    public string atkType;

    #region Components
    private Button button;
    private TextMeshProUGUI textMeshPro;
    private RectTransform rectTransform;
    #endregion


    private void Awake()
    {
        button = GetComponentInChildren<Button>();
        textMeshPro = GetComponentInChildren<TextMeshProUGUI>();
        RectTransform[] transforms = GetComponentsInChildren<RectTransform>();
        foreach (var t in transforms)
        {
            if (t.name == "Button")
                rectTransform = t;
        }
    }

    private void Start()
    {
        button.GetComponent<Image>().sprite = Resources.Load<Sprite>(imgPath);
        textMeshPro.text = cost.ToString();
    }

    private void CardSelected()
    {
        if (CardManager.Instance.CurrentSelectedCard != this)
        {
            Debug.Log("selecte a card, use CardManager.Instance");
            CardManager.Instance.ChangeSelectedCard(this);
        }
    }

    public void EnableSelcted()
    {
        Debug.Log("before change:" + rectTransform.transform.position);
        rectTransform.transform.position = rectTransform.transform.position + new Vector3(0, 20, 0);
        var CardShowWindow = UIManager.Instance.ShowUI<CardShowWindow>();
        SelectedCard selectedCard = UIManager.Instance.FindUIWindowComponentInChildren<SelectedCard>(CardShowWindow);
        selectedCard.Init(imgPath, atk.ToString(), aspd.ToString(), atkType);
    }

    public void DisEnableSelcted()
    {
        rectTransform.transform.position = rectTransform.transform.position - new Vector3(0, 20, 0);
    }

    private void OnEnable()
    {
        button.onClick.AddListener(CardSelected);
    }
}
