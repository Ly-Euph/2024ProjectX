using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // UIを使うように
using System; //DateTimeを使用する為追加。

public class DateTimeText : MonoBehaviour
{
    #region 
    // 反映させるオブジェクト
    [SerializeField] Text text;

    //DateTimeを使うため変数を設定
    DateTime TodayNow;

    float hour;
    float minute;

    string minuteString;
    #endregion
    void Start()
    {

     

    }

    // 日付表示
    void SetDate()
    {

    }

    // 時刻表示
    void SetTime()
    {
        //時間を取得
        TodayNow = DateTime.Now;

        // 時間を取得
        hour = TodayNow.Hour;
        minute = TodayNow.Minute;

        // 分数が一桁の場合0を入れる
        if (minute <= 9)
        {
            minuteString = "0" + minute.ToString();
        }
        else
        {
            minuteString = minute.ToString();
        }

        //テキストUIに反映表示
        text.text = hour + "：" + minuteString.ToString();
    }
}
