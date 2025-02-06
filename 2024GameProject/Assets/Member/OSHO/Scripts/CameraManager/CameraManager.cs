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

    // コスト
    [Header("ボルトのコスト")]const int cost_volt=7;
    [Header("スキャンのコスト")]const int cost_scan=20;

    // カメラ切り替え用
    private int cameraNum = 1;

    // ソナー中に回復しないように
    private bool trapFlg = false;

    //GlitchFx用のFlag
    [Header("各Glitch_Fx用のフラグ")]
    public bool[] Gf_Flg;
    #endregion


    void Start()
    {
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
        if (Input.GetKeyDown(KeyCode.C)&&battery.Para_Battery>=cost_volt)
        {
            // 音再生
            gMng.OneShotSE_U(SEData.Type.ETC, GameManager.UISe.Eff2);
            // バッテリー消費
            BatteryCost(cost_volt);
            // ボルト生成
            volt.UseVolt(cameraNum);
        }
        // ボルトのリチャージ
        volt.Recharge();

        // スキャン機能
        if (Input.GetKeyDown(KeyCode.X)&&battery.Para_Battery>=cost_scan)
        {
            // 音再生
            gMng.OneShotSE_U(SEData.Type.ETC, GameManager.UISe.Eff3);
            // バッテリー消費
            BatteryCost(cost_scan);
            // スキャン開始
            scan.UseScan();
        }
        // スキャンのリチャージ
        scan.Recharge();

        // 回復機能
        battery.HealBattery();
        // バッテリー残量によってUIにプレイヤーに対し注意効果を付ける
        battery.Battery_Color();
    }

    /// <summary>
    /// バッテリー消費の処理
    /// </summary>
    /// <param name="cost">消費コスト</param>
    void BatteryCost(int cost)
    {
        battery.Para_Battery -= cost;
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