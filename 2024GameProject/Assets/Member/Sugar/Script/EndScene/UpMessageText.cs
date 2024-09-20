using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // UIを使うように
using System; //DateTimeを使用する為追加。
using UnityEngine.SceneManagement;

public class UpMessageText : MonoBehaviour
{
    #region 
    // 反映させるオブジェクト
    [SerializeField] Text UpText;

    // 一文字ごとの表示にかかる時間
    [SerializeField] float delay = 0.3f;

    // シーン遷移に使う
    [SerializeField] Fade fade;

    //DateTimeを使うため変数を設定
    DateTime TodayNow;

    // 音再生につかう
    [SerializeField] GameManager gMng;

    // 時間と分数の取得用
    float hour;
    float minute;

    // 日付の取得用
    int month;
    int day;
    int year;

    // スイッチ処理
    int num = 0;
    
    // 分数が一桁の時に先頭に0を入れる
    string minuteString;
    // 日付でも同じように
    string monthString;
    string dayString;

    [SerializeField]string message = "You've survived!";

    string stringAll_Up;   // 一行目のテキストまとめ

    // ゲームオーバーシーンのみでつかう
    [SerializeField] bool IsGameOver = false;
    [SerializeField] MeshRenderer[] EffObj;

    float addPoint=0.1f;
    float effPoint = 0;
    #endregion
   
    #region Method
    // 日付表示
    void SetDate()
    {
        month = TodayNow.Month;

        day = TodayNow.Day;

        year = TodayNow.Year;

        // 月が一桁の場合先頭に0を追加
        if (month <= 9)
        {
            monthString = "0" + month.ToString();
        }
        else
        {
            monthString = month.ToString();
        }

        // 日が一桁の場合先頭に0を追加
        if (day <= 9)
        {
            dayString = "0" + day.ToString();
        }
        else
        {
            dayString = day.ToString();
        }

        // まとめて入れておく
        stringAll_Up += monthString + "／" + dayString+"／"+year.ToString();
        // 改行文字
        stringAll_Up += "\n";
    }

    // 時刻表示
    //void SetTime()
    //{
    //    // 時間を取得
    //    hour = TodayNow.Hour;
    //    minute = TodayNow.Minute;

    //    // 分数が一桁の場合先頭に0を追加
    //    if (minute <= 9)
    //    {
    //        minuteString = "0" + minute.ToString();
    //    }
    //    else
    //    {
    //        minuteString = minute.ToString();
    //    }

    //    // まとめて入れておく
    //    stringAll_Up += "　"+ hour + " : " + minuteString;
    //}

    // メッセージを追加
    void SetMessage()
    {
        stringAll_Up +=message.ToString();
    }

    IEnumerator RevealText()
    {
        // 一文字ずつ表示
        foreach (char c in stringAll_Up)
        {
            UpText.text += c;
            gMng.OneShotSE_U(SEData.Type.ETC,GameManager.UISe.textmsg);
            yield return new WaitForSecondsRealtime(delay); // 指定時間待機
        }
    }
    #endregion
    void Start()
    {
        // 文字削除
        UpText.text = "";

        //時間を取得
        TodayNow = DateTime.Now;

        SetDate();
        SetMessage();
        //SetTime();
    }
    private void Update()
    {
        switch(num)
        {

            case 0:
                // コルーチン開始
                StartCoroutine(RevealText());
                num++;
                break;
            case 1:
                if (UpText.text == stringAll_Up)
                {
                    num++;
                }
                break;
            case 2:
                if (!IsGameOver)
                {
                    fade.FadeIn(0.5f, () => SceneManager.LoadScene("TitleScene"));
                    num = 999; // 範囲外にする
                }
                else
                {
                    num++;
                }
                break;
            case 3:
                effPoint += addPoint;
                EffObj[0].material.SetFloat("_Progress", effPoint);
                EffObj[1].material.SetFloat("_Progress", effPoint);
                if(effPoint>=1.0f)
                {
                    num++;
                }
                break;
            case 4:
                EffObj[0].material.SetFloat("_Progress", 1);
                EffObj[1].material.SetFloat("_Progress", 1);
                effPoint -= addPoint;
                if (effPoint <= 0.0f)
                {
                    fade.FadeIn(0.5f, () => SceneManager.LoadScene("TitleScene"));
                    num = 999; // 範囲外にする
                }
                break;

        }
    }

   
}
