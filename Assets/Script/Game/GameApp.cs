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
        // add game map
        UIManager.Instance.ShowUI<Canva_Start>("Canva_Start");

        // add player

        // add ui
    }
}
