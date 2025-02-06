using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutantController : MonoBehaviour
{
    private CameraManager cameraManager;            //CameraManagerスクリプトの取得

    [SerializeField] GameObject[] spawnPos;         //Mutantのスポーン場所、向きを取得するために使う

    public GameObject Mutant;

    [SerializeField] GameManager gMng;

    private int camNum;             //CameraManagerのcameraNumを継承
    private int compareNum;         //上のcamNumとの比較、カメラ変更があったことを検知するために使う

    private int rand;
    private int changeRand;

    float timer = 0;

    private Vector3 pos;            //spawnPosのpositionを保存する時に使う
    private Quaternion qrt;         //spawnPosのrotationを保存する時に使う

    private bool camChangeFlag;     //カメラの変更が行われた時true
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
        compareNum = camNum;

        if (rand==changeRand)
        {
            pos = spawnPos[camNum - 1].transform.position;        //値を代入
            qrt = spawnPos[camNum - 1].transform.rotation;        //値を代入
            Instantiate(Mutant, pos, qrt);
            //audioSourse.PlayOneShot(spawnSound);

            //gMng.OneShotSE_U(SEData.Type.ETC, GameManager.UISe.Eff5);


            //  同じタイミングで二度目は出さない
            changeRand = 0;
        }
        
        camChangeFlag = false;
    }

}
