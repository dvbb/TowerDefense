using UnityEngine;
using UnityEngine.SceneManagement;

enum Scenes
{
    StartScene,
    EscScene,
}

public class MySceneManager : MonoBehaviour
{
    private MySceneManager Instance;

    [SerializeField] private bool isDebug;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsEscLoaded())
                UnloadEsc();
            else
                LoadEsc();
        }
        if (!isDebug)
        {
            Scene scene = SceneManager.GetActiveScene();
        }
    }

    private bool IsEscLoaded()
    {
        Scene[] scenes = SceneManager.GetAllScenes();
        foreach (Scene scene in scenes)
        {
            if (scene.name == Scenes.EscScene.ToString())
                return true;
        }
        return false;
    }

    public void ToStartScene() => SceneManager.LoadScene(Scenes.StartScene.ToString());
    public void LoadEsc()
    {
        Time.timeScale = 0;
        SceneManager.LoadScene(Scenes.EscScene.ToString(), LoadSceneMode.Additive);
    }
    public void UnloadEsc()
    {
        UIManager.Instance.ResetSpeed();
        SceneManager.UnloadSceneAsync(Scenes.EscScene.ToString());
    }
    public void ToMap() => SceneManager.LoadScene("Map");
    public void ToLevel1()
    {
        SceneManager.LoadScene("Level_1");
        SceneManager.LoadScene("BattleAreaUI", LoadSceneMode.Additive);

    }
    public void ToLevel2()
    {
        SceneManager.LoadScene("Level_2");
        SceneManager.LoadScene("BattleAreaUI", LoadSceneMode.Additive);
    }
    public void QuitGame() => Application.Quit();
}
