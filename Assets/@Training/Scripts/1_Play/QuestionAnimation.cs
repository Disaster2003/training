using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// クエスチョンマークのアニメーションクラス
/// </summary>
public class QuestionAnimation : MonoBehaviour
{
    /// <summary>
    /// 画像編集用コンポーネント
    /// </summary>
    Image IMGQuestion;

    [SerializeField, Header("クエスチョンマーク画像群")]
    Sprite[] Question;

    /// <summary>
    /// アニメーション間隔を管理する変数
    /// </summary>
    float intervalAnimation;

    [SerializeField, Header("アニメーション間隔")]
    float IntervalAnimationMax = 0.1f;


    void Start()
    {
        // 画像の初期化
        IMGQuestion = GetComponent<Image>();
        IMGQuestion.sprite = Question[0];

        // アニメーション間隔の初期化
        intervalAnimation = 0f;
    }

    void Update()
        => AnimationQuestion();

    /// <summary>
    /// クエスチョンマークのアニメーションを行う
    /// </summary>
    void AnimationQuestion()
    {
        if (intervalAnimation < IntervalAnimationMax) {
            // アニメーションのインターバル中
            intervalAnimation += Time.deltaTime;
            return;
        }

        // アニメーション
        intervalAnimation = 0f;
        for (var i = 0; i < Question.Length; i++) {
            if (IMGQuestion.sprite == Question[i]) {
                if (i == Question.Length - 1) {
                    // 最初の画像に戻り、終了
                    IMGQuestion.enabled = false;
                    IMGQuestion.sprite = Question[0];
                    enabled = false;
                    break;
                } else {
                    // 次の画像へ
                    IMGQuestion.sprite = Question[i + 1];
                    break;
                }
            }
        }
    }
}
