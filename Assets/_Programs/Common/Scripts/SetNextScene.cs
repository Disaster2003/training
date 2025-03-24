using UnityEngine;
using UnityEngine.UI;

public class SetNextScene : MonoBehaviour
{
    Button btnNextScene;
    [SerializeField, Header("���ɑJ�ڂ��������")]
    GameManager.STATE_SCENE State_scene;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // �R���|�[�l���g�̎擾
        btnNextScene = GetComponent<Button>();

        NullCheck();

        // OnClick�C�x���g�ɓo�^
        btnNextScene.onClick.AddListener(OnStartSelectScene);
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// null�`�F�b�N
    /// </summary>
    void NullCheck()
    {
        if (btnNextScene == null) {
            Debug.LogError("Button�R���|�[�l���g���擾�ł��܂���");
        }
    }

    /// <summary>
    /// ��ʑJ�ڂ��J�n����
    /// </summary>
    void OnStartSelectScene()
    {
        GameManager.Instance.ChangeScene = State_scene;
    }
}
