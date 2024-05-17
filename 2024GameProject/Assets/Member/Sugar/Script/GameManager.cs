using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // ����̃I�u�W�F�N�g���\�����ꂽ�玞�Ԓ�~
    [SerializeField] GameObject[] Target;
    [SerializeField] bool B_Title=false;

    [SerializeField] AudioSource[] aud;
    void Start()
    {
        // FPS60���ێ�����悤��
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
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
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (Target[0].activeSelf == false) { Target[0].SetActive(true); }
            else { Target[0].SetActive(false); }
        }
    }

    // ���ŕK�v�ɂȂ肻���Ȃ��̂������B
    // �ǉ��ŕK�v�Ȃ炱���ɗp�Ӂ@
    // �L�����N�^�[�֘A�̉�
    public enum ClipSe
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
        textmsg, // �e�L�X�g���艹
        enter,   // ���艹
        wasd,    // UI�̈ړ���
        esc,     // UI�E�B���h�E
        tab,     // �߂鉹�i�L�����Z�����j
        Eff1,    // �G�t�F�N�g
        Eff2,
        Eff3,
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
            aud[0].PlayOneShot(dataBase.SEDATA[(int)SEData.Type.OBJ].SE[(int)se]);
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
}