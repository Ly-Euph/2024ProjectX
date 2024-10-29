using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutantController : MonoBehaviour
{
    private CameraManager cameraManager;            //CameraManagerスクリプトの取得

    [SerializeField] GameObject[] spawnPos;         //Mutantのスポーン場所、向きを取得するために使う



    private int camNum;             //CameraManagerのcameraNumを継承
    private int compareNum;         //上のcamNumとの比較、カメラ変更があったことを検知するために使う

    private int rand;
    private int changeRand;



    private Vector3 pos;            //spawnPosのpositionを保存する時に使う
    private Quaternion qrt;         //spawnPosのrotationを保存する時に使う


    private bool camChangeFlag;     //カメラの変更が行われた時true
    // Start is called before the first frame update
    void Start()
    {
        cameraManager = GameObject.Find("CameraManager").GetComponent<CameraManager>();    

        camNum = cameraManager.cameraNum;
        compareNum = camNum;

        rand = Random.Range(0, 60);

        
        camChangeFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        camNum = cameraManager.cameraNum;

        //カメラの変更があった時
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
        changeRand = Random.Range(0, 60);

        if(rand==changeRand)
        {
            pos = spawnPos[camNum - 1].transform.position;        //値を代入
            qrt = spawnPos[camNum - 1].transform.rotation;        //値を代入

            transform.position = pos;
            transform.rotation = qrt;

            compareNum = camNum;
        }
        
        camChangeFlag = false;
    }

}
