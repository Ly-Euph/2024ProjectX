using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeCounter : MonoBehaviour
{
    [Header("�����Ŏ��Ԑ����̑�����s���ĂˁB")]

    [SerializeField] int TimeMinute = 15;

    private float TimeSecond;
    private bool TimeLimit = false;
    private Text TimeText;

    

    
    // Start is called before the first frame update
    void Start()
    {
        TimeText = GetComponent<Text>();
        TimeSecond = TimeMinute * 60;
    }

    // Update is called once per frame
    void Update()
    {
        if (!TimeLimit)
        {
            //timeScale�ŃQ�[�������Ԃ�M��܂����B

            TimeSecond -= Time.deltaTime;
            
            //TimeSpan��mm\:ss�Ŏ��Ԑ������ȒP�ɐ���ł���悤�ɁB
            //�ϐ�TimeSecond�̒l���Q�ƁB

            var span = new TimeSpan(0, 0, (int)TimeSecond);�@
            TimeText.text = span.ToString(@"mm\:ss");
        }
        if (TimeSecond < 0)
        {
            Debug.Log("�N���A�I�I");
            TimeLimit = true;

            //�V�[���ڍs�̏���
            FadeManager.Instance.LoadScene("TitleScene",1.0f);
            //����̓N���A�����X�e�[�W��ClearScene�Ɉڍs����\��ł��B
        }
    }
}
