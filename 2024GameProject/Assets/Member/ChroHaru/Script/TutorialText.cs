using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TutorialText : MonoBehaviour
{
    // ���Đ��ɂ���
    [SerializeField] GameManager gMng;
    [SerializeField] Text text;
    [SerializeField] string message;
    [SerializeField] float delay = 0.3f;
    int num = 0;
    string stringAll_Up;
    [SerializeField] GameObject Img1;
    [SerializeField] GameObject Img2;
    [SerializeField] GameObject Img3;
    [SerializeField] GameObject Img4;
    [SerializeField] GameObject Img5;
    [SerializeField] GameObject Canvas;

    // Update is called once per frame
    void Update()
    {
        switch (num)
        {
            case 0:
                // �����폜
                text.text = "";
                // �����Z�b�g
                message = "�{�ݓ��ɐN���҂��m�F���ꂽ";
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
                if(Input.GetKeyDown(KeyCode.Return))
                {
                    // �����폜
                    text.text = "";
                    message = "����������܂ŐN���҂��Ǘ����� \n" +
                         "�N�������Ȃ��ł���";
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
                
             if(Input.GetKeyDown(KeyCode.Return))
                {
                    text.text = "";
                    message = "����͎{�݂̒n�}��\n" +
                         "���������ΓG�̐N���o�H��\n" +
                         "�\�����₷���Ȃ�";
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
               
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    Img1.SetActive(false);
                    text.text = "";
                    message = "�����Ă��ꂪ�{�݂̎c��̃o�b�e���[�ʂ�\n" +
                        "����͎{�݂̐ݔ����g���Ə����Ă�����\n" +
                        "��莞�Ԍo�߂���Ǝc�ʂ��񕜂��邼";
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

                if (Input.GetKeyDown(KeyCode.Return))
                {
                    Img2.SetActive(false);
                    text.text = "";
                    message = "���Ɏ{�݂ɂ���ݔ��̐�����\n"+
                        "�P�ڂ̐ݔ��̓\�i�[��\n"+
                        "�����Ȃ��G�����邩�X�L�����ł��邼";
                    stringAll_Up = message;
                    Img3.SetActive(true);
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

                if (Input.GetKeyDown(KeyCode.Return))
                {
                    Img3.SetActive(false);
                    text.text = "";
                    message ="2�ڂ̐ݔ��̓X�L������\n" +
                        "�Ď����Ă��Ȃ��G���A�ɓG�����邩\n"+
                        "�X�L�������ł���";
                    stringAll_Up = message;
                    Img4.SetActive(true);
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

                if (Input.GetKeyDown(KeyCode.Return))
                {
                    Img4.SetActive(false);
                    text.text = "";
                    message = "3�ڂ̐ݔ��͓d�C�V���b�N��\n" +
                        "�g�p���邱�ƂœG��r�����邱�Ƃ��ł���";
                    stringAll_Up = message;
                    Img5.SetActive(true);
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

                if (Input.GetKeyDown(KeyCode.Return))
                {
                    Img5.SetActive(false);
                    text.text = "";
                    message = "�ł͌������F��";
                    stringAll_Up = message;
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

                if (Input.GetKeyDown(KeyCode.Return))
                {
                    Canvas.SetActive(false);
                }
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
