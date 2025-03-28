using UnityEngine;

/// <summary>
/// カメラの回転クラス
/// </summary>
public class CameraRotater : MonoBehaviour
{
    /// <summary>
    /// 回転方向を保持する変数
    /// </summary>
    public PhaseManager.Direction RotateDirection;

    void Update()
    {
        // カメラの回転とアスペクト比を変更する
        switch (RotateDirection) {
        default:
            break;
        case PhaseManager.Direction.Up:
            transform.rotation = Quaternion.Euler(0, 0, 0);
            break;
        case PhaseManager.Direction.Down:
            transform.rotation = Quaternion.Euler(0, 0, 180);
            break;
        case PhaseManager.Direction.Left:
            transform.rotation = Quaternion.Euler(0, 0, 90);
            break;
        case PhaseManager.Direction.Right:
            transform.rotation = Quaternion.Euler(0, 0, 270);
            break;
        }
    }
}
