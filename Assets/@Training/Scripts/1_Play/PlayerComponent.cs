using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// プレイヤークラス
/// </summary>
public class PlayerComponent : MonoBehaviour
{
    /// <summary>
    /// インプットアクションを定義
    /// </summary>
    InputSystem_Actions inputSystem_Actions;

    /// <summary>
    /// 押下移動量
    /// </summary>
    Vector3 inputMove;
    
    [SerializeField, Header("座標を制限する絶対値")]
    Vector2 POSLimit;

    [SerializeField, Header("移動速度")]
    float SpeedMove;

    [SerializeField, Header("弾の複製元")]
    GameObject Bullet;

    /// <summary>
    /// プレイヤーの体力
    /// </summary>
    int hitPoint;

    [SerializeField, Header("最大体力")]
    int HitPointMax;

    void Start()
    {
        // インプットアクションを取得
        inputSystem_Actions = new InputSystem_Actions();

        // アクションにイベントを登録
        inputSystem_Actions.Player.Move.started += OnMove;
        inputSystem_Actions.Player.Move.performed += OnMove;
        inputSystem_Actions.Player.Move.canceled += OnMove;
        inputSystem_Actions.Player.Jump.started += OnSpawnBullet;

        // インプットアクションを機能させる為に有効化
        inputSystem_Actions.Enable();

        // 状態の初期化
        inputMove = Vector3.zero;
        hitPoint = HitPointMax;
    }

    void Update()
        => Move();

    // インプットアクションを他の画面で呼び出さないように無効化
    void OnDestroy()
        => inputSystem_Actions.Disable();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hurdle")) {
            hitPoint--;

            // ゲームオーバー
            if (hitPoint <= 0) {
                GameManager.Instance.ChangeScene = GameManager.StateScene.Result;
            }
        }
    }

    /// <summary>
    /// 押下状態 / スティックの倒れ具合を取得
    /// </summary>
    /// <param name="context">WASD, ↑↓←→, スティックの入力値</param>
    void OnMove(InputAction.CallbackContext context)
        => inputMove = context.ReadValue<Vector2>();

    void Move()
    {
        // 押下されていない / 十分にジョイスティックが倒れていない判定
        if (inputMove.sqrMagnitude < 0.01f) return;

        // 入力方向への移動
        transform.position += inputMove.normalized * SpeedMove * Time.deltaTime;

        // 移動制限
        transform.position =
            new Vector2
            (
                Mathf.Clamp(transform.position.x, -POSLimit.x, POSLimit.x),
                Mathf.Clamp(transform.position.y, -POSLimit.y, POSLimit.y)
            );
    }

    /// <summary>
    /// 弾の発射準備を行う
    /// </summary>
    /// <param name="context">Space, Button Southの入力</param>
    void OnSpawnBullet(InputAction.CallbackContext context)
    {
        Instantiate(Bullet, transform.position, Quaternion.identity);
    }
}
