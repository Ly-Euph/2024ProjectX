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


    GameObject duct;
    //Vector3 ductPos;


    private bool camScan;
    private float scanTime;

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
    }

    // Update is called once per frame
    void Update()
    {
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
}
