using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] Enemy;

    private GameObject[] em_Normal;
    private GameObject[] em_Jammer;
    private GameObject[] em_Speed;
    private GameObject[] em_Hide;

    private bool spawnFlag;


    //1:normal√1
    //2:normal√2
    //3:speed
    //4:hide
    //5:jammer
    private int[] spawnCost = { 1, 1, 2, 2, 3 };
    private int emNum;

    private int totalCost;
    private int[] maxCost = { 20, 30, 40 };

    private int[,] probability = new int[,] { { 30, 60, 80, 95, 100 }, { 25, 25, 20, 20, 10 }, { 10, 10, 10, 30, 40 } };

    private int[] easy;

    int random;

    float timer;


    private string difficulty;
    private string[] difficult = { "Easy", "Normal", "Hard" };

    // Start is called before the first frame update
    void Start()
    {
        spawnFlag = false;

        emNum = 0;

        totalCost = 0;
        timer = 0;

        difficulty = "Easy";
    }

    // Update is called once per frame
    void Update()
    {
        timer+= Time.deltaTime;


        if (timer >= 5f)
        {
            random = Random.Range(0, 4);
            timer = 0;
            spawnFlag = true;
            Instantiate(Enemy[random], new Vector3(0, 0, 0), Quaternion.identity);
        }

        if(spawnFlag==true)
        {
            SearchEnemy();
            spawnFlag = false;
            
        }
    }


    void SearchEnemy()
    {

        random = Random.Range(1, 101);

        em_Normal = GameObject.FindGameObjectsWithTag("NormalEnemy");
        em_Jammer = GameObject.FindGameObjectsWithTag("JammerEnemy");
        em_Speed = GameObject.FindGameObjectsWithTag("SpeedEnemy");
        em_Hide = GameObject.FindGameObjectsWithTag("HideEnemy");

        emNum = spawnCost[0] * em_Normal.Length + spawnCost[1] * em_Jammer.Length + 
            spawnCost[2] * em_Speed.Length + spawnCost[3] * em_Hide.Length;





        ChooseEnemy();
        //Debug.Log(emNum);
    }

    void ChooseEnemy()
    {

        for(int i=0;i<difficult.GetLength(0);i++)
        {
            if(difficulty==difficult[i])
            {
                //設定された難易度の確率
                for (int j = 0; j < probability.GetLength(1); j++)
                {
                    //randomの数値からスポーンさせる敵を選択
                    //条件：コストオーバーしていない
                    //randomで出た値の
                    if (maxCost[i] + spawnCost[j] > totalCost && random > probability[i, j])
                    {

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
