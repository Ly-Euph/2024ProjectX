using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutantController : MonoBehaviour
{
    private CameraManager cameraManager;            //CameraManager�X�N���v�g�̎擾

    [SerializeField] GameObject[] spawnPos;         //Mutant�̃X�|�[���ꏊ�A�������擾���邽�߂Ɏg��

    public GameObject Mutant;

    [SerializeField] GameManager gMng;

    private int camNum;             //CameraManager��cameraNum���p��
    private int compareNum;         //���camNum�Ƃ̔�r�A�J�����ύX�����������Ƃ����m���邽�߂Ɏg��

    private int rand;
    private int changeRand;

    float timer = 0;

    private Vector3 pos;            //spawnPos��position��ۑ����鎞�Ɏg��
    private Quaternion qrt;         //spawnPos��rotation��ۑ����鎞�Ɏg��

    private bool camChangeFlag;     //�J�����̕ύX���s��ꂽ��true
    // Start is called before the first frame update
    void Start()
    {
        cameraManager = GameObject.Find("CameraManager").GetComponent<CameraManager>();    

        camNum = cameraManager.CameraNum;
        compareNum = camNum;

        rand = 1;
        
        camChangeFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        camNum = cameraManager.CameraNum;

        timer += Time.deltaTime;

        if(timer>=3.0f)
        {
            timer = 0;
            changeRand = Random.Range(0, 10);
        }

        //�J�����̕ύX����������
        if (camNum != compareNum)
        {
            camChangeFlag = true;
        }



        if(camChangeFlag==true)
        {
            Test();
        }



    }

    void Test()
    {
        compareNum = camNum;

        if (rand==changeRand)
        {
            pos = spawnPos[camNum - 1].transform.position;        //�l����
            qrt = spawnPos[camNum - 1].transform.rotation;        //�l����
            Instantiate(Mutant, pos, qrt);
            //audioSourse.PlayOneShot(spawnSound);

            //gMng.OneShotSE_U(SEData.Type.ETC, GameManager.UISe.Eff5);


            //  �����^�C�~���O�œ�x�ڂ͏o���Ȃ�
            changeRand = 0;
        }
        
        camChangeFlag = false;
    }

}
