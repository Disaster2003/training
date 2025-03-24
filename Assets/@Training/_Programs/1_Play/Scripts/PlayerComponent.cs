using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// プレイヤークラス
/// </summary>
public class PlayerComponent : MonoBehaviour
{
    InputSystem_Actions inputSystem_Actions; // インプットアクションを定義
    Vector3 inputMove; // 押下移動量
    [SerializeField, Header("座標を制限する絶対値")]
    Vector2 POSLimit;
    [SerializeField, Header("移動速度")]
    float SpeedMove;

    int hitPoint; // プレイヤーの体力
    [SerializeField, Header("最大体力")]
    int hitPointMax;

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
        hitPoint = hitPointMax;
    }

    void Update() => Move();

    void OnDestroy()
    {
        // インプットアクションを他の画面で呼び出さないように無効化
        inputSystem_Actions.Disable();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy")) {
            hitPoint--;

            if (hitPoint <= 0) {
                /**
 * 後日、編集
 */
            }
        }
    }

    void OnMove(InputAction.CallbackContext context)
    {
        // 押下状態 / スティックの倒れ具合を取得
        inputMove = context.ReadValue<Vector2>();
    }

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

    void OnSpawnBullet(InputAction.CallbackContext context)
    {
        /**
         * 後日、編集
         */
        //Instantiate();
    }
}
