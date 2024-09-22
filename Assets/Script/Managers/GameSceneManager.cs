using UnityEngine;
using UnityEngine.SceneManagement;

enum Scenes
{
    StartScene,
    EscScene,
}

public class GameSceneManager : UnitySingleton<GameSceneManager>
{
    protected override void Awake()
    {
        base.Awake();
    }

    private void Update()
    {

    }

    public void ToStartScene()
    {
        CameraController.Instance.InitMoveDistance(Vector2.zero, Vector2.zero);
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            if (SceneManager.GetSceneAt(i).name != "StartScene")
            {
                SceneManager.UnloadSceneAsync(SceneManager.GetSceneAt(i));
                Debug.Log(SceneManager.GetSceneAt(i).name);
            }
        }
        UIManager.Instance.HideUI<TitleWindow>();
        UIManager.Instance.ShowUI<TitleWindow>();
    }
    public void ToLevel1()
    {
        UIManager.Instance.CloseUI("ForestMapWindow");
        SceneManager.LoadScene("Level_1", LoadSceneMode.Additive);
        SceneManager.LoadScene("BattleAreaUI", LoadSceneMode.Additive);
        CameraController.Instance.InitMoveDistance(new Vector2(-1, -.5f), new Vector2(1, .5f));
    }
    public void ToLevel2()
    {
        UIManager.Instance.CloseUI("ForestMapWindow");
        SceneManager.LoadScene("Level_2", LoadSceneMode.Additive);
        SceneManager.LoadScene("BattleAreaUI", LoadSceneMode.Additive);
        CameraController.Instance.InitMoveDistance(new Vector2(-1, -.5f), new Vector2(1, .5f));
    }
    public void QuitGame() => Application.Quit();
}
