using UnityEngine;
using UnityEngine.SceneManagement;
public class OptionUICur : MonoBehaviour
{
    // �t�F�[�h�̎���
    [SerializeField] Fade fade;

    // �^�[�Q�b�g���W
    [SerializeField] RectTransform[] List;

    // Option��\��
    [SerializeField] GameObject OpBox;

    [SerializeField] GameObject UIPre;

    // ���Đ��Ɏg��
    [SerializeField] GameManager gMng;

    int num = 0;
    int Max = 1;
    int Min = 0;
    // Start is called before the first frame update
    void Start()
    {
        num = 0;
    }

    // �������l
    private void OnEnable()
    {
        num = 0;
    }
    void Update()
    {
        InputKey();
        RectPos();
    }
    void RectPos()
    {
        this.gameObject.GetComponent<RectTransform>().anchoredPosition =
          List[num].anchoredPosition;
    }

    // ���͏���
    void InputKey()
    {
        if (Input.GetKeyDown(KeyCode.W)
            || Input.GetKeyDown(KeyCode.UpArrow)) // ��
        {
            gMng.OneShotSE_U(SEData.Type.ETC, GameManager.UISe.wasd);
            if (num == Min)
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
            gMng.OneShotSE_U(SEData.Type.ETC, GameManager.UISe.wasd);
            if (num == Max)
            {
                num = Min;
            }
            else
            {
                num += 1;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Return)) // ����
        {
            gMng.OneShotSE_U(SEData.Type.ETC, GameManager.UISe.enter);
            switch (num)
            {
                case 0: // Option
                    OpBox.SetActive(true);
                    UIPre.SetActive(false);
                    break;
                case 1:
                    fade.FadeIn(0.5f,()=> SceneManager.LoadScene("TitleScene"));
                    UIPre.SetActive(false);
                    break;
            }
        }
    }
}
