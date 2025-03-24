using UnityEngine;
using UnityEngine.UI;

public class SetNextScene : MonoBehaviour
{
    Button btnNextScene;
    [SerializeField, Header("次に遷移したい画面")]
    GameManager.STATE_SCENE State_scene;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // コンポーネントの取得
        btnNextScene = GetComponent<Button>();

        NullCheck();

        // OnClickイベントに登録
        btnNextScene.onClick.AddListener(OnStartSelectScene);
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// nullチェック
    /// </summary>
    void NullCheck()
    {
        if (btnNextScene == null) {
            Debug.LogError("Buttonコンポーネントが取得できません");
        }
    }

    /// <summary>
    /// 画面遷移を開始する
    /// </summary>
    void OnStartSelectScene()
    {
        GameManager.Instance.ChangeScene = State_scene;
    }
}
