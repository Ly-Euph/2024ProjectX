using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Hide : MonoBehaviour
{
    private Cinemachine.CinemachineDollyCart dolly;
    private Cinemachine.CinemachinePathBase myPath;

    [SerializeField] Cinemachine.CinemachinePathBase[] path;


    Transform tr;


    SkinnedMeshRenderer skin;


    public GameObject cam;

    GameObject duct;
    //Vector3 ductPos;


    private bool camScan;
    private float scanTime;

    private int[,] root = { { 0, 2, 6 }, { 0, 3, 6 }, { 0, 4, 6 },
                            { 1, 3, 6 }, { 1, 4, 6 }, { 1, 2, 6 },
                            { 2, 6, 6 } };

    private int rootRand;

    public int stage;

    // Start is called before the first frame update
    void Start()
    {

        dolly = GetComponent<Cinemachine.CinemachineDollyCart>();

        myPath = path[0];


        tr = GetComponent<Transform>();

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
    }

    // Update is called once per frame
    void Update()
    {
        SwitchStage();
        this.dolly.m_Path = myPath;
        if (Input.GetKeyDown(KeyCode.C))
        {
            camScan = true;
        }

        EnemyMove();


        if (camScan == true)
        {
            CamScan();
            scanTime += 1 / 60f;
        }

        if (stage == 2)
        {
            Destroy(gameObject);
            Debug.Log("Hide‚É‚æ‚Á‚Ägame over");
        }

    }

    void EnemyMove()
    {
        
    }




    void CamScan()
    {
        Debug.Log("ƒXƒLƒƒƒ“’†");

        skin.enabled = true;

        if(scanTime>=4)
        {
            scanTime = 0;
            skin.enabled = false;
            camScan = false;
        }
    }


    void SwitchStage()
    {
        if (dolly.m_Position == 4)
        {
            stage++;
            myPath = path[root[rootRand, stage]];
            dolly.m_Position = 0;
        }
    }


}
