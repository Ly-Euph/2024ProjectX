using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Hide_Stage2 : MonoBehaviour, IDamageable
{
    CameraManager camMng;

    private Cinemachine.CinemachineDollyCart dolly;
    private Cinemachine.CinemachinePathBase myPath;

    [SerializeField] Cinemachine.CinemachinePathBase[] path;

    private int[,] root = { { 1, 7, 9, 9, 9, 9}, { 2, 6, 9, 9, 9, 9}, { 2, 8, 5, 9, 9, 9},
                            { 2, 8, 3, 9, 9, 9}, { 4, 0, 6, 8, 5, 9}, { 4, 0, 6, 8, 3, 9},
                            { 4, 0, 9, 9, 9, 9}, { 8, 5, 9, 9, 9, 9}, { 8, 3, 9, 9, 9, 9} };
    public int stage;
    private int rootRand;


    private Animator anim;

    private int animNum;

    private float timer;

    private int randWait;

    private int hp;

    private bool hitFlag;

    private float dieTimer;
    private bool dieFlag;

    private bool hydeFlag;

    SkinnedMeshRenderer skin;
    // Start is called before the first frame update
    void Start()
    {
        camMng = GameObject.Find("CameraManager").GetComponent<CameraManager>();

        dolly = GetComponent<Cinemachine.CinemachineDollyCart>();

        myPath = path[0];
        stage = 0;
        rootRand = Random.Range(0, 7);
        myPath = path[root[rootRand, stage]];

        anim = GetComponent<Animator>();
        animNum = 0;
        timer = 0;
        randWait = 0;

        hp = 10;

        hitFlag = false;

        dieTimer = 0f;
        dieFlag = false;


        skin = GetComponentInChildren<SkinnedMeshRenderer>();
        skin.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        hydeFlag = camMng.SendtrapFlg;

        this.dolly.m_Path = myPath;
        SwitchStage();

        timer += Time.deltaTime;
        if (timer >= 2f)
        {
            timer = 0;
            randWait = Random.Range(1, 21);
            if (randWait == 1)
            {
                animNum = 1;
                StartCoroutine("IdleWait");
            }
        }

        EmDie();
        Animation();

        if (dieFlag == true)
        {
            dieTimer += Time.deltaTime;
            if (dieTimer >= 5f)
            {
                Destroy(gameObject);
            }
        }


        if (hydeFlag==true)
        {
            skin.enabled = true;
        }
        else if(hydeFlag==false)
        {
            skin.enabled = false;
        }
    }


    void SwitchStage()
    {
        if (dolly.m_Position == 4 && hitFlag == true)
        {
            stage++;
            myPath = path[root[rootRand, stage]];
            dolly.m_Position = 0;
            hitFlag = false;
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Door")
        {
            Debug.Log("door��hit");
            hitFlag = true;
        }
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
    }

    void EmDie()
    {
        if (hp == 0)
        {
            dolly.m_Speed = 0;
            animNum = 2;
            //Debug.Log("���S");
        }
    }

    void Animation()
    {
        switch (animNum)
        {
            case 0:
                dolly.m_Speed = 0.2f;
                anim.SetBool("Run", true);
                anim.SetBool("Idle", false);
                anim.SetBool("Dead", false);
                break;

            case 1:
                dolly.m_Speed = 0;
                anim.SetBool("Run", false);
                anim.SetBool("Idle", true);
                anim.SetBool("Dead", false);
                break;

            case 2:
                dolly.m_Speed = 0;
                anim.SetBool("Run", false);
                anim.SetBool("Idle", false);
                anim.SetBool("Dead", true);
                dieFlag = true;
                break;
        }
    }
    IEnumerator IdleWait()
    {
        yield return new WaitForSeconds(7.0f);

        animNum = 0;
    }
}
