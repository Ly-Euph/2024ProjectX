using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraManager : MonoBehaviour
{
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

    [Header("それぞれのScanUIを入れるとこ")]

    [SerializeField] Image Scan_UI;

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

    [Header("それぞれのEchoトラップで使うImageを入れてね")]
    
    //エコートラップイメージ
    [SerializeField] Image[] Echo_Img;

    [Header("VoltのCooltime用のTextを入れてね。")]

    [SerializeField] Text[] CT_Volt;
    
    [Header("EchoのCooltime用のTextを入れてね。")]

    [SerializeField] Text[] CT_Echo;

    [Header("EchoManagerを入れてね")]
    //Echoマネージャー取得
    [SerializeField] EchoManager eMng;

    ScanManager sMng;

    //クールタイムUIに反映させるUI
    private int V_time = 20;
    private int E_time = 20;

    //Voltのtimerの変数

    private float[] time_Vs;

    //Echoのtimerの変数

    private float[] time_Es;

    public float[] Volt_timers;

    //Echoのtimerの変数
    public float[] Echo_timers;

    //Volt用のFlag
    public bool[] Volt_Flg;

    //Echo用のFlag
    public  bool[] Echo_Flg;

    //Camera用のFlag
    public  bool[] Cam_Flg;

    void Start()
    {
        sMng = GameObject.Find("ScanManager").GetComponent<ScanManager>();
        for (int i = 0; i < Camera.Length; i++)
        {
            // ボルトトラップ使用可能のテキスト「OK」を初めに表示

            CT_Volt[i].text = "OK";
            CT_Echo[i].text = "OK";

            //　Imageを初めは0にしておく。

            Volt_Img[i].GetComponent<Image>().fillAmount = 0;
            Echo_Img[i].GetComponent<Image>().fillAmount = 0; 
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

            time_Es = new float[Echo_timers.Length];
    }

    void Update()
    {
        //時を止めてる間はreturnし続ける。
        if (Time.timeScale == 0) return;

        //Shiftキーを押したときにバッテリーを５%減らす。
        if (Input.GetKeyDown(KeyCode.LeftShift)) { Bm.Para_Battery -= 5f; }


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

        //ボルトトラップ呼出し

        for (int i = 0; i < Cam_Flg.Length; i++)
        {
            if (Input.GetKeyDown(KeyCode.E) && Cam_Flg[i] && Volt_timers[i] >= 20)
            {
                Debug.Log("Volt生成");
                Vector3 ObjPos = Trap_Obj[i].transform.position;
                Instantiate(Trap_GK[i], ObjPos, Quaternion.identity);
                time_Vs[i] = 0;
                if (Bm.Para_Battery >= 0)
                {
                    Bm.Para_Battery -= 10;
                }
                // クールタイム計測
                time_Vs[i] += Time.deltaTime;
                if (time_Vs[i] >= Volt_timers[i])
                {
                    time_Vs[i] = Volt_timers[i]; // クールタイムがリセットされないようにする
                }
            }
            if (Input.GetKeyDown(KeyCode.C) && Cam_Flg[i] && Echo_timers[i] >= 20)
            {
                Debug.Log("Echo生成");
                eMng.EchoMode();
                time_Es[i] = 0;
                if(Bm.Para_Battery >= 0)
                {
                    Bm.Para_Battery -= 10;
                }
                time_Es[i] += Time.deltaTime;
                if (time_Es[i] >= Echo_timers[i])
                {
                    time_Es[i] = Echo_timers[i];
                }
            }
        }

        //エコートラップ呼出

        //番号１
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //Camera1の設定
            SetCamera1();
            CamFlag();
            Cam_Flg[0] = true;
            UIActive(0);
        }
        //番号２

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            //Camera2の設定
            SetCamera2();
            CamFlag();
            Cam_Flg[1] = true;
            UIActive(1);
        }

        //番号３

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            //Camera3の設定
            SetCamera3();
            CamFlag();
            Cam_Flg[2] = true;
            UIActive(2);
        }
        //番号４

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            //Camera4の設定
            SetCamera4();
            CamFlag();
            Cam_Flg[3] = true;
            UIActive(3);
        }
        //番号５

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            //Camera5の設定
            SetCamera5();
            CamFlag();
            Cam_Flg[4] = true;
            UIActive(4);
        }
        //番号６

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            //Camera6の設定
            SetCamera6();
            CamFlag();
            Cam_Flg[5] = true;
            UIActive(5);
        }

        //VoltトラップとUIを切り替える

        for (int i = 0; i < 6; i++)
        {
            if (Cam_Flg[i] && Input.GetKeyDown(KeyCode.E) && Volt_Img[i].fillAmount == 0)
            {
                StartVoltTimer(i);
            }
            if (Volt_Flg[i])
            {
                UpdateVoltTimer(i);
            }
        }

        //EchoトラップとUIを切り替える。

        for (int i = 0; i < 6; i++)
        {
            if (Cam_Flg[i] && Input.GetKeyDown(KeyCode.C) && Echo_Img[i].fillAmount == 0)
            {
                StartEchoTimer(i);
            }
            if (Echo_Flg[i])
            {
                UpdateEchoTimer(i);
            }
        }
    }

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

    //以下カメラ機能の制御

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

    void StartEchoTimer(int index)
    {
        CT_Echo[index].text = E_time.ToString();
        Echo_Img[index].fillAmount = 1;
        Echo_Flg[index] = true;

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

    void UpdateEchoTimer(int index)
    {
        Echo_timers[index] -= Time.deltaTime;
        CT_Echo[index].text = ((int)Echo_timers[index]).ToString();
        Echo_Img[index].fillAmount -= 1 / 20.0f * Time.deltaTime;

        if(Echo_timers[index] <= 0)
        {
            Echo_Flg[index] = false;
            CT_Echo[index].text = "OK";
            Echo_timers[index] = 20;
        }
    }
}