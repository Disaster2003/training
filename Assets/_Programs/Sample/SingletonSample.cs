using UnityEngine;

/// <summary>
/// �V���O���g��
/// 
/// �W�F�l���b�N�Ŕėp��������
/// </summary>
public abstract class SingletonSample<T> : MonoBehaviour where T : MonoBehaviour
{
    static T instance;
    /// <summary>
    /// �C���X�^���X���擾����
    /// </summary>
    public static T Instance { get => instance; }

    public virtual void Awake()
    {
        if (instance == null) {
            // ����̂݃C���X�^���X��
            instance = (T)FindAnyObjectByType(typeof(T));
        } else {
            // �����֎~
            Destroy(gameObject);
        }
    }
}