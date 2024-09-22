using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using UnityEngine;

public class CardManager : UnitySingleton<CardManager>
{
    [SerializeField] private CardItem CardItemPrefab;
    [SerializeField] private Transform CardContent;

    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        for (int i = 3; i < 8; i++)
        {
            CardItem card = Instantiate(CardItemPrefab, CardContent);
            card.imgPath = $"Characters/char_{i}";
            card.cost = 100;
        }

    }
}
