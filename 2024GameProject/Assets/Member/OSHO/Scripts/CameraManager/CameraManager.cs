using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Pixeye.Unity;   // フォルダ機能

public class CameraManager : MonoBehaviour
{
    #region field
    /*プレイヤーが実際に操作する機能*/
    #region
    // カメラの切り替え機能を実装
    [Foldout("ギミック"),Header("カメラ切り替えのスクリプト"),SerializeField] CameraChange cam;
    // Volt機能を実装する
    [Foldout("ギミック"),Header("Voltのギミックスクリプト"), SerializeField] Volt volt;
    // Scan機能を実装する
    [Foldout("ギミック"),Header("Scanのギミックスクリプト"), SerializeField] Scan scan;
    // ソナー機能を実装する
    [Foldout("ギミック"), Header("Sonarのギミックスクリプト"), SerializeField] SubLight sonar;
    #endregion

    // UIの揺れ実装
    // 0:センサー 1:スキャン 2:ボルト
    [Header("UIShakeのスクリプト"), SerializeField] UIShake[] shake;

    // フェードの実装
    [Header("Fadeのスクリプト"), SerializeField] Fade fade;
    // 回復,消費、カラーチェンジなどをこのスクリプトで
    [Header("バッテリー機能"), SerializeField] BatteryManager battery;
    // 音再生に使う
    [Header("音再生機能のスクリプト"),SerializeField] GameManager gMng;

    // コスト
    const int cost_volt = 5;  // ボルト
    const int cost_scan = 15; // スキャン

    // カメラ切り替え用
    private int cameraNum = 1;

    // ソナー使用のフラグ
    private bool trapFlg = false;

    // センサー使用中電力回復を制限する
    private bool IsSensor = false;

    // センサーライトフラグオンオフ切替
    private bool IsSwitch = false;
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
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (battery.Para_Battery >= cost_volt)
            {
                // ボルト生成
                if (volt.UseVolt(cameraNum))
                {
                    // 音再生
                    gMng.OneShotSE_U(SEData.Type.ETC, GameManager.UISe.Eff2);
                    // バッテリー消費
                    BatteryCost(cost_volt);
                }
                else // 使えないことを知らせるためにUIを動かす
                {
                    gMng.OneShotSE_U(SEData.Type.ETC, GameManager.UISe.Eff5);
                    shake[2].Shake();
                }
            }
            else
            {
                gMng.OneShotSE_U(SEData.Type.ETC, GameManager.UISe.Eff5);
                shake[2].Shake();
            }
        }
        // ボルトのリチャージ
        volt.Recharge();

        // スキャン機能
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (battery.Para_Battery >= cost_scan)
            {
                // スキャン開始
                if (scan.UseScan())
                {
                    // 音再生
                    gMng.OneShotSE_U(SEData.Type.ETC, GameManager.UISe.Eff4);
                    // バッテリー消費
                    BatteryCost(cost_scan);
                }
                else
                {
                    shake[1].Shake();
                    gMng.OneShotSE_U(SEData.Type.ETC, GameManager.UISe.Eff5);
                }
            }
            else
            {
                shake[1].Shake();
                gMng.OneShotSE_U(SEData.Type.ETC, GameManager.UISe.Eff5);
            }
        }
        // スキャンのリチャージ
        scan.Recharge();

        if(Input.GetKeyDown(KeyCode.F))
        {
            IsSwitch = IsSwitch ? false : true;
            // 起動した最初のみで実行する処理
            if (!IsSensor)
            {
                // 音再生
                gMng.OneShotSE_U(SEData.Type.ETC, GameManager.UISe.Eff3);
                // バッテリー消費
                IsSensor = true;
                //shake[0].Shake()
            }
        }
        if (IsSwitch) // ON状態処理
        {
            // ソナーライト
            sonar.UseLight(cameraNum);
        }
        else // OFF状態処理
        {
            IsSensor = false;
            // 通常ライト
            sonar.NormalLight(cameraNum);
        }
        // 回復機能
        if (!IsSensor){ battery.HealBattery(); }
        // バッテリー残量によってUIにプレイヤーに対し注意効果を付ける
        battery.Battery_Color();

        /*コスト以下の電力の時に使えないことを知らせる*/
        /*コストがあり、クールタイム期間でなければREADYにする*/
        if (cost_volt > battery.Para_Battery)
        {
            volt.NotCost();
        }
        else
        {
            volt.ReadySet();
        }
        if(cost_scan>battery.Para_Battery)
        {
            scan.NotCost();
        }
        else
        {
            scan.ReadySet();
        }
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