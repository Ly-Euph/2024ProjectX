using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Normal : MonoBehaviour
{
    private Cinemachine.CinemachineDollyCart dolly;     //Cinemachine��dolly cart���擾

    private Cinemachine.CinemachinePathBase myPath;     //���g�̃p�X

    public Cinemachine.CinemachinePathBase path1;       //
    public Cinemachine.CinemachinePathBase path2;       //
    public Cinemachine.CinemachinePathBase path3;       //
    public Cinemachine.CinemachinePathBase path4;       //
    public Cinemachine.CinemachinePathBase path5;       //
    public Cinemachine.CinemachinePathBase path6;       //��L6�͂��ꂼ��̃��[�g

    private Animator anim;                              //�A�j���[�V����
    private int animNum;                                //�A�j���[�V�������Ǘ����鐔��
    

    private int stage;                                  
    private float waitTime;                             //���g�̒�~����


    private bool countFlag;                             //true�Ń^�C�}�[���쓮


    // Start is called before the first frame update
    void Start()
    {
        dolly = GetComponent<Cinemachine.CinemachineDollyCart>();
        dolly.m_Speed = 0.2f;           //�ړ��X�s�[�h0.2

        anim = GetComponent<Animator>();
        animNum = 0;                    //0�̃A�j���[�V�������Đ�(����)

        myPath = path1;

        stage = 0;

        waitTime = 0.0f;

        countFlag = false;

    }

    // Update is called once per frame
    void Update()
    {

        this.dolly.m_Path = myPath;

        SwitchStage();
        InputKey();         //
        CharactorMove();

        if (countFlag == true)
        {
            TimerCount();
        }
        else if (countFlag == false)
        {
            animNum = 0;
            dolly.m_Speed = 0.2f;
            Debug.Log("false");
        }

        AnimControlle();
    }


    void SwitchStage()
    {
        switch(stage)
        {
            case 0:
                stage = 100;
                myPath = path1;
                dolly.m_Position = 0;
                break;

            case 1:
                stage = 100;
                myPath = path2;
                dolly.m_Position = 0;
                break;

            case 2:
                stage = 100;
                myPath = path3;
                dolly.m_Position = 0;
                break;

            case 3:
                stage = 100;
                myPath = path4;
                dolly.m_Position = 0;
                waitTime = 7.5f;
                break;

            case 4:
                stage = 100;
                myPath = path5;
                dolly.m_Position = 0;
                break;

            case 5:
                stage = 100;
                myPath = path6;
                dolly.m_Position = 0;
                break;

        }
    }

    void InputKey()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            stage = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            stage = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            stage = 2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            stage = 3;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            stage = 4;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            stage = 5;
        }
    }

    void CharactorMove()
    {
        if (waitTime > 0f && dolly.m_Position >= 2)
        {
            animNum = 1;
            Debug.Log("��~");
            countFlag = true;
        }
    }

    void TimerCount()
    {
        dolly.m_Speed = 0f;

        if (waitTime > 0f)
        {
            waitTime -= Time.deltaTime;
        }
        countFlag = false;
    }

    void AnimControlle()
    {
        switch(animNum)
        {
            case 0:
                anim.ResetTrigger("idle");
                Debug.Log("Run");
                anim.SetTrigger("run");
                break;

            case 1:
                anim.ResetTrigger("run");
                Debug.Log("Idle");
                anim.SetTrigger("idle");
                break;

            case 2:
                Debug.Log("Dead");
                anim.SetTrigger("dead");
                break;
        }
    }

}
