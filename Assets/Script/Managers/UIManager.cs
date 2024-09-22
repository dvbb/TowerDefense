using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class UIManager : UnitySingleton<UIManager>
{
    //private Transform canvasTransform;
    private List<UIBase> uiList;

    protected override void Awake()
    {
        base.Awake();
        //canvasTransform = GameObject.Find("Canvas").transform;
        uiList = new List<UIBase>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UIBase escWindow = Find("EscWindow");
            if (escWindow == null)
            {
                Time.timeScale = 0;
                ShowUI<EscWindow>();
                return;
            }
            if (escWindow.isActiveAndEnabled)
            {
                Time.timeScale = 1f;
                HideUI("EscWindow");
            }
            else
            {
                Time.timeScale = 0;
                ShowUI<EscWindow>();
            }
        }
    }

    public UIBase ShowUI<T>() where T : UIBase
    {
        string uiName = typeof(T).Name;
        UIBase ui = Find(uiName);
        if (ui == null)
        {
            GameObject obj = Instantiate(Resources.Load("UI_Windows/" + uiName)) as GameObject;
            obj.name = uiName;
            ui = obj.AddComponent<T>();
            uiList.Add(ui);
        }
        else
        {
            ui.Show();
        }
        return ui;
    }

    public UIBase ShowUI<T>(string uiName) where T : UIBase
    {
        UIBase ui = Find(uiName);
        if (ui == null)
        {
            GameObject obj = Instantiate(Resources.Load("UI_Windows/" + uiName)) as GameObject;
            obj.name = uiName;
            ui = obj.AddComponent<T>();
            uiList.Add(ui);
        }
        else
        {
            ui.Show();
        }
        return ui;
    }

    public void HideUI(string uiName)
    {
        UIBase ui = Find(uiName);
        ui?.Hide();
    }

    public void HideUI<T>() where T: UIBase
    {
        UIBase ui = Find(typeof(T).Name);
        ui?.Hide();
    }

    public void CloseUI(string uiName)
    {
        UIBase ui = Find(uiName);
        if (ui != null)
        {
            uiList.Remove(ui);
            Destroy(ui.gameObject);
        }
    }

    public void CloseUI<T>() where T: UIBase
    {
        UIBase ui = Find(typeof(T).Name);
        if (ui != null)
        {
            uiList.Remove(ui);
            Destroy(ui.gameObject);
        }

    }
    public void CloseAllUI()
    {
        foreach (UIBase ui in uiList)
        {
            Destroy(ui.gameObject);
        }
        uiList.Clear();
    }
    
    public UIBase Find(string uiName)
    {
        for (int i = 0; i < uiList.Count; i++)
        {
            if (uiList[i].name == uiName)
                return uiList[i];
        }
        return null;
    }
    public UIBase Find<T>() where T : UIBase
    {
        for (int i = 0; i < uiList.Count; i++)
        {
            if (uiList[i].name == typeof(T).Name)
                return uiList[i];
        }
        return null;
    }
}