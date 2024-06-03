using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectManager : MonoBehaviour
{
    [SerializeField] StageDataBase SDB;
    [SerializeField] Text StageNameText;
    [SerializeField] Text Info;
    [SerializeField] Fade fade;                // FadeCanvas

    // 0(Left) 1(Center) 2(Right)
    [SerializeField] Image[] StageImage;

    // ���ʉ��Đ�
    [SerializeField] GameManager gMng;

    // �I��ԍ�
    public int Lnum,Cnum,Rnum; 

    // �ő�l�ƍŏ��l
    int Max;
    int Min = 0;
    int point = 1;
    void Start()
    {
        // �v�f���[�P�̒l�����߂�
        Max = SDB.STAGE_DATA.Count-point; // �v�f�����ő�l�Ƃ���
        Cnum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0) { return; }
        InputKEY();
        SDB_Set();
    }
    void InputKEY()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            gMng.OneShotSE_U(SEData.Type.ETC, GameManager.UISe.wasd);
            if (Cnum == 0) { Cnum = Max; }
            else { Cnum -= point; }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            gMng.OneShotSE_U(SEData.Type.ETC, GameManager.UISe.wasd);
            if (Cnum == Max) { Cnum = Min; }
            else { Cnum += point; }
        }
        if(Input.GetKeyDown(KeyCode.Return))
        {
            gMng.OneShotSE_U(SEData.Type.ETC, GameManager.UISe.enter);
            fade.FadeIn(0.5f, () => SceneManager.LoadScene(SDB.STAGE_DATA[Cnum].StageSceneName));
        }
    }
    void SDB_Set()
    {
        // �ȗ��p
        var IxSDB = SDB.STAGE_DATA;

        // Center�̒l���獶�E�����߂�
        Lnum = Cnum-point;
        Rnum = Cnum+point;
        
        // �^�񒆂̃C���[�W�ɉ摜���������ނƂ��Ƀ��X�g�̊O�ɂȂ�Ȃ��悤��
        if (Cnum == Min) { Lnum = Max; }
        if (Cnum == Max) { Rnum = Min; }

        // �f�[�^�x�[�X�����ɕ\��
        StageImage[0].sprite= IxSDB[Lnum].StageImage;
        StageImage[1].sprite= IxSDB[Cnum].StageImage;
        StageImage[2].sprite= IxSDB[Rnum].StageImage;

        StageNameText.text = IxSDB[Cnum].StageName;

        Info.text = IxSDB[Cnum].infomation_Level + "\n"
            + IxSDB[Cnum].infomation_Cam;
    }
}
