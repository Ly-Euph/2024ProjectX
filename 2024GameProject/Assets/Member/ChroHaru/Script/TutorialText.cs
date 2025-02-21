using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class TutorialText : MonoBehaviour
{
    // ���Đ��ɂ���
    [SerializeField] GameManager gMng;
    // �M�~�b�N����Ɏg��
    [SerializeField] CameraManager cMng;
    // �\����̃e�L�X�g
    [SerializeField] Text text;
    // ���̏����Ɍ��������ɑ����悤��
    [SerializeField] GameObject enterText;
    // ���b�Z�[�W�i�[
    string message;
    // �\�����x
    [SerializeField] float delay = 0.1f;
    // �X�C�b�`�����Ɏg�p
    [SerializeField] int num = 0;
    // message���i�[���A�ꕶ�����\�����鎞�Ɏg��
    string stringAll_Up;

    // �f���Q�[�g
    private Func<bool> callAction;

    // �^�C�}�[
    float _timer = 3.0f;
    const float setT = 3.0f;

    // �A�E�g���C���I�u�W�F�N�g
    [SerializeField] GameObject map;         // �}�b�v
    [SerializeField] GameObject battery;     // �o�b�e���[
    [SerializeField] GameObject light;       // �Z���T�[���C�g
    [SerializeField] GameObject scan;        // �X�L����
    [SerializeField] GameObject volt;        // �{���g
    [SerializeField] GameObject Canvas;      // �`���[�g���A���I�u�W�F�N�g
    [SerializeField] GameObject TimeText;    // �^�C�}�[�e�L�X�g
    [SerializeField] GameObject CameraText;  // �J�����ԍ��̃e�L�X�g
    
    // �V�[���ړ��̎��̃t�F�[�h
    [SerializeField] Fade fade;

    /// <summary>
    /// �`���[�g���A���̂ݑ���������ňꊇ�Ǘ�
    /// </summary>
    void Update()
    {
        //�����~�߂Ă�Ԃ�return��������B
        if (Time.timeScale == 0) return;

        switch (num)
        {
            case 0:
                // �����폜
                text.text = "";
                // �����Z�b�g
                message = "�{�݂Ɏ��c���ꂽ�悤����\n"+
                    "�{�ݓ��ɓG�̐N�����m�F����Ă���B";
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
                    TimeText.SetActive(true);
                    // �����폜
                    text.text = "";
                    message = "���~���Ɍ������Ă���\n"+"���̎��ԑς��Ă���B";
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
                    // �^�C�}�[�̃A�E�g���C���I�u�W�F�N�g�폜
                    Destroy(TimeText);
                    enterText.SetActive(false);
                    text.text = ""; 
                    message = "�{�ݓ��̐ݔ��͎g����悤���ȁB\n"+"�g������������Ă������B";
                    stringAll_Up = message;
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
                    CameraText.SetActive(true);
                    enterText.SetActive(false);
                    text.text = ""; 
                    message = "���ꂪ���݌��Ă���J������\n" + "����̃}�b�v�̔ԍ��Ɛ������A�����Ă���B";
                    stringAll_Up = message;
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
                    // �J�����e�L�X�g�̃I�u�W�F�N�g�폜
                    Destroy(CameraText);
                    map.SetActive(true);
                    enterText.SetActive(false);
                    text.text = "";
                    message = "���̏�ɂ���̂��{�ݓ��̃}�b�v���B\n"+"�l�^�}�[�N�͌N�̂���G���A���B";
                    stringAll_Up = message;
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
                    // �}�b�v�̃A�E�g���C���I�u�W�F�N�g�폜
                    Destroy(map);
                    enterText.SetActive(false);
                    text.text = "";
                    message = "�`�Ƃc�L�[�ŃJ�����𑀍�ł���B\n"+
                              "�����Ă݂Ă���B";
                    stringAll_Up = message;
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
                _timer -= Time.deltaTime;
                if (_timer <= 0)
                {
                    _timer -= Time.deltaTime;
                    text.text = "";
                    message = "���ɐN���҂���g�����ׂɎg��\n"+
                        "�@�\���������B";
                    stringAll_Up = message;
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
                    text.text = "";
                    message = "�܂��̓X�L�������B\n" +
                        "����œG�̏ꏊ�����ł���B";
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
                enterText.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    enterText.SetActive(false);
                    text.text = "";
                    message = "�g�p����ɂ̓o�b�e���[�������B\n" +
                        "�����čė��p�ɂ̓��`���[�W���K�v���B";
                    stringAll_Up = message;
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
                    text.text = "";
                    battery.SetActive(true);
                    message = "���ꂪ�o�b�e���[�ʂ��B\n"+
                        "�o�b�e���[�͎��Ԃŉ񕜂��Ă����B";
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
                    // �֐��o�^
                    callAction = cMng.Tutorial_Scan;
                    // �o�b�e���[�A�E�g���C���I�u�W�F�N�g�폜
                    Destroy(battery);
                    scan.SetActive(true);
                    enterText.SetActive(false);
                    text.text = "";
                    message = "����ł̓X�L�����������Ă���B";
                    stringAll_Up = message;
                    // �R���[�`���J�n
                    StartCoroutine(RevealText());
                    num++;
                }
                break;
            case 21:
                if (text.text == stringAll_Up)
                {
                    num++;
                }
                break;
            case 22:
                if (callAction != null&&callAction.Invoke())
                {
                    // �X�L�����̃A�E�g���C���I�u�W�F�N�g�폜
                    Destroy(scan);
                    text.text = "";
                    message = "�}�b�v���݂Ă���A�Ԃ��_�ł��Ă���ꏊ��\n"+
                        "�G�̐N�����Ă���G���A���B";
                    stringAll_Up = message;
                    // �R���[�`���J�n
                    StartCoroutine(RevealText());
                    // �֐�����
                    callAction = null;
                    num++;
                }
                break;
            case 23:
                if (text.text == stringAll_Up)
                {
                    num++;
                }
                break;
            case 24:
                enterText.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    enterText.SetActive(false);
                    text.text = "";
                    message = "�J������؂�ւ��邼�B";
                    stringAll_Up = message;
                    // �R���[�`���J�n
                    StartCoroutine(RevealText());
                    num++;
                }
                break;
            case 25:
                if (text.text == stringAll_Up)
                {
                    num++;
                }
                break;
            case 26:
                enterText.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    // �֐��o�^
                    callAction = cMng.Tutorial_CamChan;
                    enterText.SetActive(false);
                    text.text = "";
                    message = "����͐����L�[��2���ȁB\n"+
                        "��������E�L�[�ł�������";
                    stringAll_Up = message;
                    // �R���[�`���J�n
                    StartCoroutine(RevealText());
                    num++;
                }
                break;
            case 27:
                if (text.text == stringAll_Up)
                {
                    num++;
                }
                break;
            case 28:
                if (callAction != null && callAction.Invoke())
                {
                    text.text = "";
                    message = "�c��������Ȃ���\n"
                              + "�Z���T�[���C�g�����Ă݂邩�B";
                    stringAll_Up = message;
                    // �R���[�`���J�n
                    StartCoroutine(RevealText());
                    // �֐�����
                    callAction = null;
                    num++;
                }
                break;
            case 29:
                if (text.text == stringAll_Up)
                {
                    num++;
                }
                break;
            case 30:
                enterText.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    enterText.SetActive(false);
                    text.text = "";
                    message = "���Ă���Ԃ̓o�b�e���[��\n" +
                        "�񕜂��Ȃ�����v���ӂ��B";
                    stringAll_Up = message;
                    // �R���[�`���J�n
                    StartCoroutine(RevealText());
                    num++;
                }
                break;
            case 31:
                if (text.text == stringAll_Up)
                {
                    num++;
                }
                break;
            case 32:
                enterText.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    // �֐��o�^
                    callAction = cMng.Tutorial_Light;
                    enterText.SetActive(false);
                    light.SetActive(true);
                    text.text = "";
                    message = "����ł͂��Ă݂Ă���B\n"+
                        "�X�e���X��Ԃ̓G����������͂����B";
                    stringAll_Up = message;
                    // �R���[�`���J�n
                    StartCoroutine(RevealText());
                    num++;
                }
                break;
            case 33:
                if (text.text == stringAll_Up)
                {
                    num++;
                }
                break;
            case 34:
                if (callAction != null && callAction.Invoke())
                {
                    // ���C�g�̃A�E�g���C���I�u�W�F�N�g�폜
                    Destroy(light);
                    text.text = "";
                    message = "�����ȁB���ނ��邼�B";
                    stringAll_Up = message;
                    // �R���[�`���J�n
                    StartCoroutine(RevealText());
                    // �֐�����
                    callAction = null;
                    num++;
                }
                break;
            case 35:
                if (text.text == stringAll_Up)
                {
                    num++;
                }
                break;
            case 36:
                enterText.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    callAction = cMng.Tutorial_Volt;
                    volt.SetActive(true);
                    enterText.SetActive(false);
                    text.text = "";
                    message = "������g���񂾁B";
                    stringAll_Up = message;
                    // �R���[�`���J�n
                    StartCoroutine(RevealText());
                    num++;
                }
                break;
            case 37:
                if (text.text == stringAll_Up)
                {
                    num++;
                }
                break;
            case 38:
                if (callAction != null && callAction.Invoke())
                {
                    // �{���g�̃A�E�g���C���I�u�W�F�N�g�폜
                    Destroy(volt);
                    text.text = "";
                    message = "�ЂƂ܂��A���v�������ȁB\n"+
                        "�ł́A�������F��B";
                    stringAll_Up = message;
                    // �R���[�`���J�n
                    StartCoroutine(RevealText());
                    // �֐�����
                    callAction = null;
                    num++;
                }
                break;
            case 39:
                if (text.text == stringAll_Up)
                {
                    num++;
                    _timer = setT;
                }
                break;
            case 40:
                _timer -= Time.deltaTime;
                if(_timer<=0)
                {
                    num++;
                }
                break;
            case 41:
                fade.FadeIn(1.0f, () => SceneManager.LoadScene("SSS"));
                num++;
                break;
        }

    }

    /// <summary>
    /// �ꕶ�����\�������鏈��
    /// </summary>
    /// <returns></returns>
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
