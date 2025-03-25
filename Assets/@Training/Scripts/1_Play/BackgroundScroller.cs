using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField, Header("�w�i�̃}�e���A���擾�p")]
    SpriteRenderer Background;

    /// <summary>
    /// offset�̏���l
    /// </summary>
    const float OffsetMax = 1f;

    [SerializeField, Header("�x������{��(�����_�P�ʂŋL��)")]
    float SlowMagnification;

    /// <summary>
    /// �X�N���[�������������񋓌^
    /// </summary>
    public enum ScrollDirection
    {
        /// <summary>
        /// �����
        /// </summary>
        Up,

        /// <summary>
        /// ������
        /// </summary>
        Down,

        /// <summary>
        /// ������
        /// </summary>
        Left,

        /// <summary>
        /// �E����
        /// </summary>
        Right,
    }

    /// <summary>
    /// �X�N���[��������ێ�����ϐ�
    /// </summary>
    public ScrollDirection ScrollDIR;

    void Update()
    {
        // �w�i�̃X�N���[������������
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
    /// �w�i���X�N���[������
    /// </summary>
    /// <param name="_scrollVector">�w�i���X�N���[���������</param>
    void ScrollBackground(Vector2 _scrollVector)
        => Background.material.SetTextureOffset("_MainTex", _scrollVector * Mathf.Repeat(SlowMagnification * Time.time, OffsetMax));
}
