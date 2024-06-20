using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Hide : MonoBehaviour
{
    private Cinemachine.CinemachineDollyCart dolly;
    private Cinemachine.CinemachinePathBase myPath;

    [SerializeField] Cinemachine.CinemachinePathBase[] path;


    SkinnedMeshRenderer skin;


    public GameObject cam;

    GameObject duct;
    //Vector3 ductPos;


    private bool camScan;
    private float scanTime;

    private int[,] root = { { 0, 2, 6 }, { 0, 3, 6 }, { 0, 4, 6 },
                            { 1, 3, 6 }, { 1, 4, 6 }, { 1, 2, 6 },
                            { 2, 5, 6 } };

    private int rootRand;

    public int stage;

    private bool hitFlag;

    // Start is called before the first frame update
    void Start()
    {

        dolly = GetComponent<Cinemachine.CinemachineDollyCart>();

        myPath = path[0];

        skin = GetComponentInChildren<SkinnedMeshRenderer>();

        //duct = GameObject.FindGameObjectWithTag("duct");
        //ductPos = duct.transform.position;

        //tr.position = ductPos;
        skin.enabled = false;


        camScan = false;
        scanTime = 0;

        stage = 0;

        rootRand = Random.Range(0, 7);

        myPath = path[root[rootRand, stage]];
        //Debug.Log(rootRand);

        hitFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        SwitchStage();
        this.dolly.m_Path = myPath;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            skin.enabled = true;
        }
        else
        {
            skin.enabled = false;
        }


        if (stage == 2)
        {
            Destroy(gameObject);
            Debug.Log("Hide‚É‚æ‚Á‚Ägame over");
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
        if(collision.gameObject.tag=="Door")
        {
            hitFlag = true;
        }
    }


}
