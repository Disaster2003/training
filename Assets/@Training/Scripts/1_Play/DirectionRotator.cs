using UnityEngine;

/// <summary>
/// 方向によって回転を変更するクラス
/// </summary>
public class DirectionRotator : MonoBehaviour
{
    [SerializeField, Header("移動速度")]
    float SpeedMove;

    /// <summary>
    /// 回転方向を保持する変数
    /// </summary>
    public PhaseManager.Direction RotateDirection;

    void Update()
    {
        switch (RotateDirection) {
        case PhaseManager.Direction.Up:
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), SpeedMove * Time.deltaTime);
            break;
        case PhaseManager.Direction.Down:
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 180), SpeedMove * Time.deltaTime);
            break;
        case PhaseManager.Direction.Left:
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 90), SpeedMove * Time.deltaTime);
            break;
        case PhaseManager.Direction.Right:
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 270), SpeedMove * Time.deltaTime);
            break;
        }
    }
}
