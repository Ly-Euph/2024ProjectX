using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Volt : MonoBehaviour
{
    #region field
    // ボルトトラップ使用後再利用まで
    // パネルを表示し使えないことを示すため
    [Header("クールタイムのパネル表示"),SerializeField] Image voltImg;
    // 使ったかどうかの状態
    [Header("Voltの使用状態表示テキスト"),SerializeField] Text voltText;

    // transform取得用
    [Header("発動する位置指定するオブジェクト"), SerializeField] GameObject[] objPos;
    // volt生成オブジェクト
    [Header("生成するvoltのオブジェクト"), SerializeField] GameObject voltObj;

    // Voltトラップのクールタイム設定
    const int voltCTTimer = 7;
    // クールタイムの計算用
    float voltTimer ;
    #endregion

    public void VoltStart()
    {
        // ボルトトラップ使用可能を表示
        voltText.text = "READY";

        // 最初は使えるので0
        voltImg.fillAmount = 0;
    }

    //バッテリー残量の管理はMainでもあるCameraManagerにて
    /// <summary>
    /// ボルト使用の処理
    /// </summary>
    /// <param name="num">どのカメラかCameraManagerのcamaeraNumを送って</param>
    public bool UseVolt(int num)
    {
        // 準備出来たかチェック
        if (voltText.text != "READY") { return false; }
        // -1にして配列の0番目から使えるように
        // ポジションの設定
        Vector3 ObjPos = objPos[num-1].transform.position;
        // 生成
        Instantiate(voltObj, ObjPos, Quaternion.identity);
        // 使用済
        voltText.text = "CHARGE";
        voltImg.fillAmount = 1;

        return true;
    }

    /// <summary>
    /// クールタイム計算
    /// </summary>
    public void Recharge()
    {
        // チャージに切り替わったら計算開始
        if (voltText.text != "CHARGE"&&voltImg.fillAmount==0) { return; }
        // 時間計算
        voltTimer += Time.deltaTime;
        voltImg.fillAmount -= 1.0f / (float)voltCTTimer*Time.deltaTime;
        if (voltTimer>=voltCTTimer)
        {
            voltTimer = 0;
            voltText.text = "READY";
            // 一応ここで0にしておく
            voltImg.fillAmount = 0;
        }
    }

    /// <summary>
    /// チャージ出来ていてもバッテリーが足りない時に使えないことを知らせる
    /// </summary>
    /// <param name="cost">このギミックの使用コスト</param>
    /// <param name="battery">バッテリーの残量</param>
    public void NowCost(int cost,float battery)
    {
        if(cost>=battery)
        {
            voltText.text = "CHARGE";
        }
        else
        {
            voltText.text = "READY";
        }
    }
}
