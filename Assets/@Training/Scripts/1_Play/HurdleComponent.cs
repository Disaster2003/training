using UnityEngine;

/// <summary>
/// 障害物クラス
/// </summary>
public class HurdleComponent : MonoBehaviour
{
    /// <summary>
    /// 移動の役割を保持する変数
    /// </summary>
    public PhaseManager.Direction MoveDirection;

    [SerializeField, Header("自由落下用")]
    Rigidbody2D RB2D;

    [SerializeField, Header("目標地点の絶対値")]
    float POSGoal;

    /// <summary>
    /// 開始時のy座標
    /// </summary>
    float POSStartY;

    [SerializeField, Header("sin波の幅")]
    float WidthSin;

    [SerializeField, Header("sin波の周期")]
    float SpeedSin;

    /// <summary>
    /// 動き出すまでの時間(生成時、役割ごとに決定)
    /// </summary>
    public float IntervalMoveStart;

    /// <summary>
    /// 障害物の体力
    /// </summary>
    int hitPoint;

    /// <summary>
    /// 最大体力(生成時、役割ごとに決定)
    /// </summary>
    public int HitPointMax;

    void Start()
    {
        MakeWeightless();

        // 開始位置の確定
        POSStartY = transform.position.y;

        // 状態の初期化
        hitPoint = HitPointMax;
    }

    void Update()
        => Move();

    void OnEnable()
        => MakeWeightless();

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet")) {
            hitPoint--;

            if (hitPoint <= 0) {
                Destroy(gameObject);
            }
        }
    }

    /// <summary>
    /// 役割ごとに移動処理を行う
    /// </summary>
    void Move()
    {
        // 移動開始するまで、インターバルを持たせる
        if (IntervalMoveStart > 0f) {
            IntervalMoveStart -= Time.deltaTime;
            return;
        }

        switch (MoveDirection) {
        default:
            break;
        case PhaseManager.Direction.Up:
            if (RB2D.bodyType == RigidbodyType2D.Dynamic) {
                break;
            }

            // 自由落下運動開始
            RB2D.bodyType = RigidbodyType2D.Dynamic;
            break;
        case PhaseManager.Direction.Right:
            // sin波移動中
            transform.Translate(Vector3.left * Time.deltaTime);
            transform.position = new Vector3(
                transform.position.x,
                POSStartY + (WidthSin * Mathf.Sin(SpeedSin * Time.time)));
            break;
        }

        // 画面の枠外なら、移動終了
        if(Mathf.Abs(transform.position.x) >= POSGoal || Mathf.Abs(transform.position.y) >= POSGoal) {
            MakeWeightless();
            GetComponent<HurdleComponent>().enabled = false;
        }
    }

    /// <summary>
    /// 無重力化
    /// </summary>
    void MakeWeightless()
    {
        RB2D.linearVelocity = new Vector2(0, 0);
        RB2D.bodyType = RigidbodyType2D.Kinematic;
    }
}
