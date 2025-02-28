using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmSpawner_3 : MonoBehaviour
{
    public int[][] sendNum = new int[][]
        {
            new int[] {0,2,7},
            new int[] {0,5,6,7},
            new int[] {1,6,7},
            new int[] {1,5,6,7},
            new int[] {1,5,2,7},
            new int[] {3,4,7}
        };

    private int random;

    private float timer;
    private float setTime;
    public float spawnLate;
    private void Start()
    {
        random = Random.Range(0, sendNum.GetLength(0));

        setTime = 1.0f;
        spawnLate = 10.0f;
    }

    private void Update()
    {
        timer += Time.deltaTime;




        //EmOtamesi.Instance.SetData(sendNum[random]);
    }
}
