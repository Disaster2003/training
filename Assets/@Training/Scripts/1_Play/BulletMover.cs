using UnityEngine;

/// <summary>
/// 弾の発射制御クラス
/// </summary>
public class BulletMover : MonoBehaviour
{
    /// <summary>
    /// 弾の移動方向
    /// </summary>
    public PhaseManager.Direction MoveDirection;

    [SerializeField, Header("目標地点の絶対値")]
    Vector2 POSGoal;

    [SerializeField, Header("弾の移動速度")]
    float SpeedMove;

    /// <summary>
    /// 障害物のタグを照合する時に使う文字列
    /// </summary>
    const string Hurdle_Key = "Hurdle";

    /// <summary>
    /// ヒットエフェクト用変数
    /// </summary>
    HitEffectAnimation hitEffectAnimation;

    void Start()
    {
        // 発射方向を定める
        switch (MoveDirection) {
        default:
            break;
        case PhaseManager.Direction.Up:
        case PhaseManager.Direction.Down:
            transform.rotation = Quaternion.Euler(0, 0, 0);
            break;
        case PhaseManager.Direction.Left:
        case PhaseManager.Direction.Right:
            transform.rotation = Quaternion.Euler(0, 0, 90);
            break;
        }

        // 状態の初期化
        hitEffectAnimation = GetComponent<HitEffectAnimation>();
    }

    void Update()
    {
        // 自身をヒットエフェクト化
        if (hitEffectAnimation.enabled) {
            return;
        }

        Vector2 moveVector;

        switch (MoveDirection) {
        default:
            moveVector = Vector2.zero;
            break;
        case PhaseManager.Direction.Up:
        case PhaseManager.Direction.Left:
            moveVector = Vector2.up;
            break;
        case PhaseManager.Direction.Down:
        case PhaseManager.Direction.Right:
            moveVector = Vector2.down;
            break;
        }

        Move(moveVector);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Hurdle_Key)) {
            transform.localScale = Vector3.one;
            hitEffectAnimation.enabled = true;
        }
    }

    /// <summary>
    /// 弾を移動する
    /// </summary>
    /// <param name="moveVector">背景をスクロールする向き</param>
    void Move(Vector2 moveVector)
    {
        transform.Translate(SpeedMove * moveVector * Time.deltaTime);

        // 画面の枠外なら、移動終了
        if (Mathf.Abs(transform.position.x) >= POSGoal.x || Mathf.Abs(transform.position.y) >= POSGoal.y) {
            Destroy(gameObject);
        }
    }
}
