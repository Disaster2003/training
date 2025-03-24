using UnityEngine;

/// <summary>
/// シングルトン
/// 
/// ジェネリックで汎用性を強化
/// </summary>
public abstract class SingletonSample<T> : MonoBehaviour where T : MonoBehaviour
{
    static T instance;
    /// <summary>
    /// インスタンスを取得する
    /// </summary>
    public static T Instance { get => instance; }

    public virtual void Awake()
    {
        if (instance == null) {
            // 初回のみインスタンス化
            instance = (T)FindAnyObjectByType(typeof(T));
        } else {
            // 複製禁止
            Destroy(gameObject);
        }
    }
}