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


    //1:normalã1
    //2:normalã2
    //3:speed
    //4:hide
    //5:jammer
    private int[] spawnCost = { 1, 1, 2, 2, 3 };
    private int emNum;

    private int totalCost;

    private int[,] difficult = new int[3, 5] { { 30, 60, 80, 95, 100 }, { 25, 25, 20, 20, 10 }, { 10, 10, 10, 30, 40 } };
    private int[] est;

    private int[] easy;

    int random;

    float timer;

    // Start is called before the first frame update
    void Start()
    {
        spawnFlag = false;

        emNum = 0;

        totalCost = 0;
        timer = 0;
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
            ChooseEnemy();
        }
    }


    void SearchEnemy()
    {
        em_Normal = GameObject.FindGameObjectsWithTag("NormalEnemy");
        em_Jammer = GameObject.FindGameObjectsWithTag("JammerEnemy");
        em_Speed = GameObject.FindGameObjectsWithTag("SpeedEnemy");
        em_Hide = GameObject.FindGameObjectsWithTag("HideEnemy");

        emNum = spawnCost[0] * em_Normal.Length + spawnCost[1] * em_Jammer.Length + 
            spawnCost[2] * em_Speed.Length + spawnCost[3] * em_Hide.Length;

        //Debug.Log(emNum);
    }

    void ChooseEnemy()
    {
        random = Random.Range(1, 101);

        for(int i=0;i<difficult.Length;i++)
        {
            Debug.Log("dif");
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
