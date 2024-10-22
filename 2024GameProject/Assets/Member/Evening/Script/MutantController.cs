using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutantController : MonoBehaviour
{
    private CameraManager cameraManager;            //CameraManagerスクリプトの取得

    [SerializeField] GameObject[] spawnPos;         //Mutantのスポーン場所、向きを取得するために使う

    private int posAmount;                          //spawnPosの総量を保存する


    private int camNum;             //CameraManagerのcameraNumを継承
    private int compareNum;         //上のcamNumとの比較、カメラ変更があったことを検知するために使う


    private Vector3 pos;            //spawnPosのpositionを保存する時に使う
    private Quaternion qrt;         //spawnPosのrotationを保存する時に使う


    private bool camChangeFlag;     //カメラの変更が行われた時true
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

        //カメラの変更があった時
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
            pos = spawnPos[camNum-1].transform.position;        //値を代入
            qrt = spawnPos[camNum-1].transform.rotation;        //値を代入

            transform.position = pos;
            transform.rotation = qrt;

            compareNum = camNum;

            camChangeFlag = false;
        }
    }

}
