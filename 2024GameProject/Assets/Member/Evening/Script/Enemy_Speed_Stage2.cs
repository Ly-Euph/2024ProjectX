using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Speed_Stage2 : MonoBehaviour, IDamageable
{
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

    private bool dieFlag;

    // Start is called before the first frame update
    void Start()
    {
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

        dieFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        this.dolly.m_Path = myPath;
        SwitchStage();

        //if (Input.GetKeyDown(KeyCode.J))
        //{
        //    hp -= 10;
        //}
        EmDie();
        Animation();

        if (dieFlag == true)
        {
            Destroy(gameObject);
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