using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Jammer : MonoBehaviour
{

    private float timer;

    private Cinemachine.CinemachineDollyCart dolly;

    private Cinemachine.CinemachinePathBase myPath;
    [SerializeField] Cinemachine.CinemachinePathBase[] path;

    Animator anim;

    private int animNum;

    void Start()
    {
        timer = 0f;

        dolly = GetComponent<Cinemachine.CinemachineDollyCart>();

        dolly.m_Speed = 0.2f;

        myPath = path[0];

        anim = GetComponent<Animator>();
        animNum = 0;
    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;

        this.dolly.m_Path = myPath;


        if (timer <= 2.5f)
        {
            //Debug.Log("idle");
            animNum = 0;

        }
        else if (timer > 1.5f && dolly.m_Position != 1)
        {
            //Debug.Log("Walk");
            animNum = 1;

        }
        else if (dolly.m_Position == 1)
        {
            //Debug.Log("camHack");
            animNum = 0;
        }
        Anim();

    }

    void Anim()
    {
        switch(animNum)
        {
            case 0:
                dolly.m_Speed = 0f;
                anim.SetBool("Idle", true);
                anim.SetBool("Walk", false);
                anim.SetBool("Hack", false);
                break;

            case 1:
                dolly.m_Speed = 0.3f;
                anim.SetBool("Idle", false);
                anim.SetBool("Walk", true);
                anim.SetBool("Hack", false);
                break;

            case 2:
                anim.SetBool("Idle", false);
                anim.SetBool("Walk", false);
                anim.SetBool("Hack", true);
                break;



        }
    }


}
