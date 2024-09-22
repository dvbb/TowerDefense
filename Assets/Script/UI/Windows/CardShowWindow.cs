using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class CardShowWindow : UIBase
{
    private void Awake()
    {
        Image image  = GetComponentInChildren<Image>();
        Debug.Log(image);
        Debug.Log(image.sprite);
    }

    public void Init(string imgPath)
    {
    }
}
