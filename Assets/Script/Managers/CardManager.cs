using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CardManager : UnitySingleton<CardManager>
{
    [SerializeField] private GameObject CardItemPrefab;
    [SerializeField] private RectTransform CardContent;

    public CardItem CurrentSelectedCard;
    private Camera MainCamera;

    protected override void Awake()
    {
        base.Awake();
        CardItemPrefab = Resources.Load("Card/CardItem") as GameObject;
        MainCamera = Camera.main;
    }

    private void Update()
    {
        if (CurrentSelectedCard == null)
            return;

        // Drag card
        if (CurrentSelectedCard.isDragging && CurrentSelectedCard.turret != null)
        {
            // TODO: use parameter
            float x = MainCamera.transform.position.x + (Input.mousePosition.x - 435) / 33;
            float y = MainCamera.transform.position.y + (Input.mousePosition.y - 245) / 33;
            CurrentSelectedCard.turret.transform.position = new Vector3(x, y);

        }

        // Cancle show card
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (CurrentSelectedCard.isDragging)
            {
                CurrentSelectedCard.StopPlaceTurret();
                CancelSelecteCard();
            }
            else
                CancelSelecteCard();
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

    public void CancelSelecteCard()
    {
        CurrentSelectedCard?.DisEnableSelcted();
        CurrentSelectedCard = null;
        UIManager.Instance.HideUI<CardShowWindow>();
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
