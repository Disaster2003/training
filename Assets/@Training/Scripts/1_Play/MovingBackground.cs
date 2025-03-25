using UnityEngine;

public class MovingBackground : MonoBehaviour
{
    const float OffsetMax = 1f; // offsetの上限値
    [SerializeField] SpriteRenderer Background; // 背景のマテリアル取得用

    void Update()
    {
        // xの値が0 ～ 1でリピートするようにする
        var x = Mathf.Repeat(Time.time, OffsetMax);
        Background.material.SetTextureOffset("_MainTex", new Vector2(x, 0));
    }
}
