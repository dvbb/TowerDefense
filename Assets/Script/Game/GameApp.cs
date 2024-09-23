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
        // Play BGM
        BgmManager.Instance.PlayBgm("TestBGM");

        // Enter title window
        UIManager.Instance.ShowUI<TitleWindow>();
        UIManager.Instance.ShowUI<CardTableWindow>();

        // add player


        // add ui
    }
}
