using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraManager : MonoBehaviour
{
    public GlitchFx[] GF_gf;

    [Header("Camera関連をここに入れといて")]

    [SerializeField] GameObject[] OBJ_camera;

    [Header("Text関連をここに入れといて")]

    [SerializeField] Text TEXT_camera;

    [Header("BatteryManagerを入れてね。")]

    [SerializeField] BatteryManager BM_mng;

    [Header("Trapを発動する位置用のObject")]

    [SerializeField] GameObject[] OBJ_trapPos;

    [Header("様々なTrapを入れてね")]

    [SerializeField] GameObject[] OBJ_trapObj;

    //[Header("それぞれのCamZoomUIを入れるとこ")]

    //[SerializeField] GameObject[] OBJ_camZoom;

    [Header("それぞれのGimmicUIを入れるとこ")]

    [SerializeField] GameObject[] OBJ_gimmicUI;

    [Header("SonarFxのScriptを入れてね")]

    // ソナースクリプト取得
    [SerializeField] SonarFx[] SonarFx_sf;

    [Header("それぞれのVoltトラップで使うImageを入れてね")]

    // ボルトトラップイメージ
    [SerializeField] Image[] IMAGE_Volt;

    [Header("VoltのCooltime用のTextを入れてね。")]

    [SerializeField] Text[] CT_Volt;

    [Header("Sencor用のTextを入れてね。")]

    [SerializeField] Text[] Sensor_Text;

    [Header("ScanManagerを入れてね")]

    ScanManager sMng;

    [Header("ステージ事に合わせたカメラの数を入力してください")]

    [SerializeField] int Camera_Num;

    [SerializeField] GameObject SensorS;

    //Voltトラップのクールタイム
    private int V_time = 20;

    private int Voltcounter = 0;

    //センサーの使えるバッテリー容量
    public int Sensor_Capacity;

    public int Cool_Volt;

    public int shiftbattery;

    public int voltbattery;

    public int SencorBattery;

    public float[] time_Gf;

    //Voltのtimerの変数
    private float[] time_Vs;

    //Voltのtimerの変数
    public float[] Volt_timers;

    //Volt用のFlag
    public bool[] Volt_Flg;

    //Camera用のFlag
    public bool[] Cam_Flg;

    //GlitchFx用のFlag
    public bool[] Gf_Flg;

    //Sensor用のFlag
    public bool[] IsSencor;

    void Start()
    {
        //sMng = GameObject.Find("ScanManager").GetComponent<ScanManager>();
        for (int i = 0; i < OBJ_camera.Length; i++)
        {
            // ボルトトラップ使用可能のテキスト「OK」を初めに表示

            CT_Volt[i].text = "OK";

            //Sencorトラップ使用可能のテキスト[OFF]を初めに表示
            Sensor_Text[i].text = "OFF";

            //　Imageを初めは0にしておく。
            IMAGE_Volt[i].GetComponent<Image>().fillAmount = 0;
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
        //時を止めてる間はreturnし続ける。
        if (Time.timeScale == 0) return;

        if (BM_mng.Para_Battery >= 5)
        {
            //Shiftキーを押したときにバッテリーを５%減らす。
            if (Input.GetKeyDown(KeyCode.LeftShift)) { BM_mng.Para_Battery -= shiftbattery; }

            if (Input.GetKey(KeyCode.LeftShift))
            {
                SonarOn();
                //Shiftキーを押し続けたときにバッテリーを継続的に減らす。
                if (BM_mng.Para_Battery >= 0) { BM_mng.Para_Battery -= 0.05f; }
            }
        }

        //Shiftキーを離したときにスキャンを止める。

        if (Input.GetKeyUp(KeyCode.LeftShift)) { SonarOff(); }

        //Voltトラップ呼出し
        if (BM_mng.Para_Battery >= 5)
        {
            
            for (int i = 0; i < Cam_Flg.Length; i++)
            {
                CT_Volt[i].text = "OK";
                if (Input.GetKeyDown(KeyCode.E) && Cam_Flg[i] && Volt_timers[i] >= Cool_Volt)
                {

                    Vector3 ObjPos = OBJ_trapPos[i].transform.position;
                    Instantiate(OBJ_trapObj[i], ObjPos, Quaternion.identity);
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
                GF_gf[i - 1].intensity += 1.0f;
                Gf_Flg[i - 1] = true;
            }
        }

        //GlitchFxの切り替えとノイズ表示
        for (int i = 0; i < Gf_Flg.Length; i++)
        {
            if (Gf_Flg[i])
            {
                time_Gf[i] += Time.deltaTime;
                if (time_Gf[i] >= 1)
                {
                    GF_gf[i].intensity = 0.01f;
                    time_Gf[i] = 0;
                    Gf_Flg[i] = false;
                }
            }
        }

        //VoltトラップとUIを切り替える

        for (int i = 0; i < Camera_Num; i++)
        {
            if (Cam_Flg[i] && Input.GetKeyDown(KeyCode.E) && IMAGE_Volt[i].fillAmount == 0 && BM_mng.Para_Battery >= 5)
            { 
                StartVoltTimer(i);
            }
            if (Volt_Flg[i])
            {
                Debug.Log("UPDate起動");
                UpdateVoltTimer(i);
            }
            if (BM_mng.Para_Battery <= Sensor_Capacity)
            {
                IsSencor[i] = false;  
                //return;
            }
            if(BM_mng.Para_Battery <= 5)
            {
                Sensor_Text[i].text = "OFF";
                CT_Volt[i].text = "NO";
            }
            if (BM_mng.Para_Battery >= 5)
            {
               
                if (Cam_Flg[i] && Input.GetKeyDown(KeyCode.C))
                {
                    IsSencor[i] = IsSencor[i] == false ? true : false;
                    if (IsSencor[i])
                    {
                        for (int j = 0; j < Sensor_Text.Length; j++)
                        {
                            Sensor_Text[j].text = "ON";
                        }
                        SensorS.SetActive(true);
                    }
                    if (!IsSencor[i])
                    {
                        for (int v = 0; v < Sensor_Text.Length; v++)
                        {
                            Sensor_Text[v].text = "OFF";


                        }
                        SensorS.SetActive(false);
                    }
                    BM_mng.Para_Battery -= SencorBattery;
                }
            }
        }
        for (int i = 0; i < IsSencor.Length; i++)
        {
            if (IsSencor[i]) BM_mng.Para_Battery -= 0.05f;
        }
        Debug.Log(Cool_Volt);
    }

    //GimmickとCamZoomの制御
    private void UIActive(int num)
    {
        for (int i = 0; i < OBJ_gimmicUI.Length; i++)
        {
            // 一旦全てのUI表示を非表示
            OBJ_gimmicUI[i].SetActive(false);
           // OBJ_camZoom[i].SetActive(false);
        }
        OBJ_gimmicUI[num].SetActive(true);
        //OBJ_camZoom[num].SetActive(true);
    }

    //以下カメラ機能のState
    private void SetCamera(int num)
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


    private void SetCamera1()
    {
        CameraScan();
        OBJ_camera[0].SetActive(true);
        TEXT_camera.text = "CAMERA1";
    }

    private void SetCamera2()
    {
        CameraScan();
        OBJ_camera[1].SetActive(true);

        TEXT_camera.text = "CAMERA2";
    }

    private void SetCamera3()
    {
        CameraScan();
        OBJ_camera[2].SetActive(true);
        TEXT_camera.text = "CAMERA3";
    }

    private void SetCamera4()
    {
        CameraScan();
        OBJ_camera[3].SetActive(true);
        TEXT_camera.text = "CAMERA4";
    }

    private void SetCamera5()
    {
        CameraScan();
        OBJ_camera[4].SetActive(true);
        TEXT_camera.text = "CAMERA5";
    }
    private void SetCamera6()
    {
        CameraScan();
        OBJ_camera[5].SetActive(true);
        TEXT_camera.text = "CAMERA6";
    }
    private void SonarOff()
    {
        for (int i = 0; i < SonarFx_sf.Length; i++)
        {
            SonarFx_sf[i].enabled = false;
        }
    }
    private void SonarOn()
    {
        for (int i = 0; i < SonarFx_sf.Length; i++)
        {
            SonarFx_sf[i].enabled = true;
        }
    }
    private void CameraScan()
    {
        for (int i = 0; i < OBJ_camera.Length; i++)
        {
            OBJ_camera[i].SetActive(false);
        }
    }

    private void CamFlag()
    {
        for (int i = 0; i < Cam_Flg.Length; i++)
        {
            Cam_Flg[i] = false;
        }
    }

    private void StartVoltTimer(int index)
    {
        CT_Volt[index].text = V_time.ToString();
        IMAGE_Volt[index].fillAmount = 1;
        Volt_Flg[index] = true;
    }
    private void UpdateVoltTimer(int index)
    {
        Volt_timers[index] -= Time.deltaTime;
            CT_Volt[index].text = ((int)Volt_timers[index]).ToString();
        IMAGE_Volt[index].fillAmount -= 1.0f / (float)Cool_Volt* Time.deltaTime;
            if (Volt_timers[index] <= 0)
            {
                Volt_Flg[index] = false;
                CT_Volt[index].text = "OK";
                Volt_timers[index] = Cool_Volt;
            }
    }

    void Battery_nega()
    {
        if (BM_mng.Para_Battery >= 0)
        {
            BM_mng.Para_Battery -= voltbattery;
        }
    }
}