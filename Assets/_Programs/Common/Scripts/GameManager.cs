using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletonSample<GameManager>
{
    public enum STATE_SCENE
    {
        TITLE,  // �^�C�g�����
        PLAY,   // �v���C���
        RESULT, // ���ʉ��
    }
    STATE_SCENE state_scene;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // �V�[���J�ڂɂ��j��̖h�~
        DontDestroyOnLoad(gameObject);

        // ��Ԃ̏�����
        state_scene = (STATE_SCENE)SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// ��ʑJ�ڂ��s��
    /// </summary>
    public STATE_SCENE ChangeScene
    {
        set {
            state_scene = value;
            SceneManager.LoadSceneAsync((int)state_scene);
        }
    }
}
