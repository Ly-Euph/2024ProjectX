using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraManager : MonoBehaviour
{
    public GlitchFx[] gf;

    [Header("Camera関連をここに入れといて")]

    [SerializeField] GameObject[] Camera;

    [Header("Text関連をここに入れといて")]

    [SerializeField] Text Camera_Text;

    [Header("BatteryManagerを入れてね。")]

    [SerializeField] BatteryManager Bm;

    [Header("Enemy関連")]

    [SerializeField] GameObject[] Enemy;

    [Header("Trapを発動する位置用のObject")]

    [SerializeField] GameObject[] Trap_Obj;

    [Header("様々なTrapを入れてね")]

    [SerializeField] GameObject[] Trap_GK;

    [Header("それぞれのCamZoomUIを入れるとこ")]

    [SerializeField] GameObject[] Cam_Zoom;

    [Header("それぞれのGimmicUIを入れるとこ")]

    [SerializeField] GameObject[] Gimmick;

    [Header("SonarFxのScriptを入れてね")]

    // ソナースクリプト取得
    [SerializeField] SonarFx[] Sf;

    [Header("それぞれのVoltトラップで使うImageを入れてね")]

    // ボルトトラップイメージ
    [SerializeField] Image[] Volt_Img;

    [Header("VoltのCooltime用のTextを入れてね。")]

    [SerializeField] Text[] CT_Volt;

    [SerializeField] Text[] Sencor_text;

    [Header("EchoManagerを入れてね")]

    ScanManager sMng;

    [Header("ステージ事に合わせたカメラの数を入力してください")]

    [SerializeField] int Camera_Num;

    private int V_time = 20;

    private int Sencor_Count = 0;

    public int Sensor_Bt;

    public float[] time_Gf;

    //Voltのtimerの変数
    private float[] time_Vs;

    //Voltのtimerの変数
    public float[] Volt_timers;

    //Volt用のFlag
    public bool[] Volt_Flg;

    //Camera用のFlag
    public bool[] Cam_Flg;

    public bool[] Gf_Flg;

    public bool[] IsSencor;

    void Start()
    {
        sMng = GameObject.Find("ScanManager").GetComponent<ScanManager>();
        for (int i = 0; i < Camera.Length; i++)
        {
            // ボルトトラップ使用可能のテキスト「OK」を初めに表示

            CT_Volt[i].text = "OK";
            Sencor_text[i].text = "OFF";

            //　Imageを初めは0にしておく。

            Volt_Img[i].GetComponent<Image>().fillAmount = 0;
        }
        //初めはCamera1に設定
        SetCamera1();
        //カメラに関するFlagを全てOffに
        CamFlag();
        Cam_Flg[0] = true;
        //GimmicとCameraZoomのUIを引数の値に応じて表示
        UIActive(0);
        //Sonartxをfalseに
        SonarOff();

        //time_Vsに配列の値を代入。
        time_Vs = new float[Volt_timers.Length];
    }

    void Update()
    {
        Debug.Log(Sencor_Count);
        //時を止めてる間はreturnし続ける。
        if (Time.timeScale == 0) return;

        //Shiftキーを押したときにバッテリーを５%減らす。
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Bm.Para_Battery -= 5f;
        }


        if (Input.GetKey(KeyCode.LeftShift))
        {
            SonarOn();
            //Shiftキーを押し続けたときにバッテリーを継続的に減らす。
            if (Bm.Para_Battery >= 0) { Bm.Para_Battery -= 0.05f; }
        }

        //Shiftキーを離したときにスキャンを止める。

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            SonarOff();
        }

        //Voltトラップ呼出し
        for (int i = 0; i < Cam_Flg.Length; i++)
        {
            if (Input.GetKeyDown(KeyCode.E) && Cam_Flg[i] && Volt_timers[i] >= 20)
            {
                Debug.Log("Volt生成");
                Vector3 ObjPos = Trap_Obj[i].transform.position;
                Instantiate(Trap_GK[i], ObjPos, Quaternion.identity);
                time_Vs[i] = 0;
                Battery_nega();
                // クールタイム計測
                time_Vs[i] += Time.deltaTime;
                if (time_Vs[i] >= Volt_timers[i])
                {
                    time_Vs[i] = Volt_timers[i]; // クールタイムがリセットされないようにする
                }
            }
        }

        //カメラ関連の切り替え。

        for (int i = 0; i <= Camera_Num; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i - 1))
            {
                SetCamera(i);
                CamFlag();
                Cam_Flg[i - 1] = true;
                UIActive(i - 1);
                gf[i - 1].intensity += 1.0f;
                Gf_Flg[i - 1] = true;
            }
        }

        for (int i = 0; i < Gf_Flg.Length; i++)
        {
            if (Gf_Flg[i])
            {
                time_Gf[i] += Time.deltaTime;
                if (time_Gf[i] >= 1)
                {
                    gf[i].intensity = 0.01f;
                    time_Gf[i] = 0;
                    Gf_Flg[i] = false;
                }
            }
        }

        //VoltトラップとUIを切り替える

        for (int i = 0; i < Camera_Num; i++)
        {
            if (Cam_Flg[i] && Input.GetKeyDown(KeyCode.E) && Volt_Img[i].fillAmount == 0)
            {
                StartVoltTimer(i);
            }
            if (Volt_Flg[i])
            {
                UpdateVoltTimer(i);
            }
            if (Bm.Para_Battery <= Sensor_Bt)
            {
                for (int j = 0; j < Sencor_Count; j++)
                {
                    Sencor_text[i].text = "OFF";
                }
                IsSencor[i] = false;  
                //return;
            }
            if (Cam_Flg[i] && Input.GetKeyDown(KeyCode.C))
            {
                Debug.Log(i);
                IsSencor[i] = IsSencor[i] == false ? true : false;
                Sencor_text[i].text = "ON";
                Sencor_Count++;
                if(!IsSencor[i])
                {
                    Sencor_text[i].text = "OFF";
                }

            }
          
        }
        for (int i = 0; i < IsSencor.Length; i++)
        {
            if (IsSencor[i]) Bm.Para_Battery -= 0.05f;
        }
       
    }

    //GimmickとCamZoomの制御
    private void UIActive(int num)
    {
        for (int i = 0; i < Gimmick.Length; i++)
        {
            // 一旦全てのUI表示を非表示
            Gimmick[i].SetActive(false);
            Cam_Zoom[i].SetActive(false);
        }
        Gimmick[num].SetActive(true);
        Cam_Zoom[num].SetActive(true);
    }

    //以下カメラ機能のState
    void SetCamera(int num)
    {
        switch (num)
        {
            case 1:
                SetCamera1();

                break;
            case 2:
                SetCamera2();
                break;
            case 3:
                SetCamera3();
                break;
            case 4:
                SetCamera4();
                break;
            case 5:
                SetCamera5();
                break;
            case 6:
                SetCamera6();
                break;
        }
    }


    void SetCamera1()
    {
        CameraScan();
        Camera[0].SetActive(true);
        Camera_Text.text = "カメラ１:";
    }

    void SetCamera2()
    {
        CameraScan();
        Camera[1].SetActive(true);

        Camera_Text.text = "カメラ２:";
    }

    void SetCamera3()
    {
        CameraScan();
        Camera[2].SetActive(true);
        Camera_Text.text = "カメラ３:";
    }

    void SetCamera4()
    {
        CameraScan();
        Camera[3].SetActive(true);
        Camera_Text.text = "カメラ４:";
    }

    void SetCamera5()
    {
        CameraScan();
        Camera[4].SetActive(true);
        Camera_Text.text = "カメラ５:";
    }
    void SetCamera6()
    {
        CameraScan();
        Camera[5].SetActive(true);
        Camera_Text.text = "カメラ６:";
    }
    void SonarOff()
    {
        for (int i = 0; i < Sf.Length; i++)
        {
            Sf[i].enabled = false;
        }
    }
    void SonarOn()
    {
        for (int i = 0; i < Sf.Length; i++)
        {
            Sf[i].enabled = true;
        }
    }
    void CameraScan()
    {
        for (int i = 0; i < Camera.Length; i++)
        {
            Camera[i].SetActive(false);
        }
    }

    void CamFlag()
    {
        for (int i = 0; i < Cam_Flg.Length; i++)
        {
            Cam_Flg[i] = false;
        }
    }

    void StartVoltTimer(int index)
    {
        CT_Volt[index].text = V_time.ToString();
        Volt_Img[index].fillAmount = 1;
        Volt_Flg[index] = true;
    }
    void UpdateVoltTimer(int index)
    {
        Volt_timers[index] -= Time.deltaTime;
        CT_Volt[index].text = ((int)Volt_timers[index]).ToString();
        Volt_Img[index].fillAmount -= 1 / 20.0f * Time.deltaTime;

        if (Volt_timers[index] <= 0)
        {
            Volt_Flg[index] = false;
            CT_Volt[index].text = "OK";
            Volt_timers[index] = 20;
        }
    }

    void Battery_nega()
    {
        if (Bm.Para_Battery >= 0)
        {
            Bm.Para_Battery -= 10;
        }
    }
}