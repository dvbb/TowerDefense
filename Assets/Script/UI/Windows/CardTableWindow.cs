using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class CardTableWindow : UIBase
{
    private void Awake()
    {
        RectTransform[] transforms = GetComponentsInChildren<RectTransform>();
        foreach (var item in transforms)
        {
            if (item.name == "content")
            {
                CardManager.Instance.Init(item);
            }
        }

        CardManager.Instance.GenerateTestCards();

        //Init();
    }
}
