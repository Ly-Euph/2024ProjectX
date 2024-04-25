using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleCursor : MonoBehaviour
{
    [SerializeField] RectTransform[] ObjRect;  // ���W�Q�Ƃ�text
    RectTransform myObjRect;                   // ������text
    int num;
    int Max;
    int Min;
    void Start()
    {
        // �R���|�[�l���g�擾
        myObjRect = GetComponent<RectTransform>();
        // �z��ԍ���Max���擾
        Max = ObjRect.Length-1;
        // �z��ԍ���Min��0�Ƃ���
        Min = 0;
    }
    // ���͊֘A
    void InputKey() {
        if(Input.GetKeyDown(KeyCode.W)
            ||Input.GetKeyDown(KeyCode.UpArrow)) // ��
        {
            if(num==Min)
            {
                num = Max;
            }
            else
            {
                num -= 1;
            }
        }
        else if (Input.GetKeyDown(KeyCode.S) 
            || Input.GetKeyDown(KeyCode.DownArrow)) // ��
        {
            if(num==Max)
            {
                num = Min;
            }
            else
            {
                num += 1;
            }
        }
        else if(Input.GetKeyDown(KeyCode.Return)) // ����
        {
            switch (num)
            {
                case 0: // START�{�^��

                    break;
                case 1: // OPTION�{�^��

                    break;
                case 2: // END�{�^�� 
#if UNITY_EDITOR
                    UnityEditor.EditorApplication.isPlaying = false;//�Q�[���v���C�I��
#else
    Application.Quit();//�Q�[���v���C�I��
#endif

                    break;
            }
        }
    }
    void RectPos()
    {
        this.gameObject.GetComponent<RectTransform>().anchoredPosition =
          ObjRect[num].anchoredPosition ;
    }
    // Update is called once per frame
    void Update()
    {
        InputKey();
        RectPos();
    }
}
