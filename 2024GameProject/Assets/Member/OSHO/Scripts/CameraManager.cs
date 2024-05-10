using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraManager : MonoBehaviour
{
    [SerializeField] GameObject[] Camera = new GameObject[3];
    [SerializeField] Text[] CameraNumber = new Text[3];

    SonarFx sf1;
    SonarFx sf2;
    SonarFx sf3;
    SonarFx sf4;

    int i = 0;

    void Start()
    {
        Camera[0] = GameObject.Find("Camera1");
        Camera[1] = GameObject.Find("Camera2");
        Camera[2] = GameObject.Find("Camera3");
        Camera[3] = GameObject.Find("Camera4");
        
        //カメラ2,3,4は最初にfalseに
        Camera[1].SetActive(false);
        Camera[2].SetActive(false);
        Camera[3].SetActive(false);

        //テキスト2,3,4は最初falseに
        CameraNumber[1].enabled = false;
        CameraNumber[2].enabled = false;
        CameraNumber[3].enabled = false;

        sf1 = Camera[0].GetComponent<SonarFx>();
        sf2 = Camera[1].GetComponent<SonarFx>();
        sf3 = Camera[2].GetComponent<SonarFx>();
        sf4 = Camera[3].GetComponent<SonarFx>();

        //Sonartx2,3,4をfalseに
        sf1.enabled = false;
        sf2.enabled = false;
        sf3.enabled = false;
        sf4.enabled = false;
    }

    void Update()
    { 
        if(Input.GetKey(KeyCode.LeftShift))
        {
            sf1.enabled = true;
            sf2.enabled = true;
            sf3.enabled = true;
            sf4.enabled = true;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            sf1.enabled = false;
            sf2.enabled = false;
            sf3.enabled = false;
            sf4.enabled = false;
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
    }

    void SetCamera1()
    {
        Camera[0].SetActive(true);
        Camera[1].SetActive(false);
        Camera[2].SetActive(false);
        Camera[3].SetActive(false);

        //Textをenabledで管理
        CameraNumber[0].enabled = true;
        CameraNumber[1].enabled = false;
        CameraNumber[2].enabled = false;
        CameraNumber[3].enabled = false;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            sf1.enabled = true;
            sf2.enabled = false;
            sf3.enabled = false;
            sf4.enabled = false;
        }
    }

    void SetCamera2()
    {
        Camera[1].SetActive(true);
        Camera[0].SetActive(false);
        Camera[2].SetActive(false);
        Camera[3].SetActive(false);

        CameraNumber[1].enabled = true;
        CameraNumber[0].enabled = false;
        CameraNumber[2].enabled = false;
        CameraNumber[3].enabled = false;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            sf2.enabled = true;
            sf3.enabled = false;
            sf4.enabled = false;
            sf1.enabled = false;
        }
    }

    void SetCamera3()
    {
        Camera[2].SetActive(true);
        Camera[0].SetActive(false);
        Camera[1].SetActive(false);
        Camera[3].SetActive(false);

        CameraNumber[2].enabled = true;
        CameraNumber[0].enabled = false;
        CameraNumber[1].enabled = false;
        CameraNumber[3].enabled = false;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            sf3.enabled = true;
            sf4.enabled = false;
            sf1.enabled = false;
            sf2.enabled = false;
        }
    }

    void SetCamera4()
    {
        Camera[3].SetActive(true);
        Camera[0].SetActive(false);
        Camera[1].SetActive(false);
        Camera[2].SetActive(false);

        CameraNumber[3].enabled = true;
        CameraNumber[0].enabled = false;
        CameraNumber[1].enabled = false;
        CameraNumber[2].enabled = false;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            sf4.enabled = true;
            sf1.enabled = false;
            sf2.enabled = false;
            sf3.enabled = false;
        }
    }
}