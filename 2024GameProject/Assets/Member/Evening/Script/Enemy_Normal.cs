using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Normal : MonoBehaviour,IDamageable
{
    private Cinemachine.CinemachineDollyCart dolly;     //Cinemachineのdolly cartを取得

    private Cinemachine.CinemachinePathBase myPath;     //自身のパス

    [SerializeField] Cinemachine.CinemachinePathBase[] path;       //ルートのパス


    private Animator anim;


    private float timer = 0f;
    private int randWait;

    public int animNum;
    public int hp = 10;
    public int stage;

    //0:room1
    //1:room2
    //2:room3
    //3:room4
    //4:room5
    //5:room6
    //6:plRoom
    private int[,] root = { { 0, 2, 5, 6 }, { 0, 3, 6, 6 }, { 0, 4, 6, 6 },
                            { 1, 3, 6, 6 }, { 1, 4, 6, 6 }, { 1, 2, 5, 6 },
                            { 2, 5, 6, 6 } };

    private int rootRand;

    public bool hitFlag;


    // Start is called before the first frame update
    void Start()
    {
        dolly = GetComponent<Cinemachine.CinemachineDollyCart>();
        dolly.m_Speed = 0.2f;           //移動スピード0.2

        anim = GetComponent<Animator>();

        animNum = 0;
        stage = 0;
        hp = 10;

        rootRand = Random.Range(0, 7);

        myPath = path[root[rootRand, stage]];

        hitFlag = false;

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer>=2f)
        {
            timer = 0;
            randWait = Random.Range(1, 21);
            if(randWait==1)
            {
                animNum = 1;
                StartCoroutine("IdleWait");
            }
        }


        EmDie();
        Animation();


        this.dolly.m_Path = myPath;


        //部屋移動
        SwitchStage();


        //Player死亡
        if(stage==2)
        {
            Destroy(gameObject);
            Debug.Log("Normalによりgame over");
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
        if(hp==0)
        {
            dolly.m_Speed = 0;
            animNum = 2;
            //Debug.Log("死亡");
        }
    }


    void Animation()
    {
        switch(animNum)
        {
            case 0:
                dolly.m_Speed = 0.2f;
                anim.SetBool("Run", true);
                anim.SetBool("Idle", false);
                anim.SetBool("Dead", false);
                break;

            case 1:
                dolly.m_Speed = 0;
                anim.SetBool("Run",false);
                anim.SetBool("Idle", true);
                anim.SetBool("Dead", false);
                break;

            case 2:
                dolly.m_Speed = 0;
                anim.SetBool("Run", false);
                anim.SetBool("Idle", false);
                anim.SetBool("Dead", true);
                break;
        }
    }

    IEnumerator IdleWait()
    {
        yield return new WaitForSeconds(5.0f);

        animNum = 0;
    }


}
