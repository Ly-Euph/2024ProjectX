using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutantScript : MonoBehaviour
{
    [SerializeField] GameObject[] position;         //スポーンさせる位置

    private bool camChangeFlag;

    private int posAmount;                          //スポーンさせる位置の量
    private int rand;                               //ランダム値

    private string inputStr;                        //入力された文字数字

    // Start is called before the first frame update
    void Start()
    {
        camChangeFlag = false;

        posAmount = position.Length;

        
    }

    void Update()
    {
        Test();
    }


    void Test()
    {
        if(camChangeFlag==true)             //カメラの切り替えが行われた時
        {
            for (int i = 0; i < posAmount; i++)
            {
                Debug.Log("a");
            }
        }


        rand = Random.Range(0, 100);
    }

}
