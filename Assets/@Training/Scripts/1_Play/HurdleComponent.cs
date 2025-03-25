using UnityEngine;

public class HurdleComponent : MonoBehaviour
{
    public enum Job
    {
        Drop,    // 自由落下運動
        SinWave, // sin波移動
    }
    public Job JobMove; // 移動の役割

    [SerializeField, Header("自由落下用")]
    Rigidbody2D RB2D;
    public float IntervalDrop; // 落下するまでの時間

    float POSStart_y; // 開始時のy座標
    [SerializeField, Header("sin波の幅")]
    float WidthSin;
    [SerializeField, Header("sin波の周期")]
    float SpeedSin;

    void Start()
    {
        // 重力OFF
        RB2D.gravityScale = 0f;

        // 開始位置の確定
        POSStart_y = transform.position.y;
    }

    void Update()
        => Move();

    void Move()
    {
        // 移動開始するまで、インターバルを持たせる
        if (IntervalDrop > 0f) {
            IntervalDrop -= Time.deltaTime;
            return;
        }

        switch (JobMove) {
            case Job.Drop:
                if (RB2D.gravityScale == 1f) return;

                // 自由落下運動開始
                RB2D.gravityScale = 1f;
                break;
            case Job.SinWave:
                // sin波移動中
                transform.Translate(Vector3.left * Time.deltaTime);
                float sin = WidthSin * Mathf.Sin(SpeedSin * Time.time);
                transform.position =
                    new Vector3
                    (
                        transform.position.x,
                        POSStart_y + sin
                    );
                break;
        }
    }
}
