﻿using UnityEngine;

public class BulletMover : MonoBehaviour
{
    /// <summary>
    /// 弾の移動方向
    /// </summary>
    public PhaseManager.Direction MoveDirection;

    [SerializeField, Header("弾の移動速度")]
    float SpeedMove;

    void Start()
    {
        // 発射方向を定める
        switch (MoveDirection) {
        default:
            break;
        case PhaseManager.Direction.Up:
            //case PhaseManager.Direction.Down: /* 後日、実装予定 */
            transform.rotation = Quaternion.Euler(0, 0, 0);
            break;
        //case PhaseManager.Direction.Left: /* 後日、実装予定 */
        case PhaseManager.Direction.Right:
            transform.rotation = Quaternion.Euler(0, 0, 90);
            break;
        }
    }

    void Update()
    {
        Vector2 moveVector;
        switch (MoveDirection) {
        default:
            moveVector = Vector2.zero;
            break;
        case PhaseManager.Direction.Up:
        //case PhaseManager.Direction.Left: /* 後日、実装予定 */
            moveVector = Vector2.up;
            break;
        //case PhaseManager.Direction.Down: /* 後日、実装予定 */
        case PhaseManager.Direction.Right:
            moveVector = Vector2.down;
            break;
        }

        Move(moveVector);
    }

    /// <summary>
    /// 弾を移動する
    /// </summary>
    /// <param name="_moveVector">背景をスクロールする向き</param>
    void Move(Vector2 _moveVector)
        => transform.Translate(SpeedMove * _moveVector * Time.deltaTime);
}
