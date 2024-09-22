using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.EventSystems;
using UnityEngine;

public class ForestMapWindow : UIBase
{
    private void Awake()
    {
        Register("1-1").onClick = ToLevel1_1;
        Register("1-2").onClick = ToLevel1_2;

    }

    private void ToLevel1_1(GameObject obj, PointerEventData pdata)
    {
        GameSceneManager.Instance.ToLevel1();
    }
    private void ToLevel1_2(GameObject obj, PointerEventData pdata)
    {
        GameSceneManager.Instance.ToLevel2();
    }
    private void EnterNode(string name)
    {
    }
}
