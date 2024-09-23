using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Header("Card info")]
    public string name;
    public int cost;
    public int atk;
    public int aspd;
    public string atkType;

    [Header("Resources")]
    public string imgPath;
    public string prefabPath;

    public bool isDragging;
    public Vector3 mousePosition;

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

    public void EnableSelcted()
    {
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
        button.onClick.AddListener(OnMouseDown);
        button.onClick.AddListener(OnMouseUp);
    }

    private void OnMouseDown()
    {
        isDragging = true;
        mousePosition = Input.mousePosition;
        Debug.Log(Input.mousePosition);
    }

    private void OnMouseUp()
    {
        isDragging = false;
        Debug.Log(Input.mousePosition);
        if (Input.mousePosition == mousePosition)
        {
            CardSelected();
        }
        else
        {
            Debug.Log("xx");
            Instantiate(Resources.Load(prefabPath));
        }
    }

    private void CardSelected()
    {
        if (CardManager.Instance.CurrentSelectedCard == this)
        {
            CardManager.Instance.UnSelecteCard();
        }
        else
        {
            CardManager.Instance.ChangeSelectedCard(this);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        throw new NotImplementedException();
    }
    public void OnDrag(PointerEventData eventData)
    {
        throw new NotImplementedException();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        throw new NotImplementedException();
    }
}
