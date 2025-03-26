using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 画面遷移イベントクラス
/// </summary>
public class SetNextScene : MonoBehaviour
{
    [SerializeField, Header("画面遷移アクション用ボタン")]
    Button BTNNextScene;

    [SerializeField, Header("次に遷移したい画面")]
    GameManager.StateScene StateSceneVAR;

    void Start()
        => BTNNextScene.onClick.AddListener(OnStartSelectScene);

    /// <summary>
    /// 画面遷移を開始する
    /// </summary>
    void OnStartSelectScene()
        => GameManager.Instance.ChangeScene = StateSceneVAR;
}
