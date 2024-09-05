using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // UI���g���悤��
using System; //DateTime���g�p����גǉ��B

public class DateTimeText : MonoBehaviour
{
    #region 
    // ���f������I�u�W�F�N�g
    [SerializeField] Text text;

    //DateTime���g�����ߕϐ���ݒ�
    DateTime TodayNow;

    float hour;
    float minute;

    string minuteString;
    #endregion
    void Start()
    {

     

    }

    // ���t�\��
    void SetDate()
    {

    }

    // �����\��
    void SetTime()
    {
        //���Ԃ��擾
        TodayNow = DateTime.Now;

        // ���Ԃ��擾
        hour = TodayNow.Hour;
        minute = TodayNow.Minute;

        // �������ꌅ�̏ꍇ0������
        if (minute <= 9)
        {
            minuteString = "0" + minute.ToString();
        }
        else
        {
            minuteString = minute.ToString();
        }

        //�e�L�X�gUI�ɔ��f�\��
        text.text = hour + "�F" + minuteString.ToString();
    }
}
