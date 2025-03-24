using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 画面遷移イベントクラス
/// </summary>
public class SetNextScene : MonoBehaviour
{
    [SerializeField] Button BTNNextScene; // 画面遷移アクション用ボタン
    [SerializeField, Header("次に遷移したい画面")]
    GameManager.StateScene State_Scene;

    void Start()
        => BTNNextScene.onClick.AddListener(OnStartSelectScene);

    /// <summary>
    /// 画面遷移を開始する
    /// </summary>
    void OnStartSelectScene()
        => GameManager.Instance.ChangeScene = State_Scene;
}
