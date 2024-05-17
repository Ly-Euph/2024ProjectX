using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Normal : MonoBehaviour
{
    private Cinemachine.CinemachineDollyCart dolly;

    private Cinemachine.CinemachinePathBase myPath;
    public Cinemachine.CinemachinePathBase path1;
    public Cinemachine.CinemachinePathBase path2;
    public Cinemachine.CinemachinePathBase path3;
    public Cinemachine.CinemachinePathBase path4;
    public Cinemachine.CinemachinePathBase path5;
    public Cinemachine.CinemachinePathBase path6;

    private Animator anim;


    private int stage;
    private float waitTime;


    private bool countFlag;


    // Start is called before the first frame update
    void Start()
    {
        dolly = GetComponent<Cinemachine.CinemachineDollyCart>();
        dolly.m_Speed = 0.2f;

        anim.SetFloat("EnemyAnim", 2);

        myPath = path1;

        anim = gameObject.GetComponent<Animator>();

        stage = 0;

        waitTime = 0.0f;

        countFlag = false;

    }

    // Update is called once per frame
    void Update()
    {

        this.dolly.m_Path = myPath;

        SwitchStage();
        InputKey();
        CharactorMove();

        if (countFlag == true)
        {
            TimerCount();
        }
        else if (countFlag == false)
        {
            dolly.m_Speed = 0.2f;
            Debug.Log("false");
        }


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
            anim.SetFloat("EnemyAnim", 1);

            Debug.Log("’âŽ~");
            countFlag = true;
        }
    }

    void TimerCount()
    {
        dolly.m_Speed = 0f;

        if (waitTime > 0f)
        {
            waitTime -= 1 / 60f;
        }
        countFlag = false;
    }


}
