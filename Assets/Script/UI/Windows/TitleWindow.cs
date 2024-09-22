using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

public class TitleWindow : UIBase
{
    private void Awake()
    {
        Register("Buttons_Panel/Start").onClick = onStartGameBtn;
        Register("Buttons_Panel/Continue").onClick = onContinueGameBtn;
        Register("Buttons_Panel/End").onClick = onEndGameBtn;
    }

    private void onStartGameBtn(GameObject obj, PointerEventData pdata)
    {
        UIManager.Instance.HideUI("TitleWindow");
        UIManager.Instance.ShowUI<ForestMapWindow>("ForestMapWindow");
    }

    private void onContinueGameBtn(GameObject obj, PointerEventData pdata)
    {
        Close();
    }

    private void onEndGameBtn(GameObject obj, PointerEventData pdata)
    {
        Application.Quit();
    }
}