using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class RankSeter : MonoBehaviour
{
    [SerializeField, Header("�v���C���[�̃X�R�A")]
    TextMeshProUGUI TXTPlayerScore;

    [SerializeField, Header("�����L���O�̃X�R�A")]
    TextMeshProUGUI[] TXTRankingScore;

    /// <summary>
    /// �����N���ꂼ��̃X�R�A
    /// </summary>
    float[] scoreRank = new float[6];

    void Start()
    {
        CallRankData();
        UpdateRank();
    }

    void Update()
    {
        // esc�Ń����L���O���Z�b�g
        if (Keyboard.current.escapeKey.wasPressedThisFrame) {
            for (var i = 0; i < TXTRankingScore.Length; i++) {
                scoreRank[i + 1] = 0f;
                TXTRankingScore[i].text = $"{i + 1} | _._s";
            }

            // �f�[�^�̈�̃��Z�b�g
            PlayerPrefs.DeleteAll();
        }
    }

    /// <summary>
    /// �����N�̃X�R�A��
    /// �ۑ�����Ă���ꍇ: �f�[�^�̈悩��Ăяo��
    /// �ۑ�����Ă��Ȃ��ꍇ: �f�[�^�̈������������
    /// </summary>
    void CallRankData()
    {
        // �v���C���[�̃X�R�A���Ăяo��
        scoreRank[0] = PlayerPrefs.GetFloat("Rank0");
        TXTPlayerScore.text = scoreRank[0].ToString("f1");
        TXTPlayerScore.color = Color.red;
        
        if (PlayerPrefs.HasKey("Rank1")) {
            // �f�[�^�̈�̓ǂݍ���
            for (var i = 1; i < scoreRank.Length; i++) {
                scoreRank[i] = PlayerPrefs.GetFloat("Rank" + i);
            }
        } else {
            // �f�[�^�̈�̏�����
            for (var i = 1; i < scoreRank.Length; i++) {
                scoreRank[i] = 0f;
                PlayerPrefs.SetFloat("Rank" + i, scoreRank[i]);
            }
        }
    }

    /// <summary>
    /// �����N�t�������āA�\������
    /// </summary>
    void UpdateRank()
    {
        var rankNew = 0; // ����̃X�R�A���ŉ��ʂƉ��肷��

        for (int i = scoreRank.Length - 1; i > 0; i--) { 
            // ���� 1...5
            if (scoreRank[i] == 0f || scoreRank[i] >= scoreRank[0]) {
                // �����N�ԍ��̋L�^
                rankNew = i;
            }
        }

        // �����X�R�A���Ȃ��A�܂��͐V���������N������������
        if (rankNew != 0) {
            // 0�ʂ̂܂܂łȂ������烉���N�C���m��
            for (int i = scoreRank.Length - 1; i > rankNew; i--) {
                // �J�艺������
                scoreRank[i] = scoreRank[i - 1];
            }

            // �V�����N�ɓo�^
            scoreRank[rankNew] = scoreRank[0];
            scoreRank[0] = 0f;

            for (var i = 1; i < scoreRank.Length; i++) {
                // �f�[�^�̈�ɕۑ�
                PlayerPrefs.SetFloat("Rank" + i, scoreRank[i]);
            }
        }

        // �e�L�X�g�ɕ\��
        for (var i = 0; i < TXTRankingScore.Length; i++) {
            if (scoreRank[i + 1] == 0f) {
                TXTRankingScore[i].text = $"{i + 1} | _._s";
            } else {
                TXTRankingScore[i].text = $"{i + 1} | {scoreRank[i + 1]:f1}s";

                if(i + 1 == rankNew) {
                    TXTRankingScore[i].color = Color.red;
                }
            }
        }
    }
}
