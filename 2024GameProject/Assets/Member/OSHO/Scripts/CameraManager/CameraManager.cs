using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraManager : MonoBehaviour
{
    #region field
    // フェードの実装
    [Header("FadeのPrefab"),SerializeField] Fade fade;

    // 音再生に使う
    [SerializeField] GameManager gMng;

    // ノイズ実装
    [Header("GlitchFxのスクリプトを入れてね"),SerializeField] GlitchFx[] GF_gf;

    // 回復,消費、カラーチェンジなどをこのスクリプトで
    [Header("バッテリー機能"), SerializeField] BatteryManager battery;

    /*プレイヤーが実際に操作する機能*/
    #region
    // カメラの切り替え機能を実装
    [Header("カメラ切り替えのスクリプト"),SerializeField] CameraChange cam;
    // Volt機能を実装する
    [Header("Voltのギミックスクリプト"), SerializeField] Volt volt;
    // Scan機能を実装する
    [Header("Scanのギミックスクリプト"), SerializeField] Scan scan;
    #endregion

    /*現状は使わない予定*/
    // ソナースクリプト取得
    //[Header("SonarFxのスクリプト"),SerializeField] SonarFx[] SonarFx_sf;

    [Header("○○以下になったらの数字")]

    [SerializeField] int Under_Battery;

    private bool SencorFlg = false;

    [Header("センサーの使えるバッテリー容量")]
    public int Sensor_Capacity;

    [Header("Z(ソナー）を押した時のバッテリーの減算")]
    public int SonarBattery;

    [Header("Eキー（ボルトを押したときの）のバッテリー減算")]
    public int voltbattery;

    [Header("Cキー（センサーを押したとき）のバッテリーの減算")]
    public int SencorBattery;

    [Header("ノイズ処理の調整用")]
    public float Gf_float;

    // カメラ切り替え用
    private int cameraNum = 1;

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

    //GlitchFx用のFlag
    [Header("各Glitch_Fx用のフラグ")]
    public bool[] Gf_Flg;

    //Sensor用のFlag
    [Header("各センサー用のフラグ")]
    public bool[] Sensor_Flg;
    #endregion


    void Start()
    {
        ////Sencorトラップ使用可能のテキスト[OFF]を初めに表示
        //Sensor_Text.text = "OFF";

        //Sonartxをfalseに
        //SonarOff();

        // カメラの設定
        cam.CameraStart();

        // ボルトの初期設定
        volt.VoltStart();

        // スキャンの初期設定
        scan.ScanStart();
    }

    void Update()
    {
        //時を止めてる間はreturnし続ける。
        if (Time.timeScale == 0) return;

        // カメラの切り替え機能
        CamChange();

        // ボルト機能
        if (Input.GetKeyDown(KeyCode.C))
        {
            // 音再生
            gMng.OneShotSE_U(SEData.Type.ETC, GameManager.UISe.Eff2);
            // ボルト生成
            volt.UseVolt(cameraNum);
        }
        // ボルトのリチャージ
        volt.Recharge();

        // スキャン機能
        if (Input.GetKeyDown(KeyCode.X))
        {
            // 音再生
            gMng.OneShotSE_U(SEData.Type.ETC, GameManager.UISe.Eff3);
            // スキャン開始
            scan.UseScan();
        }
        // スキャンのリチャージ
        scan.Recharge();

        // 回復機能
        battery.HealBattery();
        // バッテリー残量によってUIにプレイヤーに対し注意効果を付ける
        battery.Battery_Color();


        //if (BM_mng.Para_Battery >= Under_Battery)
        //{

        //    //Shiftキーを押したときにバッテリーを５%減らす。
        //    if (Input.GetKeyDown(KeyCode.Z))
        //    {
        //        BM_mng.Para_Battery -= SonarBattery;
        //    }

        //    if (Input.GetKey(KeyCode.Z))
        //    {
        //        //Shiftキーを押し続けたときにバッテリーを継続的に減らす。
        //        if (BM_mng.Para_Battery >= 3.0f)
        //        {
        //            _timer += Time.deltaTime;
        //            //ソナーを押してる間の音。
        //            gMng.OneShotSE_U(SEData.Type.ETC, GameManager.UISe.Eff4);
        //            if (_timer >= 1)
        //            {
        //                _timer = 0;
        //                gMng.OneShotSE_U(SEData.Type.ETC, GameManager.UISe.Eff4);
        //            }
        //            SonarOn();
        //            BM_mng.Para_Battery -= 0.05f;
        //            trapFlg = true;
        //        }
        //    }
        //}
        //else
        //{
        //    Debug.Log("ソナー停止");

        //    trapFlg = false;
        //    SonarOff();
        //}

        ////Shiftキーを離したときにスキャンを止める。

        //if (Input.GetKeyUp(KeyCode.Z))
        //{
        //    SonarOff();
        //    trapFlg = false;
        //}

        ////バッテリー残量が５％以上の時Voltトラップ呼出し
        //if (BM_mng.Para_Battery >= Under_Battery)
        //{

        //    for (int i = 0; i < Cam_Flg.Length; i++)
        //    {
        //        CT_Volt.text = "OK";
        //        if (Input.GetKeyDown(KeyCode.C) && Cam_Flg[i] && Volt_timers[i] >= Cool_Volt)
        //        {
        //            Vector3 ObjPos = Obj_Trap[i].transform.position;
        //            Instantiate(OBJ_trapObj[i], ObjPos, Quaternion.identity);
        //            time_Vs[i] = 0;
        //            Battery_nega();
        //            // クールタイム計測
        //            time_Vs[i] += Time.deltaTime;
        //            if (time_Vs[i] >= Volt_timers[i])
        //            {
        //                time_Vs[i] = Volt_timers[i]; // クールタイムがリセットされないようにする
        //            }
        //        }
        //    }
        //}


        ////GlitchFxの切り替えとノイズ表示
        //for (int i = 0; i < Gf_Flg.Length; i++)
        //{
        //    if (Gf_Flg[i])
        //    {
        //        time_Gf[i] += Time.deltaTime;
        //        if (time_Gf[i] >= 1)
        //        {
        //            GF_gf[i].intensity = 0.001f;
        //            time_Gf[i] = 0;
        //            Gf_Flg[i] = false;
        //        }
        //    }
        //}

        ////VoltトラップとUIを切り替え
        //for (int i = 0; i < Camera_Num; i++)
        //{
        //    if (Cam_Flg[i] && Input.GetKeyDown(KeyCode.C) && IMAGE_Volt.fillAmount == 0 && BM_mng.Para_Battery >= 5)
        //    {
        //        //VoltのSE
        //        gMng.OneShotSE_U(SEData.Type.ETC, GameManager.UISe.Eff2);
        //        StartVoltTimer(i);
        //    }
        //    if (Volt_Flg[i])
        //    {
        //        UpdateVoltTimer(i);
        //    }
        //    if (BM_mng.Para_Battery <= Sensor_Capacity)
        //    {
        //        Sensor_Flg[i] = false;
        //        //return;
        //    }
        //    if (BM_mng.Para_Battery <= Under_Battery)
        //    {
        //        Sensor_Text.text = "OFF";
        //        CT_Volt.text = "NO";
        //        SensorS.SetActive(false);
        //        for (int j = 0; j < cameraNum; j++)
        //        {
        //            Sensor_Flg[j] = false;
        //        }
        //        SencorFlg = false;
        //    }
        //    if (BM_mng.Para_Battery >= Under_Battery)
        //    {
        //        if (Cam_Flg[i] && Input.GetKeyDown(KeyCode.X))
        //        {
        //            Sensor_Flg[i] = Sensor_Flg[i] == false ? true : false;
        //            if (Sensor_Flg[i])
        //            {
        //                Sensor_Text.text = "ON";
        //                SensorS.SetActive(true);
        //                BM_mng.Para_Battery -= SencorBattery;
        //                SencorFlg = true;

        //            }
        //            if (!Sensor_Flg[i])
        //            {
        //                Sensor_Text.text = "OFF";
        //                SensorS.SetActive(false);
        //                SencorFlg = false;
        //            }
        //        }
        //    }
        //}
        //if (SencorFlg)
        //{
        //    if (BM_mng.Para_Battery > 3.0f)
        //    {
        //        BM_mng.Para_Battery -= 0.05f;
        //        Debug.Log("バッテリー残量");
        //    }
        //    else
        //    {
        //        for (int j = 0; j < cameraNum; j++)
        //        {
        //            Sensor_Flg[j] = false;
        //        }
        //        Sensor_Text.text = "OFF";
        //        SensorS.SetActive(false);

        //        SencorFlg = false;
        //    }
        //}
    }

    void Battery_nega()
    {
        if (battery.Para_Battery >= 0)
        {
            battery.Para_Battery -= voltbattery;
        }
    }

    /// <summary>
    /// CameraNumの数に応じてカメラ関連の切り替え
    /// </summary>
    private void CamChange()
    {
        for (int i = 1; i <= cam.CameraNum; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i - 1))
            {
                //カメラ切り替え時のSE
                gMng.OneShotSE_U(SEData.Type.ETC, GameManager.UISe.Eff1);
                //fadeさせる処理
                fade.FadeIn(0.1f, () =>
                fade.FadeOut(0.2f)
                );
                cameraNum = i;
                cam.SetCamera(cameraNum);
                Gf_Flg[cameraNum - 1] = true;

            }
        }
    }

    // 現状ステルスの敵に対して使う
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

    // Mutantが値を取れるように
    public int CameraNum
    {
        get
        {
            return cameraNum;
        }
    }
}