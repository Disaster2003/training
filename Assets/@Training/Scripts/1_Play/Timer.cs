using TMPro;
using UnityEngine;

/// <summary>
/// タイマー用クラス
/// </summary>
public class Timer : MonoBehaviour
{
    /// <summary>
    /// クリアまでの時間を計測する変数
    /// </summary>
    float timer;

    [SerializeField, Header("時間表記用")]
    TextMeshProUGUI TXTTimer;

    void Start()
    {
        // 時間計測の開始処理
        PlayerPrefs.SetFloat("Rank0", 0f);
        timer = 0f;
    }

    void Update()
    {
        // プレイ開始からの時間を計測
        timer += Time.deltaTime;
        TXTTimer.text = timer.ToString("f1") + "s";
    }

    void OnDestroy()
    {
        // ゲームオーバー時、0記録
        if (PlayerPrefs.GetFloat("Rank0") == 0f) {
            PlayerPrefs.SetFloat("Rank0", 0f);
        }
    }

    /// <summary>
    /// タイマーを終了する
    /// </summary>
    public void FinishTimer()
    {
        // ランキング用にタイムを保存し、ゲーム終了
        PlayerPrefs.SetFloat("Rank0", timer);
    }
}
