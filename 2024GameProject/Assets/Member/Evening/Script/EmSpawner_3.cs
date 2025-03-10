using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmSpawner_3 : MonoBehaviour
{
    [Header("�����ɏ�������G��Prefab������")]
    [SerializeField] GameObject[] enemy;

    private GameObject[] em_Normal;
    private GameObject[] em_Speed;
    private GameObject[] em_Hide;

    private int[] spawnCost = { 1, 1, 2, 2, 3, 3 };     //�G�̂��ꂼ��̃R�X�g
    private int totalCost;                              //���ݑ��݂���G�̑��R�X�g
    private int maxCost = 30;                           //�G�̑��݂ł���ő�R�X�g

    private int[] probability = new int[] { 15, 30, 45, 60, 73, 100 };      //�e�G�̃X�|�[���m��

    [Header("�X�e�[�W�̑I��")]
    [SerializeField] StageCandidate stageName;

    public enum StageCandidate
    { 
        Stage1,
        Stage2,
        Stage3,
    }

    //�X�e�[�W���̓G���[�g
    public int[][] sendNum_Stage1 = new int[][]
        {
            new int[]{ 0, 2, 4, 6 },
            new int[]{ 0, 3, 5, 6 },
            new int[]{ 1, 2, 4, 6 },
            new int[]{ 1, 3, 5, 6 },
        };

    public int[][] sendNum_Stage2 = new int[][]
        {
            new int[]{ 1, 7, 9 },
            new int[]{ 2, 6, 9 },
            new int[]{ 2, 8, 5, 9 },
            new int[]{ 2, 8, 3, 9 },
            new int[]{ 4, 0, 6, 8, 5, 9 },
            new int[]{ 4, 0, 6, 8, 3, 9 },
            new int[]{ 4, 0, 9 },
            new int[]{ 8, 5, 9 },
            new int[]{ 8, 3, 9 },
        };


    public int[][] sendNum_Stage3 = new int[][]
        {
            new int[] {0,2,7},
            new int[] {0,5,6,7},
            new int[] {1,6,7},
            new int[] {1,5,6,7},
            new int[] {1,5,2,7},
            new int[] {3,4,7},
        };

    private int random;

    private int saveNum;

    private float timer;                    //�G�̃X�|�[������܂ł̎��Ԃ��Ǘ�
    private float setTime;                  //�Ȃ�ƂȂ��g���Ă�
    [Header("�G�̃X�|�[�����[�g(1��/s)")]
    public float spawnLate;

    private bool firstSpawnFlag;
    private void Start()
    {
        //random = Random.Range(0, System.Enum.GetValues(typeof(StageCandidate)).Length);
        setTime = 1.0f;
        totalCost = 0;

        firstSpawnFlag = true;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if(firstSpawnFlag==true)
        {
            timer = 0;
            CostCount();
        }
        else if(firstSpawnFlag==false)
        {
            em_Normal = GameObject.FindGameObjectsWithTag("NormalEnemy");
            em_Speed = GameObject.FindGameObjectsWithTag("SpeedEnemy");
            em_Hide = GameObject.FindGameObjectsWithTag("HideEnemy");

            totalCost = em_Normal.Length * spawnCost[0] +
                em_Speed.Length * spawnCost[2] +
                em_Hide.Length * spawnCost[4];

            timer = 0;
            CostCount();
        }


        //EmOtamesi.Instance.SetData(sendNum[random]);
    }

    private void CostCount()
    {
        random = Random.Range(1, 101);

        for (int i = 0; i < probability.GetLength(0); i++)
        {
            if (i == 0)
            {
                if (totalCost + spawnCost[i] < maxCost && probability[i] >= random)
                {
                    saveNum = i;
                    totalCost += spawnCost[i];
                    SpawnEnemy();
                }
                else if (totalCost + spawnCost[i] >= maxCost && firstSpawnFlag == true)
                {
                    firstSpawnFlag = false;
                    setTime = 1.5f;
                }
            }
            else if (i >= 1)
            {
                if (totalCost + spawnCost[i] < maxCost && probability[i] >= random && random > probability[i])
                {
                    saveNum = i;
                    totalCost += spawnCost[i];
                    SpawnEnemy();
                }
                else if(totalCost+spawnCost[i]>=maxCost&&firstSpawnFlag==true)
                {
                    firstSpawnFlag = false;
                    setTime = 1.5f;
                }
            }
        }
    }

    private void SpawnEnemy()
    {
        switch (stageName)
        {
            case StageCandidate.Stage1:
                random = Random.Range(0, sendNum_Stage1.GetLength(0));
                Debug.Log("Stage1");
                break;

            case StageCandidate.Stage2:
                random = Random.Range(0, sendNum_Stage2.GetLength(0));
                Debug.Log("Stage2");
                break;

            case StageCandidate.Stage3:
                random = Random.Range(0, sendNum_Stage3.GetLength(0));
                Debug.Log("Stage3");
                break;
        }
    }
}
