using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmSpawner : MonoBehaviour
{
    //スポーンさせる敵のプレハブを保存するとこ
    [SerializeField] GameObject[] Enemy;

    public string str = "Easy";


    //各キャラごとにtagが付けられており、現状況でそのキャラが何体存在しているかの確認に使う
    private GameObject[] em_Normal;
    private GameObject[] em_Jammer;
    private GameObject[] em_Speed;
    private GameObject[] em_Hide;


    //最初のスポーン、コストMaxまでtrue、コスト最大まで湧かせたらfalseになる
    //false時は15秒に1度敵のコスト検知+スポーン
    public bool firstSpawnFlag;


    //各キャラのスポーンコスト
    //1:normal
    //2:speed
    //3:hide
    //4:jammer
    private int[] spawnCost = { 1, 1, 2, 2, 2, 2, 3 };

    //難易度ごとの各キャラ最大スポーン数
    //1:normal
    //2:speed
    //3:hide
    //4:jammer
    //private int[,] emMaxNum = new int[,] { { 10, 5, 5, 2 }, { 8, 6, 6, 4 }, { 4, 5, 5, 7 } };

    //今現在のコストを保存する

    private int totalCost;

    //敵がスポーンする。各難易度の最大コスト
    private int[] maxCost = { 20, 30, 40 };

    //難易度毎の敵スポーン確率
    //要素1:normal√1  2:normal√2  3:speed√1  4:speed√2  5:hide√1  6:hide√2  7:jammer√1  8:jammer√2
    private int[,] probability = new int[,] {
        { 25, 50, 65, 80, 87, 100 }, // easy
        { 15, 30, 45, 60, 73, 100 }, // normal
        { 10, 20, 30, 40, 55, 100 }, // hard 
        };

    //ランダムな数の生成で使用
    int random;

    private int saveNum;

    //仮で使ってるだけ
    float timer;
    float setTime;

    public float spwanLate = 10.0f;


    //今現在の難易度を保存
    //下のdifficultyと照らし合わせて使用
    private string difficulty;
    private string[] difficult = { "Easy", "Normal", "Hard"};

    // Start is called before the first frame update
    void Start()
    {
        firstSpawnFlag = true;


        totalCost = 0;
        timer = 0;
        setTime = 1.0f;

        difficulty = str;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;


        if (timer >= setTime * spwanLate)
        {
            if (firstSpawnFlag == true)
            {
                timer = 0;
                CountCost();
            }
            else if (firstSpawnFlag == false)
            {
                em_Normal = GameObject.FindGameObjectsWithTag("NormalEnemy");
                em_Speed = GameObject.FindGameObjectsWithTag("SpeedEnemy");
                em_Hide = GameObject.FindGameObjectsWithTag("HideEnemy");
                em_Jammer = GameObject.FindGameObjectsWithTag("JammerEnemy");


                totalCost = em_Normal.Length * spawnCost[0] +
                          em_Speed.Length * spawnCost[2] +
                          em_Hide.Length * spawnCost[4] +
                          em_Jammer.Length * spawnCost[6];



                timer = 0;
                CountCost();
            }
        }


    }


    void CountCost()
    {
        

        random = Random.Range(1, 101);
        for (int i = 0; i < difficult.GetLength(0); i++)
        {
            if (difficulty == difficult[i])
            {
                for (int j = 0; j < probability.GetLength(1); j++)
                {
                    if (j==0)
                    {
                        if(totalCost+spawnCost[j]<maxCost[i]&&probability[i,j]>=random)
                        {
                            saveNum = j;
                            //Instantiate(Enemy[j], new Vector3(0, 0, 0), Quaternion.identity);
                            totalCost += spawnCost[j];
                            SpawnEnemy();
                        }
                        else if (totalCost + spawnCost[j] >= maxCost[i] && firstSpawnFlag == true)
                        {
                            firstSpawnFlag = false;
                            setTime = 1.5f;
                        }
                    }
                    else if (j >= 1)
                    {
                        if (totalCost + spawnCost[j] < maxCost[i] && probability[i, j] >= random && random > probability[i, j - 1])
                        {
                            saveNum = j;
                            //Instantiate(Enemy[j], new Vector3(0, 0, 0), Quaternion.identity);
                            totalCost += spawnCost[j];
                            SpawnEnemy();
                        }
                        else if (totalCost + spawnCost[j] >= maxCost[i] && firstSpawnFlag == true)
                        {
                            firstSpawnFlag = false;
                            setTime = 1.5f;
                        }
                    }
                    
                }
            }
        }

    }

    void SpawnEnemy()
    {
        Instantiate(Enemy[saveNum], new Vector3(0, 0, 0), Quaternion.identity);
        //Enemy_Normal norm = obj.GetComponent<Enemy_Normal>();
        //norm.hp = 10;
    }

}
