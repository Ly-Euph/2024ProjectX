using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutantScript : MonoBehaviour
{
    [SerializeField] GameObject[] position;         //�X�|�[��������ʒu

    private bool camChangeFlag;

    private int posAmount;                          //�X�|�[��������ʒu�̗�
    private int rand;                               //�����_���l

    private string inputStr;                        //���͂��ꂽ��������

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
        if(camChangeFlag==true)             //�J�����̐؂�ւ����s��ꂽ��
        {
            for (int i = 0; i < posAmount; i++)
            {
                Debug.Log("a");
            }
        }


        rand = Random.Range(0, 100);
    }

}
