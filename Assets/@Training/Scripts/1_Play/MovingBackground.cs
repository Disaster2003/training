using UnityEngine;

public class MovingBackground : MonoBehaviour
{
    const float OffsetMax = 1f; // offset�̏���l
    [SerializeField] SpriteRenderer Background; // �w�i�̃}�e���A���擾�p

    void Update()
    {
        // x�̒l��0 �` 1�Ń��s�[�g����悤�ɂ���
        var x = Mathf.Repeat(Time.time, OffsetMax);
        Background.material.SetTextureOffset("_MainTex", new Vector2(x, 0));
    }
}
