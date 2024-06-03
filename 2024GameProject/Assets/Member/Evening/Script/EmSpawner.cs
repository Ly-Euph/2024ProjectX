using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmSpawner : MonoBehaviour
{
    //スポーンさせる敵のプレハブを保存するとこ
    [SerializeField] GameObject[] Enemy;

    //各キャラごとにtagが付けられており、現状況でそのキャラが何体存在しているかの確認に使う
    private GameObject[] em_Normal;
    private GameObject[] em_Jammer;
    private GameObject[] em_Speed;
    private GameObject[] em_Hide;


    //最初のスポーン、コストMaxまでtrue、コスト最大まで湧かせたらfalseになる
    private bool firstSpawnFlag;

    //trueの時、敵スポーン
    //private bool spawnFlag;


    //各キャラのスポーンコスト
    //1:normal
    //2:speed
    //3:hide
    //4:jammer
    private int[] spawnCost = { 1, 1, 2, 2, 2, 2, 3, 3 };

    //難易度ごとの各キャラ最大スポーン数
    //1:normal
    //2:speed
    //3:hide
    //4:jammer
    private int[,] emMaxNum = new int[,] { { 10, 5, 5, 2 }, { 8, 6, 6, 4 }, { 4, 5, 5, 7 } };

    //今現在のコストを保存する
    private int totalCost;

    //敵がスポーンする。各難易度の最大コスト
    private int[] maxCost = { 20, 30, 40 };

    //難易度毎の敵スポーン確率
    //要素1:normal√1  2:normal√2  3:speed√1  4:speed√2  5:hide√1  6:hide√2  7:jammer√1  8:jammer√2
    private int[,] probability = new int[,] {
        { 25, 50, 65, 80, 87, 95, 98, 100 }, // easy
        { 15, 30, 45, 60, 73, 85, 93, 100 }, // normal
        { 10, 20, 30, 40, 55, 70, 85, 100 }, // hard 
    };

    //ランダムな数の生成で使用
    int random;

    //仮で使ってるだけ
    float timer;


    //今現在の難易度を保存
    //下のdifficultyと照らし合わせて使用
    private string difficulty;
    private string[] difficult = { "Easy", "Normal", "Hard" };

    // Start is called before the first frame update
    void Start()
    {
        firstSpawnFlag = true;
        //spawnFlag = false;


        totalCost = 0;
        timer = 0;

        difficulty = "Normal";
    }

    // Update is called once per frame
    void Update()
    {
        timer+= Time.deltaTime;


        if(firstSpawnFlag==true&&timer>=1f)
        {
            CountCost();
            timer = 0;
        }

        //if (timer >= 5f)
        //{
        //    random = Random.Range(0, 4);
        //    timer = 0;
        //    spawnFlag = true;
        //    //Instantiate(Enemy[random], new Vector3(0, 0, 0), Quaternion.identity);
        //}

        //if(spawnFlag==true)
        //{
        //    SearchEnemy();
        //    spawnFlag = false;
            
        //}
    }


    void CountCost()
    {
        //敵が今何体存在してるかを取得するために実行
        //em_Normal = GameObject.FindGameObjectsWithTag("NormalEnemy");
        //em_Jammer = GameObject.FindGameObjectsWithTag("JammerEnemy");
        //em_Speed = GameObject.FindGameObjectsWithTag("SpeedEnemy");
        //em_Hide = GameObject.FindGameObjectsWithTag("HideEnemy");

        random = Random.Range(1, 101);
        Debug.Log("random = " + random);
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
                            Instantiate(Enemy[j], new Vector3(0, 0, 0), Quaternion.identity);
                            totalCost += spawnCost[j];
                            Debug.Log("totalcost = " + totalCost);
                        }
                    }
                    else if (j >= 1)
                    {
                        if (totalCost + spawnCost[j] < maxCost[i] && probability[i, j] >= random && random > probability[i, j - 1])
                        {
                            Instantiate(Enemy[j], new Vector3(0, 0, 0), Quaternion.identity);
                            totalCost += spawnCost[j];
                            Debug.Log("totalcost = " + totalCost);
                        }
                    }
                }
            }
        }

    }


    void SearchEnemy()
    {

        random = Random.Range(1, 101);

        //敵が今何体存在してるかを取得するために実行
        em_Normal = GameObject.FindGameObjectsWithTag("NormalEnemy");
        em_Jammer = GameObject.FindGameObjectsWithTag("JammerEnemy");
        em_Speed = GameObject.FindGameObjectsWithTag("SpeedEnemy");
        em_Hide = GameObject.FindGameObjectsWithTag("HideEnemy");

        totalCost = spawnCost[0] * em_Normal.Length + spawnCost[1] * em_Jammer.Length + 
            spawnCost[2] * em_Speed.Length + spawnCost[3] * em_Hide.Length;





        ChooseEnemy();
        //Debug.Log(emNum);
    }

    void ChooseEnemy()
    {

        //難易度確認
        //iが1でif文が通った時、難易度はeasy
        for(int i=0;i<difficult.GetLength(0);i++)
        {
            if(difficulty==difficult[i])
            {
                //設定された難易度毎の出現確率
                //probabilityの要素数だけ実行
                for (int j = 0; j < probability.GetLength(1); j++)
                {
                    //randomの数値からスポーンさせる敵を選択
                    //条件：randomで出た値の敵がコストオーバーしていない
                    if (maxCost[i] + spawnCost[j] > totalCost && random > probability[i, j])
                    {
                        Instantiate(Enemy[j], new Vector3(0, 0, 0), Quaternion.identity);
                        totalCost += spawnCost[j];
                    }
                }

            }
            else
            {
                //Debug.Log("tigau");
            }
        }








        //if (random >= difficult[0, 0] && difficult[0, 1] > random)
        //{
        //    //normal_1
        //    Debug.Log("Normal1");
        //}
        //else if (random >= difficult[0, 1] && difficult[0, 2] > random)
        //{
        //    //normal_2
        //    Debug.Log("Normal2");
        //}
        //else if (random >= difficult[0, 2] && difficult[0, 3] > random)
        //{
        //    //jammer
        //    Debug.Log("Jammer");
        //}
        //else if (random >= difficult[0, 3] && difficult[0, 4] > random)
        //{
        //    //speed
        //    Debug.Log("Speed");
        //}
        //else if (random >= difficult[0, 4])
        //{
        //    //hide
        //    Debug.Log("Hide");
        //}
    }
}
