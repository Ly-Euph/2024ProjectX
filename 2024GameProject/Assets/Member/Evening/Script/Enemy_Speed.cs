using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Speed : MonoBehaviour
{
    private Cinemachine.CinemachineDollyCart dolly;

    private Cinemachine.CinemachinePathBase myPath;

    [SerializeField] Cinemachine.CinemachinePathBase[] path;

    public int stage;

    private int[,] root = { { 0, 2, 6 }, { 0, 3, 6 }, { 0, 4, 6 },
                            { 1, 3, 6 }, { 1, 4, 6 }, { 1, 2, 6 },
                            { 2, 6, 6 } };

    private int rootRand;
    // Start is called before the first frame update
    void Start()
    {
        dolly = GetComponent<Cinemachine.CinemachineDollyCart>();

        dolly.m_Speed = 0.4f;

        myPath = path[0];

        stage = 0;

        rootRand = Random.Range(0, 7);

        myPath = path[root[rootRand, stage]];
        //Debug.Log(rootRand);
    }

    // Update is called once per frame
    void Update()
    {
        this.dolly.m_Path = myPath;

        SwitchStage();

        if(stage==2)
        {
            Destroy(gameObject);
            Debug.Log("Speed‚É‚æ‚ègame over");
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
