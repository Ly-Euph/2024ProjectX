using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OptionManager : MonoBehaviour
{
    // UI�̍��W
    [SerializeField] RectTransform ImageOutLine;   // �������A�E�g���C��
    [SerializeField] RectTransform[] SetPos;       // �ڕW��UI���W

    // ���݂̉��ʒl�̕\��
    [SerializeField] Text[] Text_VolNum;

    // ���ʃo�[�̕\��
    [SerializeField] Image[] Master_VolImage;
    [SerializeField] Image[] BGM_VolImage;
    [SerializeField] Image[] SE_VolImage;

    // ���͏��ۑ�
    int num=0;

    // �e����
    int M_num;
    int B_num;
    int S_num;

    // ���V�[���ŃI�u�W�F�N�g��T��
    SoundData Sdata;
    
    void Start()
    {
        // ���ʂ̒l��ۑ����Ă���X�N���v�g
        Sdata = GameObject.Find("OptionData").GetComponent<SoundData>();

        // FPS60���ێ�����悤��
        Application.targetFrameRate = 60;

        // �l���󂯎��
        M_num = Sdata.Para_Master;
        B_num = Sdata.Para_Bgm;
        S_num = Sdata.Para_Se;
    }

    void Update()
    {
        InputKEY();
        RectPos();
    }

    // ����
    private void InputKEY()
    {
        // �I��
        if(Input.GetKeyDown(KeyCode.W)|| Input.GetKeyDown(KeyCode.UpArrow))
        {
            // ��̍��ڂ��Ȃ��ꍇ�Ɉ�ԉ��̍��ڂɂ���
            if (num == 0) { num = SetPos.Length-1; }
            else { num--; }
        }
        else if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            // ��̍��ڂ��Ȃ��ꍇ�Ɉ�ԉ��̍��ڂɂ���
            if (num == SetPos.Length-1) { num = 0; }
            else { num++; }
        }

        // ���ʒ���
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            
        }
    }
    
    // Width��Height�ƍ��W�̕ύX
    void RectPos()
    {
        ImageOutLine.anchoredPosition = SetPos[num].anchoredPosition;
        ImageOutLine.sizeDelta = SetPos[num].sizeDelta;
    }

    // ���ʒ����Ɋւ���
    void Vol(int List_num)
    {
        switch (List_num)
        {
            case 0:

                break;
            case 1:

                break;
            case 2:

                break;
        }

    }
}
