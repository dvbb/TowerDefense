using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class GameApp : UnitySingleton<GameApp>
{
    public void GameStart()
    {
        EnterGameScene();
    }

    public void EnterGameScene()
    {
        // Enter title window
        UIManager.Instance.ShowUI<TitleWindow>("TitleWindow");

        // add player

        // add ui
    }
}
