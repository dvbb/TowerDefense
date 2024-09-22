using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class GameLauch : UnitySingleton<GameLauch>
{
    protected override void Awake()
    {
        Debug.Log("==Game lauch awake==");
        base.Awake();

        // 1. Add new Components
        // 1.1 Basic components
        this.gameObject.AddComponent<GameApp>();
        this.gameObject.AddComponent<UIManager>();
        this.gameObject.AddComponent<GameSceneManager>();

        // 1.2 Audio
        this.gameObject.AddComponent<AudioSource>();
        this.gameObject.AddComponent<BgmManager>();
    }

    private void Start()
    {
        Debug.Log("==Game lauch start==");
        GameApp.Instance.GameStart();
    }
}
