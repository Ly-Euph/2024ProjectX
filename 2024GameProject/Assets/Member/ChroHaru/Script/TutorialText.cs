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
                // �����폜
                text.text = "";
                message = "����������܂ŐN���҂��Ǘ����� \n"+
                          "�N�������Ȃ��ł���";
                stringAll_Up = message;
                // �R���[�`���J�n
                StartCoroutine(RevealText());
                num++;
                break;
            case 3:
                if (text.text == stringAll_Up)
                {
                    num++;
                }
                break;

            case 4:
                // �����폜
                text.text = "";
                message = "����͎{�݂̒n�}��\n"+
                          "���������ΓG�̐N���o�H��\n"+
                          "�\�����₷���Ȃ�";
                stringAll_Up = message;
                // �R���[�`���J�n
                StartCoroutine(RevealText());
                num++;
                break;
            case 5:
                if (text.text == stringAll_Up)
                {
                    num++;
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
