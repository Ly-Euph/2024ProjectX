using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SensorText : MonoBehaviour
{
    #region
    // ��i�A���i�A���i�̏���
    [SerializeField] Text[] text;
    // �e�L�X�g�ɔ��f�����镶���͂�������擾
    [SerializeField] SensorManager Mng;
    // ���Ŏ擾���ꂽ���̂�ۑ�����
    private string message;


    // �e�i�ł���
    bool top = false;
    bool center = false;
    bool under = false;

    float colTop = 1.0f;
    float colCenter = 1.0f;
    float colUnder = 1.0f;

    float timerTop;
    float timerCenter;
    float timerUnder;

    // �Z�b�g����
    float timerSet = 5.0f;
    #endregion
    void Start()
    {
        for(int i=0;i<text.Length;i++)
        {
            // �e�L�X�g��������
            text[i].text = "";
        }
    }

    void Update()
    {
        // �����Z�b�g
        if(Mng.Recieve)
        {
            UnderSet();
        }


        // �t�F�[�h���Ă���
        Cooltime();
        if (timerTop<=0)
        {
            FadeText();
        }
        if(timerCenter <= 0)
        {
            FadeText();

        }
        if (timerUnder <= 0)
        {
            FadeText();
        }
    }

    #region Method
    // ���i�ɐV�K�Z�b�g
    // ���X�̂���i�ɂ��Ă���
    private void UnderSet()
    {
        CenterSet();
        text[2].text = "["+Mng.GSSencor+"]:Enemy".ToString();
        if (text[2].text != "")
        {
            under = true;
            timerUnder = timerSet;
            colUnder = 1.0f;
            text[2].color = new Color(1, 1, 1, colUnder);
        }
    }
    private void CenterSet()
    {
        TopSet();
        text[1].text = text[2].text.ToString();
        if (text[1].text != "")
        {
            center = true;
            timerTop = timerSet;
            colCenter = 1.0f;
            text[1].color = new Color(1, 1, 1, colCenter);
        }
    }
    private void TopSet()
    {
        text[0].text = text[1].text.ToString();

        if(text[0].text!="")
        {
            top = true;
            timerTop = timerSet;
            colTop = 1.0f;
            text[0].color = new Color(1, 1, 1, colTop);
        }
    }

    // �t�F�[�h������O�̃N�[���^�C��
    void Cooltime()
    {
        if(top)
        {
            timerTop-=Time.deltaTime;
        }
        if (center)
        {
            timerCenter -= Time.deltaTime;
        }
        if (under)
        {
            timerUnder -= Time.deltaTime;
            Debug.Log(timerUnder);
        }
    }

    // �t�F�[�h����
    void FadeText()
    {
        if (top)
        {
            text[0].color = new Color(1, 1, 1, colTop);
            colTop -= 0.01f;

            if (colTop <= 0)
            {
                colTop = 1.0f;
                timerTop = timerSet;
                top = false;
                text[0].text = "";
            }
        }
        if(center)
        {
            text[1].color = new Color(1, 1, 1, colCenter);
            colCenter -= 0.01f;

            if (colCenter <= 0)
            {
                colCenter = 1.0f;
                timerCenter = timerSet;
                center = false;
                text[1].text = "";
            }
        }
        if(under)
        {
            text[2].color = new Color(1, 1, 1, colUnder);
            colUnder -= 0.01f;

            if (colUnder <= 0)
            {
                colUnder = 1.0f;
                timerUnder = timerSet;
                under = false;
                text[2].text = "";
            }
        }
    }
    #endregion
}
