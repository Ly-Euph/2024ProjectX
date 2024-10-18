using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutantScript : MonoBehaviour
{
    [SerializeField] GameObject[] position;         //�X�|�[��������ʒu

    private bool camChangeFlag;

    private int posAmount;                          //�X�|�[��������ʒu�̗�
    private int rand;                               //�����_���l

    private Transform pos;
    private Quaternion qtr;


    //private string inputStr;                        //���͂��ꂽ��������

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
