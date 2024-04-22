using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject Camera1;
    public GameObject Camera2;
    public GameObject Camera3;
    public GameObject Camera4;

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
    }

    void Update()
    {
        // もしSpaceキーが押されたならば、
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            // 各カメラオブジェクトの有効フラグを逆転(true→false,false→true)させる
            Camera1.SetActive(true);
            Camera2.SetActive(false);
            Camera3.SetActive(false);
            Camera4.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Camera2.SetActive(true);
            Camera1.SetActive(false);
            Camera3.SetActive(false);
            Camera4.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Camera3.SetActive(true);
            Camera1.SetActive(false);
            Camera2.SetActive(false);
            Camera4.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Camera4.SetActive(true);
            Camera1.SetActive(false);
            Camera2.SetActive(false);
            Camera3.SetActive(false);
        }
    }
}