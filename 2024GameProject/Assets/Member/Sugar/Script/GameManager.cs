using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // ����̃I�u�W�F�N�g���\�����ꂽ�玞�Ԓ�~
    [SerializeField] GameObject[] Target;
    [SerializeField] bool B_Title=false;

    [SerializeField] AudioSource[] aud;


    int width = 1920;
    int height = 1080;
    void Start()
    {
        // FPS60���ێ�����悤��
        Application.targetFrameRate = 60;

        // �J�[�\����\��
        Cursor.visible = false;

        // ��ʉ𑜓x�Œ�
        Screen.SetResolution(width, height, FullScreenMode.FullScreenWindow, 60);

    }

    void Update()
    {
        timeManager();
        InputKEY();
    }
    void timeManager()
    {
        if (Target[0].activeSelf == true || Target[1].activeSelf == true) { Time.timeScale = 0; }
        else if (Target[0].activeSelf == false || Target[1].activeSelf == false) { Time.timeScale = 1; }

    }
    void InputKEY()
    {
        if (B_Title) { return; }
        if (Input.GetKeyDown(KeyCode.Escape)&&!Target[1].activeSelf) {
            if (Target[0].activeSelf == false) 
            {
                Target[0].SetActive(true);
                OneShotSE_U(SEData.Type.ETC, UISe.esc);
            }
            else { Target[0].SetActive(false); }
        }
    }

    // ���ŕK�v�ɂȂ肻���Ȃ��̂������B
    // �ǉ��ŕK�v�Ȃ炱���ɗp�Ӂ@

    // �I�u�W�F�N�g�Ƃ����낢��
    public enum ClipSe
    {
       stage,
    }
    // �L�����N�^�[�֘A�̉�
    public enum HUMANClipSe
    {
        Move1,
        Move2,
        Jump1,
        Jump2,
        Atk1,
        Atk2,
        Hit1,
        Hit2,
        Skill1,
        Skill2,
        Death,
        num,
    }
    // UI�֘A�̉��͂�����
    public enum UISe
    {
        wasd,    // UI�̈ړ���
        enter,   // ���艹
        esc,     // UI�E�B���h�E
        textmsg, // �e�L�X�g���艹
        tab,     // �߂鉹�i�L�����Z�����j
        Eff1,    // �G�t�F�N�g
        Eff2,
        Eff3,
        Eff4,
        Eff5,
        num,
    }

    [SerializeField] SEDataBase dataBase;

    /// <summary>
    /// Mng_Sound.ClipSe.xxx�ŕK�v��SE���Đ�
    /// </summary>
    /// <param name="clipse"></param>
    public void OneShotSE_C(SEData.Type type, ClipSe se)
    {
        if (type == SEData.Type.OBJ)
        {
            aud[1].PlayOneShot(dataBase.SEDATA[(int)SEData.Type.OBJ].SE[(int)se]);
        }
        else if (type == SEData.Type.HUMAN)
        {
            aud[0].PlayOneShot(dataBase.SEDATA[(int)SEData.Type.HUMAN].SE[(int)se]);
        }
    }
    public void OneShotSE_U(SEData.Type type, UISe se)
    {
        aud[0].PlayOneShot(dataBase.SEDATA[(int)SEData.Type.ETC].SE[(int)se]);
    }

    public void StopSE()
    {
        aud[0].Stop();
    }
}
