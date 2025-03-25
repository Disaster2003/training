using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField, Header("背景のマテリアル取得用")]
    SpriteRenderer Background;

    /// <summary>
    /// offsetの上限値
    /// </summary>
    const float OffsetMax = 1f;

    [SerializeField, Header("遅くする倍率(小数点単位で記入)")]
    float SlowMagnification;

    /// <summary>
    /// スクロール方向を示す列挙型
    /// </summary>
    public enum ScrollDirection
    {
        /// <summary>
        /// 上方向
        /// </summary>
        Up,

        /// <summary>
        /// 下方向
        /// </summary>
        Down,

        /// <summary>
        /// 左方向
        /// </summary>
        Left,

        /// <summary>
        /// 右方向
        /// </summary>
        Right,
    }

    /// <summary>
    /// スクロール方向を保持する変数
    /// </summary>
    public ScrollDirection ScrollDIR;

    void Update()
    {
        // 背景のスクロール方向を決定
        Vector2 scrollVector;
        switch(ScrollDIR) {
        default:
            scrollVector = Vector2.zero;
            break;
        case ScrollDirection.Up:
            scrollVector = Vector2.up;
            break;
        case ScrollDirection.Down:
            scrollVector = Vector2.down;
            break;
        case ScrollDirection.Left:
            scrollVector = Vector2.left;
            break;
        case ScrollDirection.Right:
            scrollVector = Vector2.right;
            break;
        }

        ScrollBackground(scrollVector);
    }

    /// <summary>
    /// 背景をスクロールする
    /// </summary>
    /// <param name="_scrollVector">背景をスクロールする向き</param>
    void ScrollBackground(Vector2 _scrollVector)
        => Background.material.SetTextureOffset("_MainTex", _scrollVector * Mathf.Repeat(SlowMagnification * Time.time, OffsetMax));
}
