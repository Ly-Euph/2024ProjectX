using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraManager : MonoBehaviour
{
    [Header("Camera関連をここに入れといて")]

    [SerializeField] GameObject[] Camera = new GameObject[3];

    [Header("Text関連をここに入れといて")]

    [SerializeField] Text CameraText;

    [Header("BatteryManagerを入れてね。")]

    [SerializeField] BatteryManager Bm;

    [Header("Enemy関連")]

    [SerializeField] GameObject[] enemy = new GameObject[3]; 

    SonarFx[] sf = new SonarFx[4];
    void Start()
    {
        //カメラ1以外のカメラは最初にfalseに

        Camera[1].SetActive(false);
        Camera[2].SetActive(false);
        Camera[3].SetActive(false);
        Camera[4].SetActive(false);
        Camera[5].SetActive(false);

        //sfの配列にSonarFxをげっとする。

        sf[0] = Camera[0].GetComponent<SonarFx>();
        sf[1] = Camera[1].GetComponent<SonarFx>();
        sf[2] = Camera[2].GetComponent<SonarFx>();
        sf[3] = Camera[4].GetComponent<SonarFx>();
        sf[4] = Camera[5].GetComponent<SonarFx>();
        sf[5] = Camera[6].GetComponent<SonarFx>();

        //Sonartxをfalseに

        SonarOff();
    }

    void Update()
    { 
        //Shiftキーを押したときにバッテリーを５%減らす。

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            Bm.Para_Battery -= 5f;
        }

        //Shiftキーを押し続けたときにバッテリーを継続的に減らす。

        if(Input.GetKey(KeyCode.LeftShift))
        {
            SonarOn();
            Bm.Para_Battery -= 0.05f;
        }

        //Shiftキーを離したときにスキャンを止める。

        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            SonarOff();
        }
        //番号１

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //Camera1の設定
            SetCamera1();
        }
        //番号２

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            //Camera2の設定
            SetCamera2();
        }

        //番号３

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            //Camera3の設定
            SetCamera3();
        }
        //番号４

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            //Camera4の設定
            SetCamera4();
        }
        //番号５

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            //Camera4の設定
            SetCamera5();
        }
        //番号６

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            //Camera4の設定
            SetCamera6();
        }

    }


    //以下カメラ機能の制御

    void SetCamera1()
    {
        CameraScan();
        Camera[0].SetActive(true);
        CameraText.text = "カメラ１:";
    }

    void SetCamera2()
    {
        CameraScan();
        Camera[1].SetActive(true);

        CameraText.text = "カメラ２:";
    }

    void SetCamera3()
    {
        CameraScan();
        Camera[2].SetActive(true);
        CameraText.text = "カメラ３:";
    }

    void SetCamera4()
    {
        CameraScan();
        Camera[3].SetActive(true);
        CameraText.text = "カメラ４:";
    }

    void SetCamera5()
    {
        CameraScan();
        Camera[4].SetActive(true);
        CameraText.text = "カメラ５:";
    }
    void SetCamera6()
    {
        CameraScan();
        Camera[5].SetActive(true);
        CameraText.text = "カメラ６:";
    }
    void SonarOff()
    {
        for(int i = 0; i < sf.Length; i++)
        {
            sf[i].enabled = false;
        }
    }
    void SonarOn()
    {
        for(int i = 0; i < sf.Length; i++)
        {
            sf[i].enabled = true;
        }
    }
    void CameraScan()
    {
        for (int i = 0; i < Camera.Length; i++)
        {
            Camera[i].SetActive(false);
        }
    }
}