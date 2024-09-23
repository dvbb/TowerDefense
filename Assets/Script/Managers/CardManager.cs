using System.Linq;
using UnityEngine;

public class CardManager : UnitySingleton<CardManager>
{
    [SerializeField] private GameObject CardItemPrefab;
    [SerializeField] private RectTransform CardContent;

    public CardItem CurrentSelectedCard;

    protected override void Awake()
    {
        base.Awake();
        CardItemPrefab = Resources.Load("Card/CardItem") as GameObject;
    }

    private void Update()
    {
        // Drag card
        if (CurrentSelectedCard != null && CurrentSelectedCard.isDragging)
        {
            Debug.Log("xx");
        }
    }

    public void Init(RectTransform content)
    {
        CardContent = content;
    }

    public void GenerateTestCards()
    {
        for (int i = 3; i < 8; i++)
        {
            GameObject obj = Instantiate(CardItemPrefab, CardContent);
            CardItem card = obj.GetComponent<CardItem>();
            card.imgPath = $"Characters/char_{i}";
            card.cost = Random.Range(100, 200);
            card.atk = Random.Range(100, 200);
            card.aspd = Random.Range(50, 100);
            card.atkType = Random.Range(0, 100) > 50 ? "物理" : "魔法";
            card.prefabPath = "Turrets/archer_level_1";
        }
    }

    public void ChangeSelectedCard(CardItem newCard)
    {
        CurrentSelectedCard?.DisEnableSelcted();
        newCard.EnableSelcted();
        CurrentSelectedCard = newCard;
    }

    public void UnSelecteCard()
    {
        CurrentSelectedCard?.DisEnableSelcted();
        CurrentSelectedCard = null;
        UIManager.Instance.HideUI<CardShowWindow>();
    }
}
