using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] Enemy;

    //1:normalÅ„1
    //2:normalÅ„2
    //3:speed
    //4:hide
    //5:jammer
    private int[] spawnCost = { 1, 1, 2, 2, 3 };

    private int totalCost;

    // Start is called before the first frame update
    void Start()
    {
        totalCost = 0;
    }

    // Update is called once per frame
    void Update()
    {
        SearchEnemy();
    }

    void SearchEnemy()
    {
        for (int i = 0; 3 < i; i++)
        {
            Debug.Log("âÒêî");
            totalCost += spawnCost[i];
        }
        
    }

}
