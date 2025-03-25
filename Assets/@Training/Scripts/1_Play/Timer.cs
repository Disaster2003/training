using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    /// <summary>
    /// �N���A�܂ł̎��Ԃ��v������ϐ�
    /// </summary>
    float timer;

    [SerializeField, Header("���ԕ\�L�p")]
    TextMeshProUGUI TXTTimer;

    void Start()
    {
        // ���Ԍv���̊J�n����
        PlayerPrefs.SetFloat("Rank0", 0f);
        timer = 0f;
    }

    void Update()
    {
        // �v���C�J�n����̎��Ԃ��v��
        timer += Time.deltaTime;
        TXTTimer.text = timer.ToString("f1") + "s";
    }

    void OnDestroy()
    {
        // �Q�[���I�[�o�[���A0�L�^
        if (PlayerPrefs.GetFloat("Rank0") == 0f) {
            PlayerPrefs.SetFloat("Rank0", 0f);
        }
    }

    /// <summary>
    /// �^�C�}�[���I������
    /// </summary>
    public void FinishTimer()
    {
        // �����L���O�p�Ƀ^�C����ۑ����A�Q�[���I��
        PlayerPrefs.SetFloat("Rank0", timer);
        Destroy(gameObject);
    }
}
