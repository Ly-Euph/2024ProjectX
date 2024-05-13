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
    [SerializeField] GameObject[] Master_VolImage;
    [SerializeField] GameObject[] BGM_VolImage;
    [SerializeField] GameObject[] SE_VolImage;

    // �Đ��R���|�[�l���g�̒l
    [SerializeField] AudioSource B_Audio;
    [SerializeField] AudioSource S_Audio;

    int MaxVol = 10;
    int MinVol = 0;

    // ���͏��ۑ�
    int num=0;

    // �e����
    int M_num;
    int B_num;
    int S_num;

    // ���V�[���ŃI�u�W�F�N�g��T��
    SoundData Sdata;

    private void OnEnable()
    {
        if (Sdata == null) { return; }

        // �l���󂯎��
        M_num = Sdata.Para_Master;
        B_num = Sdata.Para_Bgm;
        S_num = Sdata.Para_Se;

        // �J�[�\���ʒu
        num = 0;

        // �l�����ɐF�X�Z�b�g
        setVol();
    }
    void Start()
    {
        this.gameObject.GetComponent<Canvas>().enabled = false;
        // ���ʂ̒l��ۑ����Ă���X�N���v�g
        Sdata = GameObject.Find("OptionData").GetComponent<SoundData>();

        // �l���󂯎��
        M_num = Sdata.Para_Master;
        B_num = Sdata.Para_Bgm;
        S_num = Sdata.Para_Se;

        setVol();

        // ���V�[���ŏ��ɏ��������邽��
        // �ύX��Ɉ��\��������
        this.gameObject.GetComponent<Canvas>().enabled = true;
        this.gameObject.SetActive(false);
    }

    void Update()
    {
        if(this.gameObject.GetComponent<Canvas>().enabled == false) { return; }

        InputKEY();
        RectPos();
    }
    
    private void setVol()
    {
        // �R���|�[�l���g�̒l�ύX
        Vol_Audio();
        // �e�L�X�g�ƃo�[�ύX
        Vol_Text();
        Vol_Bar();
    }

    // ����
    private void InputKEY()
    {
        // ����
       // if (Input.GetKeyDown(KeyCode.Escape)) { this.gameObject.SetActive(false); }

        // �I��
        if (Input.GetKeyDown(KeyCode.W)|| Input.GetKeyDown(KeyCode.UpArrow))
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
            Vol(num,"A");
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            Vol(num,"D");
        }

        // ����
        if (Input.GetKeyDown(KeyCode.Return) && num== SetPos.Length - 1)
        {
            // �Ō�ɒl��ۑ�������
            Sdata.Para_Master = M_num;
            Sdata.Para_Bgm = B_num;
            Sdata.Para_Se = S_num;

            this.gameObject.SetActive(false);
        }
    }
    
    // Width��Height�ƍ��W�̕ύX
    void RectPos()
    {
        ImageOutLine.anchoredPosition = SetPos[num].anchoredPosition;
        ImageOutLine.sizeDelta = SetPos[num].sizeDelta;
    }

    // ���ʒ����̒l�̕ύX
    void Vol(int List_num,string mark)
    {
        // mark�ϐ���AorD�Œl�𑝉�����̂����������邩�̔���
        if (mark == "A")
        {
            switch (List_num)
            {
                case 0:
                    if (M_num == MinVol) { return; }
                    else {
                        --M_num;
                        
                    }
                    break;
                case 1:
                    if (B_num == MinVol) { return; }
                    else { 
                        --B_num; 
                    }
                    break;
                case 2:
                    if (S_num == MinVol) { return; }
                    else { 
                        --S_num;
                    }
                    break;
            }
        }
        else if (mark == "D")
        {
            switch (List_num)
            {
                case 0:
                    if (M_num == MaxVol) { return; }
                    else { ++M_num; }
                    break;
                case 1:
                    if (B_num == MaxVol) { return; }
                    else { ++B_num; }
                    break;
                case 2:
                    if (S_num == MaxVol) { return; }
                    else { ++S_num; }
                    break;
            }
        }
        // �e�L�X�g�ƃo�[�ύX
        setVol();
    }

    private void Vol_Text()
    {
        Text_VolNum[0].text = M_num.ToString();
        Text_VolNum[1].text = B_num.ToString();
        Text_VolNum[2].text = S_num.ToString();
    }

    private void Vol_Bar()
    {
        // ��U�S�Ă̔�\����
        for (int i = 0; i <= MaxVol; i++)
        {
            if (i > 0)
            {
                Master_VolImage[i - 1].SetActive(false);
                BGM_VolImage[i - 1].SetActive(false);
                SE_VolImage[i - 1].SetActive(false);
            }
        }

        // �}�X�^�[�{�����[���̃o�[�ύX
        for (int i=0;i<=M_num;i++)
        {
            if (i > 0) {
                Master_VolImage[i-1].SetActive(true);
            }       
        }
        // BGM�{�����[���̃o�[�ύX
        for (int i = 0; i <= B_num; i++)
        {
            if (i > 0)
            {
                BGM_VolImage[i - 1].SetActive(true);
            }
        }
        // SE�{�����[���̃o�[�ύX
        for (int i = 0; i <= S_num; i++)
        {
            if (i > 0)
            {
                SE_VolImage[i - 1].SetActive(true);
            }
        }
    }

    private void Vol_Audio()
    {
        // �}�X�^�[�{�����[��
        AudioListener.volume = M_num*0.1f;
        // BGM
        B_Audio.volume = B_num*0.1f;
        // SE
        S_Audio.volume = S_num*0.1f;
    }
}
