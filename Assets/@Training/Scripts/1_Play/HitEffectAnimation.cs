using UnityEngine;

/// <summary>
/// ヒットエフェクトのアニメーションクラス
/// </summary>
public class HitEffectAnimation : MonoBehaviour
{
    /// <summary>
    /// 画像編集用コンポーネント
    /// </summary>
    SpriteRenderer hitEffect;

    [SerializeField, Header("ヒットエフェクト画像")]
    Sprite[] Explosion;

    /// <summary>
    /// アニメーション間隔を管理する変数
    /// </summary>
    float intervalAnimation;

    [SerializeField, Header("アニメーション間隔")]
    float IntervalAnimationMax = 0.1f;

    /// <summary>
    /// 死亡フラグ
    /// </summary>
    bool isDead;

    void Start()
    {
        // 画像の初期化
        hitEffect = GetComponent<SpriteRenderer>();
        hitEffect.sprite = Explosion[0];

        // アニメーション間隔の初期化
        intervalAnimation = 0f;

        // 状態の初期化
        isDead = false;
    }

    void Update()
    {
        if (isDead) {
            return;
        }

        AnimationHitEffect();
    }

    /// <summary>
    /// ヒットエフェクトのアニメーションを行う
    /// </summary>
    void AnimationHitEffect()
    {
        if (intervalAnimation < IntervalAnimationMax) {
            // アニメーションのインターバル中
            intervalAnimation += Time.deltaTime;
            return;
        }

        // アニメーション
        intervalAnimation = 0f;
        for (var i = 0; i < Explosion.Length; i++) {
            if (hitEffect.sprite == Explosion[i]) {
                if (i == Explosion.Length - 1) {
                    isDead = true;
                    Destroy(gameObject);
                    break;
                } else {
                    // 次の画像へ
                    hitEffect.sprite = Explosion[i + 1];
                    break;
                }
            }
        }
    }
}
