using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraManager : MonoBehaviour
{
    public GameObject Camera1;
    public GameObject Camera2;
    public GameObject Camera3;
    public GameObject Camera4;

    public Text CameraNumber1;
    public Text CameraNumber2;
    public Text CameraNumber3;
    public Text CameraNumber4;

    int countTimer = 0;
    void Start()
    {
        // 各カメラオブジェクトを取得
        Camera1 = GameObject.Find("Camera1");
        Camera2 = GameObject.Find("Camera2");
        Camera3 = GameObject.Find("Camera3");
        Camera4 = GameObject.Find("Camera4");

        // サブカメラはデフォルトで無効にしておく
        Camera2.SetActive(false);
        Camera3.SetActive(false);
        Camera4.SetActive(false);

        //テキスト関連
        CameraNumber2.enabled = false;
        CameraNumber3.enabled = false;
        CameraNumber4.enabled = false;
    }

    void Update()
    { 
        //番号１
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            // 各カメラオブジェクトの有効フラグを逆転(true→false,false→true)させる
            Camera1.SetActive(true);
            Camera2.SetActive(false);
            Camera3.SetActive(false);
            Camera4.SetActive(false);

            //各テキストの有効フラグを逆転(true→false,false→true)させる
            CameraNumber1.enabled = true;
            CameraNumber2.enabled = false;
            CameraNumber3.enabled = false;
            CameraNumber4.enabled = false;
        }
        //番号２
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Camera2.SetActive(true);
            Camera1.SetActive(false);
            Camera3.SetActive(false);
            Camera4.SetActive(false);

            CameraNumber2.enabled = true;
            CameraNumber1.enabled = false;
            CameraNumber3.enabled = false;
            CameraNumber4.enabled = false;
        }
        //番号３
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Camera3.SetActive(true);
            Camera1.SetActive(false);
            Camera2.SetActive(false);
            Camera4.SetActive(false);

            CameraNumber3.enabled = true;
            CameraNumber1.enabled = false;
            CameraNumber2.enabled = false;
            CameraNumber4.enabled = false;
        }
        //番号４
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Camera4.SetActive(true);
            Camera1.SetActive(false);
            Camera2.SetActive(false);
            Camera3.SetActive(false);

            CameraNumber4.enabled = true;
            CameraNumber1.enabled = false;
            CameraNumber2.enabled = false;
            CameraNumber3.enabled = false;
        }
    }
}