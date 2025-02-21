using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Scan : MonoBehaviour
{
    #region
    // 使用の有無を表示
    [Header("スキャンの使用状態テキスト"),SerializeField] Text scanText;
    // 表示するオブジェクト
    [Header("SensorPオブジェクト"),SerializeField] GameObject scan;
    // パネルを表示し使えないことを示すため
    [Header("クールタイムのパネル表示"), SerializeField] Image scanImg;

    // Voltトラップのクールタイム設定
    const int scanCTTimer = 20;
    // クールタイムの計算用
    float scanTimer;

    // スキャンエフェクト
    [SerializeField] GameObject Eff;
    #endregion

    public void ScanStart()
    {
        // スキャン使用可能を表示
        scanText.text = "READY";

        // 最初は使えるので0
        scanImg.fillAmount = 0;
    }

    //バッテリー残量の管理はMainでもあるCameraManagerにて
    /// <summary>
    /// スキャン使用の処理
    /// </summary>
    public bool UseScan()
    {
        // 準備出来たかチェック
        if (scanText.text != "READY") { return false; }
        // オブジェクトを表示する
        scan.SetActive(true);
        Eff.SetActive(true);
        // 使用済
        scanText.text = "USED";
        scanImg.fillAmount = 1;

        return true;
    }

    /// <summary>
    /// クールタイム計算
    /// </summary>
    public void Recharge()
    {
        // チャージに切り替わったら計算開始
        if (scanText.text != "CHARGE" && scanImg.fillAmount == 0) { return; }
        // 時間計算
        scanTimer += Time.deltaTime;
        scanImg.fillAmount -= 1.0f / (float)scanCTTimer * Time.deltaTime;

        // 表示状態なら
        if(scan.activeSelf&&scanTimer>=2.0f)
        {
            // オブジェクトを非表示に切替
            scan.SetActive(false);
        }
        if (scanTimer >= scanCTTimer)
        {
            scanTimer = 0;
            scanText.text = "READY";
            // 一応ここで0にしておく
            scanImg.fillAmount = 0;
        }
    }

    /// <summary>
    /// チャージ出来ていてもバッテリーが足りない時に使えないことを知らせる
    /// </summary>
    public void NotCost()
    {
        scanText.text = "CHARGE";
    }

    /// <summary>
    /// コストある状態で呼び出し使えるようにする
    /// </summary>
    public void ReadySet()
    {
        if (scanImg.fillAmount != 0)
        {
            return;
        }
        scanText.text = "READY";
    }
}
