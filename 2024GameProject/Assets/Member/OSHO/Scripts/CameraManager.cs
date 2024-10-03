using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraManager : MonoBehaviour
{
    public GlitchFx[] GF_gf;

    [SerializeField] GameManager gMng;

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

    [Header("SensorPを入れてね。")]
    [SerializeField] GameObject SensorS;

    //Voltトラップのクールタイム
    private int V_time = 20;

    private int Voltcounter = 0;

    [Header("センサーの使えるバッテリー容量")]
    public int Sensor_Capacity;

    [Header("Voltのクールタイム")]
    public int Cool_Volt;

    [Header("Shiftを押した時のバッテリーの減算")]
    public int shiftbattery;

    [Header("Eキー（ボルトを押したときの）のバッテリー減算")]
    public int voltbattery;

    [Header("Cキー（センサーを押したとき）のバッテリーの減算")]
    public int SencorBattery;

    // ソナー中に回復しないように
    private bool trapFlg = false;

    [Header("Glitch Fx用の変数")]
    public float[] time_Gf;

    //Voltのtimerの変数
    private float[] time_Vs;

    // 音の連続再生制御
    float _timer = 0;

    //Voltのtimerの変数
    [Header("各カメラのVoltのタイマー")]
    public float[] Volt_timers;

    //Volt用のFlag
    [Header("各Volt用のフラグ")]
    public bool[] Volt_Flg;

    //Camera用のFlag
    [Header("各カメラ用のフラグ")]
    public bool[] Cam_Flg;

    //GlitchFx用のFlag
    [Header("各Glitch_Fx用のフラグ")]
    public bool[] Gf_Flg;

    //Sensor用のFlag
    [Header("各センサー用のフラグ")]
    public bool[] Sensor_Flg;

    /// <summary>
    /// trapFlgの値やり取り用
    /// </summary>
    public bool SendtrapFlg
    {
        get
        {
            return trapFlg;
        }
    }
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
        SetCamera(0);
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
            if (Input.GetKeyDown(KeyCode.Z))
            {
                BM_mng.Para_Battery -= shiftbattery;
            }

            if (Input.GetKey(KeyCode.Z))
            {
                //Shiftキーを押し続けたときにバッテリーを継続的に減らす。
                if (BM_mng.Para_Battery >= 3.0f) {
                    _timer += Time.deltaTime;
                    //ソナーを押してる間の音。
                    gMng.OneShotSE_U(SEData.Type.ETC, GameManager.UISe.Eff4);
                    if (_timer>=1) 
                    {
                        _timer = 0;
                        gMng.OneShotSE_U(SEData.Type.ETC, GameManager.UISe.Eff4);
                    }
                    SonarOn();
                    BM_mng.Para_Battery -= 0.05f; 
                    trapFlg = true;
                }
            }
        }
        else
        {
            Debug.Log("ソナー停止");

            trapFlg = false;
            SonarOff();
        }

        //Shiftキーを離したときにスキャンを止める。

        if (Input.GetKeyUp(KeyCode.LeftShift))
        { 
            SonarOff(); 
            trapFlg = false;   
        }

        //バッテリー残量が５％以上の時Voltトラップ呼出し
        if (BM_mng.Para_Battery >= 5)
        {
            
            for (int i = 0; i < Cam_Flg.Length; i++)
            {
                CT_Volt[i].text = "OK";
                if (Input.GetKeyDown(KeyCode.X) && Cam_Flg[i] && Volt_timers[i] >= Cool_Volt)
                {
                    gMng.OneShotSE_U(SEData.Type.ETC, GameManager.UISe.Eff2);
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

        //CameraNumの数に応じてカメラ関連の切り替え
        for (int i = 1; i <= Camera_Num; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i - 1))
            {
                //カメラ切り替え時のSE
                gMng.OneShotSE_U(SEData.Type.ETC, GameManager.UISe.Eff1);
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
            if (Cam_Flg[i] && Input.GetKeyDown(KeyCode.C) && IMAGE_Volt[i].fillAmount == 0 && BM_mng.Para_Battery >= 5)
            {
                //VoltのSE
                //gMng.OneShotSE_U(SEData.Type.ETC, GameManager.UISe.Eff2);
                StartVoltTimer(i);
            }
            if (Volt_Flg[i])
            {
                UpdateVoltTimer(i);
            }
            if (BM_mng.Para_Battery <= Sensor_Capacity)
            {
                Sensor_Flg[i] = false;  
                //return;
            }
            if(BM_mng.Para_Battery <= 5)
            {
                Sensor_Text[i].text = "OFF";
                CT_Volt[i].text = "NO";
                SensorS.SetActive(false);
            }
            if (BM_mng.Para_Battery >= 5)
            {
               
                if (Cam_Flg[i] && Input.GetKeyDown(KeyCode.C))
                {
                    gMng.OneShotSE_U(SEData.Type.ETC, GameManager.UISe.Eff3);
                    Sensor_Flg[i] = Sensor_Flg[i] == false ? true : false;
                    if (Sensor_Flg[i])
                    {
                        for (int j = 0; j < Sensor_Text.Length; j++)
                        {
                            Sensor_Text[j].text = "ON";
                        }
                        SensorS.SetActive(true);
                    }
                    if (!Sensor_Flg[i])
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
        for (int i = 0; i < Sensor_Flg.Length; i++)
        {
            if (Sensor_Flg[i]) BM_mng.Para_Battery -= 0.05f;
        }
       
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
    //カメラ関連の切り替えの処理
    private void SetCamera(int num)
    {
        if (num >= 1 && num <= 9)
        {
            CameraScan();
            for (int i = 0; i < OBJ_camera.Length; i++)
            {
                OBJ_camera[i].SetActive(i == num - 1);
            }
            //numの数字に応じてText（CAMERA○○）を表示
            TEXT_camera.text = $"CAMERA{num}";
        }
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