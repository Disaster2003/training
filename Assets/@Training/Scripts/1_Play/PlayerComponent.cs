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
    InputSystem_Actions inputSystemActions;

    /// <summary>
    /// 押下移動量
    /// </summary>
    Vector3 inputMove;

    [SerializeField, Header("座標を制限する絶対値(配列0番目:上下、1番目:左右)")]
    Vector2[] POSLimit = new Vector2[2];

    [SerializeField, Header("移動速度")]
    float SpeedMove;

    /// <summary>
    /// 障害物のタグを照合する時に使う文字列
    /// </summary>
    const string Hurdle_Key = "Hurdle";

    [SerializeField, Header("弾の発射方向確認用")]
    PhaseManager PM;

    [SerializeField, Header("弾の複製元")]
    GameObject Bullet;

    /// <summary>
    /// プレイヤーの体力
    /// </summary>
    public int HitPoint { get; private set; }

    [SerializeField, Header("最大体力")]
    int HitPointMax;

    [SerializeField, Header("ヒットエフェクトの複製元")]
    GameObject HitEffect;

    [SerializeField, Header("ゲームオーバー時に使用するフェードパネル")]
    Fade PanelFade;

    void Start()
    {
        // インプットアクションを取得
        inputSystemActions = new InputSystem_Actions();

        // アクションにイベントを登録
        inputSystemActions.Player.Move.started += OnMove;
        inputSystemActions.Player.Move.performed += OnMove;
        inputSystemActions.Player.Move.canceled += OnMove;
        inputSystemActions.Player.Jump.started += OnSpawnBullet;

        // インプットアクションを機能させる為に有効化
        inputSystemActions.Enable();

        // 状態の初期化
        inputMove = Vector3.zero;
        HitPoint = HitPointMax;
    }

    void Update()
    {
        // 無限ヒール(デバッグ用)
        if (Keyboard.current.escapeKey.wasPressedThisFrame) {
            HitPoint = HitPointMax;
        }

        Move();

        // 移動制限
        switch (PM.OriginDirection) {
        case PhaseManager.Direction.Up:
        case PhaseManager.Direction.Down:
            transform.position =
                new Vector2
                (
                    Mathf.Clamp(transform.position.x, -POSLimit[0].x, POSLimit[0].x),
                    Mathf.Clamp(transform.position.y, -POSLimit[0].y, POSLimit[0].y)
                );
            break;
        case PhaseManager.Direction.Left:
        case PhaseManager.Direction.Right:
            transform.position =
                new Vector2
                (
                    Mathf.Clamp(transform.position.x, -POSLimit[1].x, POSLimit[1].x),
                    Mathf.Clamp(transform.position.y, -POSLimit[1].y, POSLimit[1].y)
                );
            break;
        }
    }

    // インプットアクションを他の画面で呼び出さないように無効化
    void OnDestroy()
        => inputSystemActions.Disable();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Hurdle_Key)) {
            HitPoint--;

            // ゲームオーバー
            if (HitPoint <= 0) {
                PanelFade.StateScene = GameManager.StateScene.Result;
                PanelFade.StartedFade = true;
            } else {
                // ヒットエフェクトの発生
                Instantiate(HitEffect, transform.position, Quaternion.identity);
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
        if (inputMove.sqrMagnitude < 0.01f) {
            return;
        }

        // 入力方向への移動
        transform.position += inputMove.normalized * SpeedMove * Time.deltaTime;
    }

    /// <summary>
    /// 弾の発射準備を行う
    /// </summary>
    /// <param name="context">Space, Button Southの入力</param>
    void OnSpawnBullet(InputAction.CallbackContext context)
    {
        var bullet = Instantiate(Bullet, transform.position, Quaternion.identity);
        bullet.GetComponent<BulletMover>().MoveDirection = PM.OriginDirection;
    }
}
