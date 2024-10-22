using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutantController : MonoBehaviour
{
    [SerializeField] GameObject[] spawnPos;         //Mutant�̃X�|�[���ꏊ�A�������擾���邽�߂Ɏg��

    private int posAmount;                          //spawnPos�̑��ʂ�ۑ�����
    private int rand;                               //0�`posAmount���̃����_���l���o�͂��邽�߂ڕϐ�


    private int camNum;             //CameraManager��cameraNum���p��
    private int compareNum;         //���camNum�Ƃ̔�r�A�J�����ύX�����������Ƃ����m���邽�߂Ɏg��


    private Vector3 pos;            //spawnPos��position��ۑ����鎞�Ɏg��
    private Quaternion qrt;         //spawnPos��rotation��ۑ����鎞�Ɏg��


    private bool camChangeFlag;     //�J�����̕ύX���s��ꂽ��true
    // Start is called before the first frame update
    void Start()
    {
        posAmount = spawnPos.Length;
        rand = Random.Range(0, posAmount);

        camNum = GetComponent<CameraManager>().cameraNum;
        compareNum = camNum;

        
        camChangeFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        camNum = GetComponent<CameraManager>().cameraNum;
        Test();

        //�J�����̕ύX����������
        if(camNum!=compareNum)
        {
            camChangeFlag = true;
        }

    }

    void Test()
    {
        if(camChangeFlag==true)
        {
            pos = spawnPos[rand].transform.position;        //�l����
            qrt = spawnPos[rand].transform.rotation;        //�l����

            transform.position = pos;
            transform.rotation = qrt;

            rand = Random.Range(0, posAmount);

            camChangeFlag = false;
        }
    }

}
