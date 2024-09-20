using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class GameLauch : UnitySingleton<GameLauch>
{
    protected override void Awake()
    {
        base.Awake();

        // Add new Components
        this.gameObject.AddComponent<GameApp>();
    }

    private void Start()
    {
        GameApp.Instance.GameStart();
    }
}
