using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // UI���g���悤��
using System; //DateTime���g�p����גǉ��B
using UnityEngine.SceneManagement;

public class UpMessageText : MonoBehaviour
{
    #region 
    // ���f������I�u�W�F�N�g
    [SerializeField] Text UpText;

    // �ꕶ�����Ƃ̕\���ɂ����鎞��
    [SerializeField] float delay = 0.3f;

    // �V�[���J�ڂɎg��
    [SerializeField] Fade fade;

    //DateTime���g�����ߕϐ���ݒ�
    DateTime TodayNow;

    // ���Đ��ɂ���
    [SerializeField] GameManager gMng;

    // ���Ԃƕ����̎擾�p
    float hour;
    float minute;

    // ���t�̎擾�p
    int month;
    int day;
    int year;

    // �X�C�b�`����
    int num = 0;
    
    // �������ꌅ�̎��ɐ擪��0������
    string minuteString;
    // ���t�ł������悤��
    string monthString;
    string dayString;

    [SerializeField]string message = "You've survived!";

    string stringAll_Up;   // ��s�ڂ̃e�L�X�g�܂Ƃ�

    // �Q�[���I�[�o�[�V�[���݂̂ł���
    [SerializeField] bool IsGameOver = false;
    [SerializeField] MeshRenderer[] EffObj;

    float addPoint=0.1f;
    float effPoint = 0;
    #endregion
   
    #region Method
    // ���t�\��
    void SetDate()
    {
        month = TodayNow.Month;

        day = TodayNow.Day;

        year = TodayNow.Year;

        // �����ꌅ�̏ꍇ�擪��0��ǉ�
        if (month <= 9)
        {
            monthString = "0" + month.ToString();
        }
        else
        {
            monthString = month.ToString();
        }

        // �����ꌅ�̏ꍇ�擪��0��ǉ�
        if (day <= 9)
        {
            dayString = "0" + day.ToString();
        }
        else
        {
            dayString = day.ToString();
        }

        // �܂Ƃ߂ē���Ă���
        stringAll_Up += monthString + "�^" + dayString+"�^"+year.ToString();
        // ���s����
        stringAll_Up += "\n";
    }

    // �����\��
    //void SetTime()
    //{
    //    // ���Ԃ��擾
    //    hour = TodayNow.Hour;
    //    minute = TodayNow.Minute;

    //    // �������ꌅ�̏ꍇ�擪��0��ǉ�
    //    if (minute <= 9)
    //    {
    //        minuteString = "0" + minute.ToString();
    //    }
    //    else
    //    {
    //        minuteString = minute.ToString();
    //    }

    //    // �܂Ƃ߂ē���Ă���
    //    stringAll_Up += "�@"+ hour + " : " + minuteString;
    //}

    // ���b�Z�[�W��ǉ�
    void SetMessage()
    {
        stringAll_Up +=message.ToString();
    }

    IEnumerator RevealText()
    {
        // �ꕶ�����\��
        foreach (char c in stringAll_Up)
        {
            UpText.text += c;
            gMng.OneShotSE_U(SEData.Type.ETC,GameManager.UISe.textmsg);
            yield return new WaitForSecondsRealtime(delay); // �w�莞�ԑҋ@
        }
    }
    #endregion
    void Start()
    {
        // �����폜
        UpText.text = "";

        //���Ԃ��擾
        TodayNow = DateTime.Now;

        SetDate();
        SetMessage();
        //SetTime();
    }
    private void Update()
    {
        switch(num)
        {

            case 0:
                // �R���[�`���J�n
                StartCoroutine(RevealText());
                num++;
                break;
            case 1:
                if (UpText.text == stringAll_Up)
                {
                    num++;
                }
                break;
            case 2:
                if (!IsGameOver)
                {
                    fade.FadeIn(0.5f, () => SceneManager.LoadScene("TitleScene"));
                    num = 999; // �͈͊O�ɂ���
                }
                else
                {
                    num++;
                }
                break;
            case 3:
                effPoint += addPoint;
                EffObj[0].material.SetFloat("_Progress", effPoint);
                EffObj[1].material.SetFloat("_Progress", effPoint);
                if(effPoint>=1.0f)
                {
                    num++;
                }
                break;
            case 4:
                EffObj[0].material.SetFloat("_Progress", 1);
                EffObj[1].material.SetFloat("_Progress", 1);
                effPoint -= addPoint;
                if (effPoint <= 0.0f)
                {
                    fade.FadeIn(0.5f, () => SceneManager.LoadScene("TitleScene"));
                    num = 999; // �͈͊O�ɂ���
                }
                break;

        }
    }

   
}
