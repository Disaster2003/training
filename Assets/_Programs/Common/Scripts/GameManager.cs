using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletonSample<GameManager>
{
    public enum STATE_SCENE
    {
        TITLE,  // タイトル画面
        PLAY,   // プレイ画面
        RESULT, // 結果画面
    }
    STATE_SCENE state_scene;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // シーン遷移による破壊の防止
        DontDestroyOnLoad(gameObject);

        // 状態の初期化
        state_scene = (STATE_SCENE)SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// 画面遷移を行う
    /// </summary>
    public STATE_SCENE ChangeScene
    {
        set {
            state_scene = value;
            SceneManager.LoadSceneAsync((int)state_scene);
        }
    }
}
