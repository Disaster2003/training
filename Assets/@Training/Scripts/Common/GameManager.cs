using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 画面状態管理クラス
/// </summary>
public class GameManager : MonoBehaviour
{
    /// <summary>
    /// シングルトン用インスタンス
    /// </summary>
    static GameManager instance;

    /// <summary>
    /// インスタンスを取得する
    /// </summary>
    public static GameManager Instance { get => instance; }

    public enum StateScene
    {
        /// <summary>
        /// タイトル画面
        /// </summary>
        Title,

        /// <summary>
        /// プレイ画面
        /// </summary>
        Play,

        /// <summary>
        /// 結果画面
        /// </summary>
        Result,
    }

    StateScene stateScene;

    void Start()
    {
        if (instance == null) {
            // 初回のみインスタンス化
            instance = (GameManager)FindAnyObjectByType(typeof(GameManager));
        } else {
            // 複製禁止
            Destroy(gameObject);
        }

        // シーン遷移による破壊の防止
        DontDestroyOnLoad(gameObject);

        // 状態の初期化
        stateScene = (StateScene)SceneManager.GetActiveScene().buildIndex;
    }

    /// <summary>
    /// 画面遷移を行う
    /// </summary>
    public StateScene ChangeScene
    {
        set {
            stateScene = value;
            SceneManager.LoadSceneAsync((int)stateScene);
        }
    }
}
