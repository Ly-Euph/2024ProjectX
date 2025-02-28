using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmSpawner_3 : MonoBehaviour
{
    private int random;
    private void Start()
    {
        int[][] sendNum = new int[][]
        {
            new int[] {0,2,7},
            new int[] {0,5,6,7},
            new int[] {1,6,7},
            new int[] {1,5,6,7},
            new int[] {1,5,2,7},
            new int[] {3,4,7}
        };

        random = Random.Range(0, sendNum.GetLength(0));


        EmOtamesi.Instance.SetData(sendNum[random]);
    }
}
