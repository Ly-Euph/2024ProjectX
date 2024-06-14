using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Normal : MonoBehaviour
{
    private Cinemachine.CinemachineDollyCart dolly;     //Cinemachineのdolly cartを取得

    private Cinemachine.CinemachinePathBase myPath;     //自身のパス

    [SerializeField] Cinemachine.CinemachinePathBase[] path;       //ルートのパス


    public int stage;


    private int[,] root = { { 0, 2, 6 }, { 0, 3, 6 }, { 0, 4, 6 }, 
                            { 1, 3, 6 }, { 1, 4, 6 }, { 1, 2, 6 }, 
                            { 2, 6, 6 } };

    private int rootRand;


    // Start is called before the first frame update
    void Start()
    {
        dolly = GetComponent<Cinemachine.CinemachineDollyCart>();
        dolly.m_Speed = 0.2f;           //移動スピード0.2

        stage = 0;


        rootRand = Random.Range(0, 7);

        myPath = path[root[rootRand, stage]];

    }

    // Update is called once per frame
    void Update()
    {

        this.dolly.m_Path = myPath;

        SwitchStage();


        if(stage==2)
        {
            Destroy(gameObject);
            Debug.Log("Normalによりgame over");
        }

        //AnimControlle();
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
