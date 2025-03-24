using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 画面遷移イベントクラス
/// </summary>
public class SetNextScene : MonoBehaviour
{
    Button btnNextScene;
    [SerializeField, Header("次に遷移したい画面")]
    GameManager.StateScene State_Scene;

    void Start()
    {
        // コンポーネントの取得
        btnNextScene = GetComponent<Button>();

        // OnClickイベントに登録
        btnNextScene.onClick.AddListener(OnStartSelectScene);
    }

    /// <summary>
    /// 画面遷移を開始する
    /// </summary>
    void OnStartSelectScene()
        => GameManager.Instance.ChangeScene = State_Scene;
}
