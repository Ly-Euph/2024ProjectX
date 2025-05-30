using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Normal_Stage3 : MonoBehaviour,IDamageable
{
    #region field
    private Cinemachine.CinemachineDollyCart dolly;
    private Cinemachine.CinemachinePathBase myPath;

    [SerializeField] Cinemachine.CinemachinePathBase[] path;

    [SerializeField] GameObject deathHitEff;
    Vector3 ofsPos = new Vector3(0, 4, 0);
    float lifeT = 1.0f;

    private int[,] root = { { 0, 2, 7 ,7},{ 0, 5, 6, 7},{ 1, 6, 7, 7},
                            { 1, 5, 6, 7},{ 1, 5, 2, 7},{ 3, 4, 7, 7} };

    public int stage;
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
        stage = 0;
        INT_rootRand = Random.Range(0, 6);
        myPath = path[root[INT_rootRand, stage]];

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
        if (dieFlag == true)
        {
            Destroy(gameObject, 3.0f);
            return;
            //_DEATH.enabled = true;
        }

        this.dolly.m_Path = myPath;
        SwitchStage();


        timer += Time.deltaTime;
        if (timer >= 4f)
        {
            timer = 0;
            randWait = Random.Range(1, 21);
            if (randWait == 1)
            {
                animNum = 1;
                //StartCoroutine("IdleWait");
            }
            else
            {
                animNum = 0;
            }
        }
        //if (Input.GetKeyDown(KeyCode.J))
        //{
        //    hp -= 10;
        //}
        EmDie();
        Animation();


    }

    void SwitchStage()
    {
        if (dolly.m_Position == 4 && hitFlag == true)
        {
            stage++;
            myPath = path[root[INT_rootRand, stage]];
            dolly.m_Position = 0;
            hitFlag = false;
        }
    }


    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Door")
        {
            //Debug.Log("衝突");
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
            // エフェクト生成
            var myObj = this.gameObject.transform;
            Instantiate(deathHitEff, myObj.position, myObj.rotation);
            dolly.m_Speed = 0;
            animNum = 2;
            //Destroy(deathHitEff, lifeT);
            //Debug.Log("死亡");
        }
    }


    void Animation()
    {
        switch (animNum)
        {
            case 0:
                dolly.m_Speed = 0.4f;
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
                anim.SetBool("Dead", true);
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
