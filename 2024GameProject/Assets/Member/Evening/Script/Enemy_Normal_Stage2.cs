using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Normal_Stage2 : MonoBehaviour, IDamageable
{
    #region field
    private Cinemachine.CinemachineDollyCart dolly;
    private Cinemachine.CinemachinePathBase myPath;

    [SerializeField] Cinemachine.CinemachinePathBase[] path;

    private int[,] root = { { 1, 7, 9, 9, 9, 9}, { 2, 6, 9, 9, 9, 9}, { 2, 8, 5, 9, 9, 9},
                            { 2, 8, 3, 9, 9, 9}, { 4, 0, 6, 8, 5, 9}, { 4, 0, 6, 8, 3, 9},
                            { 4, 0, 9, 9, 9, 9}, { 8, 5, 9, 9, 9, 9}, { 8, 3, 9, 9, 9, 9} };

    private int INT_stage;
    private int INT_rootRand;


    private Animator anim;

    private int animNum;

    private float timer;

    private int randWait;

    private int hp;

    private bool hitFlag;

    //private float dieTimer;
    private bool dieFlag;
    #endregion

    #region Method
    // Start is called before the first frame update
    void Start()
    {
        dolly = GetComponent<Cinemachine.CinemachineDollyCart>();

        myPath = path[0];
        INT_stage = 0;
        INT_rootRand = Random.Range(0, 7);
        myPath = path[root[INT_rootRand, INT_stage]];

        anim = GetComponent<Animator>();
        animNum = 0;
        timer = 0;
        randWait = 0;

        hp = 10;

        hitFlag = false;

        //dieTimer = 0;
        dieFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
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
        //if (Input.GetKeyDown(KeyCode.J))
        //{
        //    hp -= 10;
        //}
        EmDie();
        Animation();
        if (dieFlag == true)
        {
            Destroy(gameObject);
            //_DEATH.enabled = true;
        }

    }

    void SwitchStage()
    {
        if (dolly.m_Position == 4 && hitFlag == true)
        {
            INT_stage++;
            myPath = path[root[INT_rootRand, INT_stage]];
            dolly.m_Position = 0;
            hitFlag = false;
        }
    }


    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Door")
        {
            //Debug.Log("�Փ�");
            hitFlag = true;
        }
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
    }

    void EmDie()
    {
        if (hp <= 0)
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
                break;

            case 1:
                dolly.m_Speed = 0;
                anim.SetBool("Run", false);
                anim.SetBool("Idle", true);
                break;

            case 2:
                dolly.m_Speed = 0;
                anim.SetBool("Run", false);
                anim.SetBool("Idle", false);
                dieFlag = true;
                break;
        }
    }

    IEnumerator IdleWait()
    {
        yield return new WaitForSeconds(5.0f);

        animNum = 0;
    }
    #endregion
}