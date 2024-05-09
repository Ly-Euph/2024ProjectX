using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraManager : MonoBehaviour
{
    [SerializeField] GameObject Camera1;
    [SerializeField] GameObject Camera2;
    [SerializeField] GameObject Camera3;
    [SerializeField] GameObject Camera4;

    SonarFx sf1;
    SonarFx sf2;
    SonarFx sf3;
    SonarFx sf4;

    public Text CameraNumber1;
    public Text CameraNumber2;
    public Text CameraNumber3;
    public Text CameraNumber4;

    GameObject[] sfobj;

    void Start()
    {
        Camera1 = GameObject.Find("Camera1");
        Camera2 = GameObject.Find("Camera2");
        Camera3 = GameObject.Find("Camera3");
        Camera4 = GameObject.Find("Camera4");
        
        //カメラ2,3,4は最初にfalseに
        Camera2.SetActive(false);
        Camera3.SetActive(false);
        Camera4.SetActive(false);

        //テキスト2,3,4は最初falseに
        CameraNumber2.enabled = false;
        CameraNumber3.enabled = false;
        CameraNumber4.enabled = false;

        sf1 = Camera1.GetComponent<SonarFx>();
        sf2 = Camera2.GetComponent<SonarFx>();
        sf3 = Camera3.GetComponent<SonarFx>();
        sf4 = Camera4.GetComponent<SonarFx>();

        //Sonartx2,3,4をfalseに
        sf2.enabled = false;
        sf3.enabled = false;
        sf4.enabled = false;

    }

    void Update()
    { 
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
        Camera1.SetActive(true);
        Camera2.SetActive(false);
        Camera3.SetActive(false);
        Camera4.SetActive(false);

        //Textをenabledで管理
        CameraNumber1.enabled = true;
        CameraNumber2.enabled = false;
        CameraNumber3.enabled = false;
        CameraNumber4.enabled = false;

       
        sf1.enabled = true;
        sf2.enabled = false;
        sf3.enabled = false;
        sf4.enabled = false;
    }

    void SetCamera2()
    {
        Camera2.SetActive(true);
        Camera1.SetActive(false);
        Camera3.SetActive(false);
        Camera4.SetActive(false);

        CameraNumber2.enabled = true;
        CameraNumber1.enabled = false;
        CameraNumber3.enabled = false;
        CameraNumber4.enabled = false;

       
        sf2.enabled = true;
        sf3.enabled = false;
        sf4.enabled = false;
        sf1.enabled = false;
        
    }

    void SetCamera3()
    {
        Camera3.SetActive(true);
        Camera1.SetActive(false);
        Camera2.SetActive(false);
        Camera4.SetActive(false);

        CameraNumber3.enabled = true;
        CameraNumber1.enabled = false;
        CameraNumber2.enabled = false;
        CameraNumber4.enabled = false;

        sf3.enabled = true;
        sf4.enabled = false;
        sf1.enabled = false;
        sf2.enabled = false;
    }

    void SetCamera4()
    {
        Camera4.SetActive(true);
        Camera1.SetActive(false);
        Camera2.SetActive(false);
        Camera3.SetActive(false);

        CameraNumber4.enabled = true;
        CameraNumber1.enabled = false;
        CameraNumber2.enabled = false;
        CameraNumber3.enabled = false;

        sf4.enabled = true;
        sf1.enabled = false;
        sf2.enabled = false;
        sf3.enabled = false;
    }
}