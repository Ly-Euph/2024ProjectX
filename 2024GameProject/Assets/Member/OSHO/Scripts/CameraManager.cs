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

    [Header("Trapを設置するObject")]

    [SerializeField] GameObject[] Trap_Obj;

    [Header("様々なTrapを入れてね")]

    [SerializeField] GameObject[] Trap_GK;

    [Header("ScanしているときのUI")]

    //スキャン中に表示するUI
    [SerializeField] Image ScanUI;

    // カメラズームのUI
    [SerializeField] GameObject[] CamZoom;

    // スキルUI
    [SerializeField] GameObject[] Gimmick;

    // ソナースクリプト取得
    [SerializeField] SonarFx[] sf;

    // ボルトトラップイメージ
    [SerializeField] Image[] Volt_Img;

    [SerializeField] Image[] Echo_Img;

    [SerializeField] Text[] CoolTime_Volt;

    [SerializeField] Text[] CoolTime_Echo;

    ScanManager sMng;
    [SerializeField] EchoManager eMng;

    private float Scan_Num;

    private int Volt_time = 20;
    private int Echo_time = 20;

    private float time_V;
    private float time_V2;

    private float time_C;
    private float time_C2;

    //Voltのtimerの変数

    private float Volt_timer = 20;
    private float Volt_timer1 = 20;
    private float Volt_timer2 = 20;
    private float Volt_timer3 = 20;
    private float Volt_timer4 = 20;
    private float Volt_timer5 = 20;

    //Echoのtimerの変数
    public float Echo_timer = 20; 
    public float Echo_timer1 = 20;
    public float Echo_timer2 = 20;
    public float Echo_timer3 = 20;
    public float Echo_timer4 = 20;
    public float Echo_timer5 = 20;


    private bool TimeFlg = false;

    private bool[] Volt_Flg = new bool[6];

    private bool[] Echo_Flg = new bool[6];

    private bool[] CamFlg = new bool[6];

    void Start()
    {
        sMng = GameObject.Find("ScanManager").GetComponent<ScanManager>();
        for (int i = 0; i < Camera.Length; i++)
        {
            // ボルトトラップ使用可能
            CoolTime_Volt[i].text = "OK";
            CoolTime_Echo[i].text = "OK";
            //sfの配列にSonarFxをげっとする。
            Volt_Img[i].GetComponent<Image>().fillAmount = 0;
            Echo_Img[i].GetComponent<Image>().fillAmount = 0;        }
        // カメラ1のみ表示
        //Camera1の設定
        SetCamera1();
        CamFlag();
        CamFlg[0] = true;
        UIActive(0);
        //Sonartxをfalseに
        SonarOff();
    }

    void Update()
    {
        //時を止めてる間はreturnする。
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
        //トラップEキーを押したときの処理

        //カメラ１のボルトトラップ

        if (Input.GetKeyDown(KeyCode.E) && CamFlg[0] && Volt_timer >= 20)
        {
            Vector3 ObjPos = Trap_Obj[0].transform.position;
            Instantiate(Trap_GK[0], ObjPos, Quaternion.identity);
            TimeFlg = false;
            time_V = 0;
            if (Bm.Para_Battery >= 0)
            {
                Bm.Para_Battery -= 10;
            }
        }
        if (!TimeFlg)
        {
            time_V += Time.deltaTime;
            //Fキーのクールタイム
            if (time_V >= Volt_timer)
            {
                TimeFlg = true;
            }
        }

        //カメラ2のボルトトラップ

        if (Input.GetKeyDown(KeyCode.E) && CamFlg[1] && Volt_timer1 >= 20)
        {
            Vector3 ObjPos = Trap_Obj[1].transform.position;
            Instantiate(Trap_GK[1], ObjPos, Quaternion.identity);
            TimeFlg = false;
            time_V2 = 0;
            if (Bm.Para_Battery >= 0)
            {
                Bm.Para_Battery -= 10;
            }
        }
        if (!TimeFlg)
        {
            time_V2 += Time.deltaTime;
            //Fキーのクールタイム
            if (time_V2 >= Volt_timer1)
            {
                TimeFlg = true;
            }
        }

        //カメラ1のエコートラップ
        if(Input.GetKeyDown(KeyCode.C) && CamFlg[0] && Echo_timer >= 20)
        {
            eMng.EchoMode();
            TimeFlg = false;
            time_C = 0;

            if(Bm.Para_Battery >= 0)
            {
                Bm.Para_Battery -= 10;
            } 
        }
        if(!TimeFlg)
        {
            time_C += Time.deltaTime;
            if (time_C >= Echo_timer)
            {
                TimeFlg = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.C) && CamFlg[1] && Echo_timer1 >= 20)
        {
            eMng.EchoMode();
            TimeFlg = false;
            time_C2 = 0;
            if (Bm.Para_Battery >= 0)
            {
                Bm.Para_Battery -= 10;
            }
        }
        if (!TimeFlg)
        {
            time_C2 += Time.deltaTime;
            if (time_C2 >= Echo_timer1)
            {
                TimeFlg = true;
            }
        }

        //番号１
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //Camera1の設定
            SetCamera1();
            CamFlag();
            CamFlg[0] = true;
            UIActive(0);
        }
        //番号２

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            //Camera2の設定
            SetCamera2();
            CamFlag();
            CamFlg[1] = true;
            UIActive(1);
        }

        //番号３

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            //Camera3の設定
            SetCamera3();
            CamFlag();
            CamFlg[2] = true;
            UIActive(2);
        }
        //番号４

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            //Camera4の設定
            SetCamera4();
            CamFlag();
            CamFlg[3] = true;
            UIActive(3);
        }
        //番号５

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            //Camera5の設定
            SetCamera5();
            CamFlag();
            CamFlg[4] = true;
            UIActive(4);
        }
        //番号６

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            //Camera6の設定
            SetCamera6();
            CamFlag();
            CamFlg[5] = true;
            UIActive(5);
        }

        //VoltトラップとUIを切り替える

        for (int i = 0; i < 6; i++)
        {
            if (CamFlg[i] && Input.GetKeyDown(KeyCode.E) && Volt_Img[i].fillAmount == 0)
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
            if (CamFlg[i] && Input.GetKeyDown(KeyCode.C) && Echo_Img[i].fillAmount == 0)
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
            CamZoom[i].SetActive(false);
        }
        Gimmick[num].SetActive(true);
        CamZoom[num].SetActive(true);
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
        for (int i = 0; i < sf.Length; i++)
        {
            sf[i].enabled = false;
        }
    }
    void SonarOn()
    {
        for (int i = 0; i < sf.Length; i++)
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

    void CamFlag()
    {
        for (int i = 0; i < CamFlg.Length; i++)
        {
            CamFlg[i] = false;
        }
    }

    void StartVoltTimer(int index)
    {
        CoolTime_Volt[index].text = Volt_time.ToString();
        Volt_Img[index].fillAmount = 1;
        Volt_Flg[index] = true;
    }

    void StartEchoTimer(int index)
    {
        CoolTime_Echo[index].text = Echo_time.ToString();
        Echo_Img[index].fillAmount = 1;
        Echo_Flg[index] = true;

    }
    void UpdateVoltTimer(int index)
    {
        float[] Volt_timers = { Volt_timer, Volt_timer1, Volt_timer2, Volt_timer3, Volt_timer4, Volt_timer5 };

        Volt_timers[index] -= Time.deltaTime;
        CoolTime_Volt[index].text = ((int)Volt_timers[index]).ToString();
        Volt_Img[index].fillAmount -= 1 / 20.0f * Time.deltaTime;

        if (Volt_timers[index] <= 0)
        {
            Volt_Flg[index] = false;
            CoolTime_Volt[index].text = "OK";
            Volt_timers[index] = 20;
        }
        Volt_timer = Volt_timers[0];
        Volt_timer1 = Volt_timers[1];
        Volt_timer2 = Volt_timers[2];
        Volt_timer3 = Volt_timers[3];
        Volt_timer4 = Volt_timers[4];
        Volt_timer5 = Volt_timers[5];
    }

    void UpdateEchoTimer(int index)
    {
        float[] Echo_timers = { Echo_timer, Echo_timer1, Echo_timer2, Echo_timer3, Echo_timer4, Echo_timer5 };

        Echo_timers[index] -= Time.deltaTime;
        CoolTime_Echo[index].text = ((int)Echo_timers[index]).ToString();
        Echo_Img[index].fillAmount -= 1 / 20.0f * Time.deltaTime;

        if(Echo_timers[index] <= 0)
        {
            Echo_Flg[index] = false;
            CoolTime_Echo[index].text = "OK";
            Echo_timers[index] = 20;
        }

        Echo_timer = Echo_timers[0];
        Echo_timer1= Echo_timers[1];
        Echo_timer2 = Echo_timers[2];
        Echo_timer3 = Echo_timers[3];
        Echo_timer4 = Echo_timers[4];
        Echo_timer5 = Echo_timers[5];
    }
}