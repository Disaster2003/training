using UnityEngine;

/// <summary>
/// 障害物クラス
/// </summary>
public class HurdleComponent : MonoBehaviour
{
    public enum Job
    {
        /// <summary>
        /// 自由落下運動
        /// </summary>
        Drop,

        /// <summary>
        /// sin波移動
        /// </summary>
        SinWave,
    }

    /// <summary>
    /// 移動の役割
    /// </summary>
    public Job JobMove;

    [SerializeField, Header("自由落下用")]
    Rigidbody2D RB2D;

    /// <summary>
    /// 落下するまでの時間
    /// </summary>
    public float IntervalMoveStart;

    /// <summary>
    /// 開始時のy座標
    /// </summary>
    float POSStartY;

    [SerializeField, Header("sin波の幅")]
    float WidthSin;

    [SerializeField, Header("sin波の周期")]
    float SpeedSin;

    void Start()
    {
        // 重力OFF
        RB2D.gravityScale = 0f;

        // 開始位置の確定
        POSStartY = transform.position.y;
    }

    void Update()
        => Move();

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

        switch (JobMove) {
            case Job.Drop:
                if (RB2D.gravityScale == 1f) {
                    return;
                }

                // 自由落下運動開始
                RB2D.gravityScale = 1f;
                break;
            case Job.SinWave:
                // sin波移動中
                transform.Translate(Vector3.left * Time.deltaTime);
                transform.position = new Vector3(transform.position.x, POSStartY + WidthSin * Mathf.Sin(SpeedSin * Time.time));
                break;
        }
    }
}
