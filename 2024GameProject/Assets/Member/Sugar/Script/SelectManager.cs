using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectManager : MonoBehaviour
{
    // �I���ł���Rect�̎Q�ƌ�
    [SerializeField] RectTransform[] RectPos; 
    // �I���A�E�g���C���̈ړ�
    [SerializeField] RectTransform Rct;
    // �f�[�^�x�[�X
    [SerializeField] StageDataBase SDB;
    // �X�e�[�W�̖��O�\��
    [SerializeField] Text StageNameText;
    // ��Փx�Ƃ��̋L�ڗp
    [SerializeField] Text Info;
    // �X�e�[�W�J�ڂɎg��
    [SerializeField] Fade fade;                // FadeCanvas
    // �X�e�[�W�̃T���l�摜
    [SerializeField] Image StageImage;
    // ���ʉ��Đ�
    [SerializeField] GameManager gMng;
    // �Q�ƌ��̍��W�ۑ��p
    Vector3 pos;
    // �I��ԍ�
    public int Lnum,Cnum,Rnum;
    int UDnum; // �㉺
    int LRnum; // ���E
    // �ő�l�ƍŏ��l
    int Max;
    int Min = 0;
    int UDMax = 1;
    // �����l
    const int point = 1;
    // height
    const int height= 200;
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
        //RectPosChange();
        SDB_Set();
    }
    void InputKEY()
    {
        var INPUT_A = Input.GetKeyDown(KeyCode.A)||
            Input.GetKeyDown(KeyCode.LeftArrow);
        var INPUT_D = Input.GetKeyDown(KeyCode.D)||
            Input.GetKeyDown(KeyCode.RightArrow);
        var INPUT_W = Input.GetKeyDown(KeyCode.W)||
            Input.GetKeyDown(KeyCode.UpArrow);
        var INPUT_S = Input.GetKeyDown(KeyCode.S)||
            Input.GetKeyDown(KeyCode.DownArrow);
        // �X�e�[�W�̖��O��I�𒆂ɍ��E�L�[�ŕύX�ł���
        if (UDnum == 0)
        {
            if (INPUT_A)
            {
                // SE�Đ�
                gMng.OneShotSE_U(SEData.Type.ETC, GameManager.UISe.wasd);
                if (LRnum == 0) { LRnum = Max; }
                else { LRnum -= point; }
            }
            if (INPUT_D)
            {
                gMng.OneShotSE_U(SEData.Type.ETC, GameManager.UISe.wasd);
                if (LRnum == Max) { LRnum = Min; }
                else { LRnum += point; }
            }
        }
        //if(INPUT_W)
        //{
        //    gMng.OneShotSE_U(SEData.Type.ETC, GameManager.UISe.wasd);
        //    if (UDnum == Min) { UDnum = UDMax; }
        //    else { UDnum -= point; }
        //}
        //if (INPUT_S)
        //{
        //    gMng.OneShotSE_U(SEData.Type.ETC, GameManager.UISe.wasd);
        //    if (UDnum == UDMax) { UDnum = Min; }
        //    else { UDnum += point; }
        //}

        // �Q�[���J�n�̃{�^���ƃA�E�g���C�����d�Ȃ��Ă��牟������n�߂���
        if (Input.GetKeyDown(KeyCode.Return)&&UDnum==1)
        {
            gMng.OneShotSE_U(SEData.Type.ETC, GameManager.UISe.enter);
            fade.FadeIn(0.5f, () => SceneManager.LoadScene(SDB.STAGE_DATA[LRnum].StageSceneName));
        }
    }
    void SDB_Set()
    {
        // �ȗ��p
        var IxSDB = SDB.STAGE_DATA;

        // Center�̒l���獶�E�����߂�
        Lnum = LRnum-point;
        Rnum = LRnum+point;
        
        // �^�񒆂̃C���[�W�ɉ摜���������ނƂ��Ƀ��X�g�̊O�ɂȂ�Ȃ��悤��
        if (LRnum == Min) { Lnum = Max; }
        if (LRnum == Max) { Rnum = Min; }

        // �f�[�^�x�[�X�����ɕ\��
        // �����̓C���[�W
        StageImage.sprite= IxSDB[LRnum].StageImage;
        // �X�e�[�W�̖��O
        StageNameText.text = IxSDB[LRnum].StageName;
        // ��Փx�ƃJ������
        Info.text = IxSDB[LRnum].infomation_Level + "\n"
            + IxSDB[LRnum].infomation_Cam;
    }
    void RectPosChange()
    {
        pos = RectPos[UDnum].anchoredPosition;
        Rct.sizeDelta = new Vector2(RectPos[UDnum].sizeDelta.x,height);
        Rct.anchoredPosition =pos;
    }
}
