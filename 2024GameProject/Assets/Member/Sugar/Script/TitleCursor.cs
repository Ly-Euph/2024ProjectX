using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleCursor : MonoBehaviour
{
    [SerializeField] Fade fade;                // FadeCanvas
    [SerializeField] RectTransform[] ObjRect;  // ���W�Q�Ƃ�text
    [SerializeField] GameObject OptionBox;     // �I�v�V�������J��
    [SerializeField] GameManager GMng;
    RectTransform myObjRect;                   // ������text
    int num;
    int Max;
    int Min;
    void Start()
    {
        num=0;
        // �R���|�[�l���g�擾
        myObjRect = GetComponent<RectTransform>();
        // �z��ԍ���Max���擾
        Max = ObjRect.Length-1;
        // �z��ԍ���Min��0�Ƃ���
        Min = 0;
    }
    // ���͊֘A
    void InputKey() {
        if(Input.GetKeyDown(KeyCode.W)
            ||Input.GetKeyDown(KeyCode.UpArrow)) // ��
        {
            GMng.OneShotSE_U(SEData.Type.ETC, GameManager.UISe.wasd);
            if(num==Min)
            {
                num = Max;
            }
            else
            {
                num -= 1;
            }
        }
        else if (Input.GetKeyDown(KeyCode.S) 
            || Input.GetKeyDown(KeyCode.DownArrow)) // ��
        {
            GMng.OneShotSE_U(SEData.Type.ETC, GameManager.UISe.wasd);
            if (num==Max)
            {
                num = Min;
            }
            else
            {
                num += 1;
            }
        }
        else if(Input.GetKeyDown(KeyCode.Return)) // ����
        {
            GMng.OneShotSE_U(SEData.Type.ETC, GameManager.UISe.enter);
            switch (num)
            {
                case 0: // START�{�^��
                    fade.FadeIn(0.5f, () => SceneManager.LoadScene("SSS"));
                    break;
                case 1: // OPTION�{�^��
                    OptionBox.SetActive(true);
                    break;
                case 2: // END�{�^�� 
#if UNITY_EDITOR
                    UnityEditor.EditorApplication.isPlaying = false;//�Q�[���v���C�I��
#else
    Application.Quit();//�Q�[���v���C�I��
#endif

                    break;
            }
        }
    }
    void RectPos()
    {
        this.gameObject.GetComponent<RectTransform>().anchoredPosition =
          ObjRect[num].anchoredPosition ;
    }
    void Update()
    {
        if (OptionBox.activeSelf == true) { return; }
        InputKey();
        RectPos();
    }
}
