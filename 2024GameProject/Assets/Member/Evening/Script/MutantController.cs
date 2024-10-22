using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutantController : MonoBehaviour
{
    private CameraManager cameraManager;            //CameraManager�X�N���v�g�̎擾

    [SerializeField] GameObject[] spawnPos;         //Mutant�̃X�|�[���ꏊ�A�������擾���邽�߂Ɏg��

    private int posAmount;                          //spawnPos�̑��ʂ�ۑ�����


    private int camNum;             //CameraManager��cameraNum���p��
    private int compareNum;         //���camNum�Ƃ̔�r�A�J�����ύX�����������Ƃ����m���邽�߂Ɏg��


    private Vector3 pos;            //spawnPos��position��ۑ����鎞�Ɏg��
    private Quaternion qrt;         //spawnPos��rotation��ۑ����鎞�Ɏg��


    private bool camChangeFlag;     //�J�����̕ύX���s��ꂽ��true
    // Start is called before the first frame update
    void Start()
    {
        cameraManager = GameObject.Find("CameraManager").GetComponent<CameraManager>();

        posAmount = spawnPos.Length;

        camNum = cameraManager.cameraNum;
        compareNum = camNum;

        
        camChangeFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        camNum = cameraManager.cameraNum;
        Test();

        //�J�����̕ύX����������
        if (camNum != compareNum)
        {
            camChangeFlag = true;
            Debug.Log("tigauyo");
        }

    }

    void Test()
    {
        if (camChangeFlag == true)
        {
            pos = spawnPos[camNum-1].transform.position;        //�l����
            qrt = spawnPos[camNum-1].transform.rotation;        //�l����

            transform.position = pos;
            transform.rotation = qrt;

            compareNum = camNum;

            camChangeFlag = false;
        }
    }

}
