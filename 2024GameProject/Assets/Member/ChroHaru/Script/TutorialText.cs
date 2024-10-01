using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TutorialText : MonoBehaviour
{
    
    // ���Đ��ɂ���
    [SerializeField] GameManager gMng;
    [SerializeField] Text text;
    [SerializeField] string message;
    [SerializeField] float delay = 0.1f;
    [SerializeField] int num = 0;
    string stringAll_Up;
    [SerializeField] GameObject Img1;
    [SerializeField] GameObject Img2;
    [SerializeField] GameObject Img3;
    [SerializeField] GameObject Img4;
    [SerializeField] GameObject Img5;
    [SerializeField] GameObject Canvas;
    [SerializeField] GameObject enterText;
    [SerializeField] GameObject TimeText;
    [SerializeField] GameObject CameraText;

    [SerializeField] Fade fade;

    // Update is called once per frame
    void Update()
    {
        switch (num)
        {
            case 0:
                // �����폜
                text.text = "";
                // �����Z�b�g
                message = "�{�ݓ��ɐN���҂��m�F���ꂽ�B";
                stringAll_Up = message;
                // �R���[�`���J�n
                StartCoroutine(RevealText());
                num++;
                break;
            case 1:
                if (text.text == stringAll_Up)
                {
                    num++;
                }
                break;

            case 2:
                enterText.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    enterText.SetActive(false);
                    // �����폜
                    text.text = "";
                    message = "����������܂ŐN���҂��Ǘ����� \n" +
                         "�N�������Ȃ��ł���B";
                    stringAll_Up = message;


                    // �R���[�`���J�n
                    StartCoroutine(RevealText());
                    num++;
                }
                    
                break;
            case 3:
                if (text.text == stringAll_Up)
                {
                    num++;
                }
                break;

            case 4:
                enterText.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    enterText.SetActive(false);
                    text.text = "";
                    message = "����͎{�݂̒n�}��\n" +
                         "���������ΓG�̐N���o�H��\n" +
                         "�\�����₷���Ȃ�B";
                    stringAll_Up = message;

                    Img1.SetActive(true);
                    // �R���[�`���J�n
                    StartCoroutine(RevealText());
                    num++;
                }
                    
                break;
            case 5:
               
                if (text.text == stringAll_Up)
                {
                    num++;
                }
                break;
            case 6:
                enterText.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    enterText.SetActive(false);
                    Img1.SetActive(false);
                    text.text = "";
                    message = "�����Ă��ꂪ�{�݂̎c��̃o�b�e���[�ʂ�\n" +
                        "����͎{�݂̐ݔ����g���Ə����Ă�����\n" +
                        "��莞�Ԍo�߂���Ǝc�ʂ��񕜂��邼�B";
                    stringAll_Up = message;
                    Img2.SetActive(true);
                    // �R���[�`���J�n
                    StartCoroutine(RevealText());
                    num++;
                }

                break;
            case 7:

                if (text.text == stringAll_Up)
                {
                    num++;
                }
                break;

            case 8:
                enterText.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    enterText.SetActive(false);
                    Img2.SetActive(false);
                    text.text = "";
                    message = "�����Ă���͏���������܂ł̎��Ԃ�\n" +
                         "���̎��ԑς��Ă���B";
                    stringAll_Up = message;

                    TimeText.SetActive(true);
                    // �R���[�`���J�n
                    StartCoroutine(RevealText());
                    num++;
                }

                break;
            case 9:
                if (text.text == stringAll_Up)
                {
                    num++;
                }
                break;

            case 10:
                enterText.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    enterText.SetActive(false);
                    TimeText.SetActive(false);
                    text.text = "";
                    message = "����͍����Ă���J�����̔ԍ���\n"+
                        "�����L�[�ŃJ������؂�ւ���\n"+
                        "���̃J���������邱�Ƃ��ł���B";
                    stringAll_Up = message;

                    CameraText.SetActive(true);
                    // �R���[�`���J�n
                    StartCoroutine(RevealText());
                    num++;
                }

                break;

            case 11:
                if (text.text == stringAll_Up)
                {
                    num++;
                }
                break;
            case 12:
                enterText.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    enterText.SetActive(false);
                    CameraText.SetActive(false);
                    text.text = "";
                    message = "���Ɏ{�݂ɂ���ݔ��̐�����\n" +
                        "��ڂ̐ݔ��̓\�i�[��\n" +
                        "�����Ȃ��G��������悤�ɂȂ邼�B";
                    stringAll_Up = message;
                    Img3.SetActive(true);
                    // �R���[�`���J�n
                    StartCoroutine(RevealText());
                    num++;
                }
                break;
            case 13:
                if (text.text == stringAll_Up)
                {
                    num++;
                }
                break;
            case 14:
                enterText.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    enterText.SetActive(false);
                    Img3.SetActive(false);
                    text.text = "";
                    message = "��ڂ̐ݔ��̓X�L������\n" +
                        "�Ď����Ă��Ȃ��G���A�ɓG���N��������\n" +
                        "�m�点�Ă����B";
                    stringAll_Up = message;
                    Img4.SetActive(true);
                    // �R���[�`���J�n
                    StartCoroutine(RevealText());
                    num++;
                }
                break;
            case 15:
                if (text.text == stringAll_Up)
                {
                    num++;
                }
                break;
            case 16:
                enterText.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    enterText.SetActive(false);
                    Img4.SetActive(false);
                    text.text = "";
                    message = "�O�ڂ̐ݔ��͓d�C�V���b�N��\n" +
                        "�g�p���邱�ƂœG��r�����邱�Ƃ��ł���B";
                    stringAll_Up = message;
                    Img5.SetActive(true);
                    // �R���[�`���J�n
                    StartCoroutine(RevealText());
                    num++;
                }
                break;
            case 17:
                if (text.text == stringAll_Up)
                {
                    num++;
                }
                break;
            case 18:
                enterText.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    enterText.SetActive(false);
                    Img5.SetActive(false);
                    text.text = "";
                    message = "�ł͌������F��B";
                    stringAll_Up = message;
                    // �R���[�`���J�n
                    StartCoroutine(RevealText());
                    num++;
                }

                break;
            case 19:
                if (text.text == stringAll_Up)
                {
                    num++;
                }
                break;
            case 20:
                enterText.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    enterText.SetActive(false);
                    //Canvas.SetActive(false);
                    num++;
                }
                break;
            case 21:
                fade.FadeIn(0.5f, () => SceneManager.LoadScene("StageSelectScene"));
                num++;
                break;
        }

    }
    IEnumerator RevealText()
    {
        // �ꕶ�����\��
        foreach (char c in stringAll_Up)
        {
            text.text += c;
            gMng.OneShotSE_U(SEData.Type.ETC, GameManager.UISe.textmsg);
            yield return new WaitForSecondsRealtime(delay); // �w�莞�ԑҋ@
        }
    }
}
