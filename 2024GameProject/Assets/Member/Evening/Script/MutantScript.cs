using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutantScript : MonoBehaviour
{
    [SerializeField] GameObject[] position;         //スポーンさせる位置

    private bool camChangeFlag;

    private int posAmount;                          //スポーンさせる位置の量
    private int rand;                               //ランダム値

    private Transform pos;
    private Quaternion qtr;


    //private string inputStr;                        //入力された文字数字

    // Start is called before the first frame update
    void Start()
    {
        camChangeFlag = false;

        posAmount = position.Length;

        rand = Random.Range(0, posAmount);
    }

    void Update()
    {
        Test();
        if(Input.GetKeyDown(KeyCode.A))
        {
            camChangeFlag = true;
        }
    }


    void Test()
    {
        if(camChangeFlag==true)
        {
            for (int i = 0; i < posAmount; i++)
            {
                Debug.Log("a");
            }
            camChangeFlag = false;
        }
    }

}
