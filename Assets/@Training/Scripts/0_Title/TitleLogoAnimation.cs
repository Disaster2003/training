using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// タイトルロゴのアニメーションクラス
/// </summary>
public class TitleLogoAnimation : MonoBehaviour
{
    /// <summary>
    /// 画像編集をする用の変数
    /// </summary>
    Image IMGTitleLogo;

    [SerializeField, Header("アニメーションするまでの待機時間")]
    float IntervalAnimation;

    void Start()
    {
        // 状態の初期化
        IMGTitleLogo = GetComponent<Image>();
        IMGTitleLogo.fillAmount = 0;
    }

    void Update()
    {
        if (IntervalAnimation > 0) {
            // アニメーションの待機中
            IntervalAnimation -= Time.deltaTime;
            return;
        }

        if(IMGTitleLogo.fillAmount < 1) {
            IMGTitleLogo.fillAmount += Time.deltaTime;
        }
    }
}
