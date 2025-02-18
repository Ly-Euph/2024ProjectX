using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class TutorialText : MonoBehaviour
{
    // 音再生につかう
    [SerializeField] GameManager gMng;
    // ギミック操作に使う
    [SerializeField] CameraManager cMng;
    // 表示先のテキスト
    [SerializeField] Text text;
    // 次の処理に向かう時に促すように
    [SerializeField] GameObject enterText;
    // メッセージ格納
    string message;
    // 表示速度
    [SerializeField] float delay = 0.1f;
    // スイッチ処理に使用
    [SerializeField] int num = 0;
    // messageを格納し、一文字ずつ表示する時に使う
    string stringAll_Up;

    // デリゲート
    private Func<bool> callAction;

    // タイマー
    float _timer = 3.0f;
    const float setT = 3.0f;

    // アウトラインオブジェクト
    [SerializeField] GameObject map;         // マップ
    [SerializeField] GameObject battery;     // バッテリー
    [SerializeField] GameObject light;       // センサーライト
    [SerializeField] GameObject scan;        // スキャン
    [SerializeField] GameObject volt;        // ボルト
    [SerializeField] GameObject Canvas;      // チュートリアルオブジェクト
    [SerializeField] GameObject TimeText;    // タイマーテキスト
    [SerializeField] GameObject CameraText;  // カメラ番号のテキスト
    
    // シーン移動の時のフェード
    [SerializeField] Fade fade;

    /// <summary>
    /// チュートリアルのみ操作もここで一括管理
    /// </summary>
    void Update()
    {
        //時を止めてる間はreturnし続ける。
        if (Time.timeScale == 0) return;

        switch (num)
        {
            case 0:
                // 文字削除
                text.text = "";
                // 文字セット
                message = "施設に取り残されたようだな\n"+
                    "施設内に敵の侵入が確認されている。";
                stringAll_Up = message;
                // コルーチン開始
                StartCoroutine(RevealText());
                num++;
                break;
            case 1:
                if (text.text == stringAll_Up)
                {
                    num++;
                }
                break;
            case 2:
                enterText.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    enterText.SetActive(false);
                    TimeText.SetActive(true);
                    // 文字削除
                    text.text = "";
                    message = "今救助に向かっている\n"+"この時間耐えてくれ。";
                    stringAll_Up = message;
                    // コルーチン開始
                    StartCoroutine(RevealText());
                    num++;
                }
                break;
            case 3:
                if (text.text == stringAll_Up)
                {
                    num++;
                }
                break;
            case 4:
                enterText.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    // タイマーのアウトラインオブジェクト削除
                    Destroy(TimeText);
                    enterText.SetActive(false);
                    text.text = ""; 
                    message = "施設内の設備は使えるようだな。\n"+"使い方を説明しておくぞ。";
                    stringAll_Up = message;
                    // コルーチン開始
                    StartCoroutine(RevealText());
                    num++;
                }   
                break;
            case 5:
                if (text.text == stringAll_Up)
                {
                    num++;
                }
                break;
            case 6:
                enterText.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    CameraText.SetActive(true);
                    enterText.SetActive(false);
                    text.text = ""; 
                    message = "これが現在見ているカメラだ\n" + "左上のマップの番号と数字が連動している。";
                    stringAll_Up = message;
                    // コルーチン開始
                    StartCoroutine(RevealText());
                    num++;
                }
                break;
            case 7:
                if (text.text == stringAll_Up)
                {
                    num++;
                }
                break;
            case 8:
                enterText.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    // カメラテキストのオブジェクト削除
                    Destroy(CameraText);
                    map.SetActive(true);
                    enterText.SetActive(false);
                    text.text = "";
                    message = "その上にあるのが施設内のマップだ。\n"+"人型マークは君のいるエリアだ。";
                    stringAll_Up = message;
                    // コルーチン開始
                    StartCoroutine(RevealText());
                    num++;
                }
                break;
            case 9:
                if (text.text == stringAll_Up)
                {
                    num++;
                }
                break;
            case 10:
                enterText.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    // マップのアウトラインオブジェクト削除
                    Destroy(map);
                    enterText.SetActive(false);
                    text.text = "";
                    message = "ＡとＤキーでカメラを操作できる。\n"+
                              "試してみてくれ。";
                    stringAll_Up = message;
                    // コルーチン開始
                    StartCoroutine(RevealText());
                    num++;
                }
                break;
            case 11:
                if (text.text == stringAll_Up)
                {
                    num++;
                }
                break;
            case 12:
                _timer -= Time.deltaTime;
                if (_timer <= 0)
                {
                    _timer -= Time.deltaTime;
                    text.text = "";
                    message = "次に侵入者から身を守る為に使う\n"+
                        "機能を説明する。";
                    stringAll_Up = message;
                    // コルーチン開始
                    StartCoroutine(RevealText());
                    num++;
                }
                break;
            case 13:
                if (text.text == stringAll_Up)
                {
                    num++;
                }
                break;
            case 14:
                enterText.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    enterText.SetActive(false);
                    text.text = "";
                    message = "まずはスキャンだ。\n" +
                        "これで敵の場所を特定できる。";
                    stringAll_Up = message;
                    // コルーチン開始
                    StartCoroutine(RevealText());
                    num++;
                }
                break;
            case 15:
                if (text.text == stringAll_Up)
                {
                    num++;
                }
                break;
            case 16:
                enterText.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    enterText.SetActive(false);
                    text.text = "";
                    message = "使用するにはバッテリーを消費する。\n" +
                        "そして再利用にはリチャージが必要だ。";
                    stringAll_Up = message;
                    // コルーチン開始
                    StartCoroutine(RevealText());
                    num++;
                }
                break;
            case 17:
                if (text.text == stringAll_Up)
                {
                    num++;
                }
                break;
            case 18:
                enterText.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    enterText.SetActive(false);
                    text.text = "";
                    battery.SetActive(true);
                    message = "これがバッテリー量だ。\n"+
                        "バッテリーは時間で回復していく。";
                    stringAll_Up = message;
                    // コルーチン開始
                    StartCoroutine(RevealText());
                    num++;
                }

                break;
            case 19:
                if (text.text == stringAll_Up)
                {
                    num++;
                }
                break;
            case 20:
                enterText.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    // 関数登録
                    callAction = cMng.Tutorial_Scan;
                    // バッテリーアウトラインオブジェクト削除
                    Destroy(battery);
                    scan.SetActive(true);
                    enterText.SetActive(false);
                    text.text = "";
                    message = "それではスキャンを試してくれ。";
                    stringAll_Up = message;
                    // コルーチン開始
                    StartCoroutine(RevealText());
                    num++;
                }
                break;
            case 21:
                if (text.text == stringAll_Up)
                {
                    num++;
                }
                break;
            case 22:
                if (callAction != null&&callAction.Invoke())
                {
                    // スキャンのアウトラインオブジェクト削除
                    Destroy(scan);
                    text.text = "";
                    message = "マップをみてくれ、赤く点滅している場所が\n"+
                        "敵の侵入しているエリアだ。";
                    stringAll_Up = message;
                    // コルーチン開始
                    StartCoroutine(RevealText());
                    // 関数解除
                    callAction = null;
                    num++;
                }
                break;
            case 23:
                if (text.text == stringAll_Up)
                {
                    num++;
                }
                break;
            case 24:
                enterText.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    enterText.SetActive(false);
                    text.text = "";
                    message = "カメラを切り替えるぞ。";
                    stringAll_Up = message;
                    // コルーチン開始
                    StartCoroutine(RevealText());
                    num++;
                }
                break;
            case 25:
                if (text.text == stringAll_Up)
                {
                    num++;
                }
                break;
            case 26:
                enterText.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    // 関数登録
                    callAction = cMng.Tutorial_CamChan;
                    enterText.SetActive(false);
                    text.text = "";
                    message = "今回は数字キーの2だな。\n"+
                        "もしくはEキーでもいいぞ";
                    stringAll_Up = message;
                    // コルーチン開始
                    StartCoroutine(RevealText());
                    num++;
                }
                break;
            case 27:
                if (text.text == stringAll_Up)
                {
                    num++;
                }
                break;
            case 28:
                if (callAction != null && callAction.Invoke())
                {
                    text.text = "";
                    message = "…見当たらないな\n"
                              + "センサーライトをつけてみるか。";
                    stringAll_Up = message;
                    // コルーチン開始
                    StartCoroutine(RevealText());
                    // 関数解除
                    callAction = null;
                    num++;
                }
                break;
            case 29:
                if (text.text == stringAll_Up)
                {
                    num++;
                }
                break;
            case 30:
                enterText.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    enterText.SetActive(false);
                    text.text = "";
                    message = "つけている間はバッテリーが\n" +
                        "回復しないから要注意だ。";
                    stringAll_Up = message;
                    // コルーチン開始
                    StartCoroutine(RevealText());
                    num++;
                }
                break;
            case 31:
                if (text.text == stringAll_Up)
                {
                    num++;
                }
                break;
            case 32:
                enterText.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    // 関数登録
                    callAction = cMng.Tutorial_Light;
                    enterText.SetActive(false);
                    light.SetActive(true);
                    text.text = "";
                    message = "それではつけてみてくれ。\n"+
                        "ステルス状態の敵が見つけられるはずだ。";
                    stringAll_Up = message;
                    // コルーチン開始
                    StartCoroutine(RevealText());
                    num++;
                }
                break;
            case 33:
                if (text.text == stringAll_Up)
                {
                    num++;
                }
                break;
            case 34:
                if (callAction != null && callAction.Invoke())
                {
                    // ライトのアウトラインオブジェクト削除
                    Destroy(light);
                    text.text = "";
                    message = "いたな。撃退するぞ。";
                    stringAll_Up = message;
                    // コルーチン開始
                    StartCoroutine(RevealText());
                    // 関数解除
                    callAction = null;
                    num++;
                }
                break;
            case 35:
                if (text.text == stringAll_Up)
                {
                    num++;
                }
                break;
            case 36:
                enterText.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    callAction = cMng.Tutorial_Volt;
                    volt.SetActive(true);
                    enterText.SetActive(false);
                    text.text = "";
                    message = "これを使うんだ。";
                    stringAll_Up = message;
                    // コルーチン開始
                    StartCoroutine(RevealText());
                    num++;
                }
                break;
            case 37:
                if (text.text == stringAll_Up)
                {
                    num++;
                }
                break;
            case 38:
                if (callAction != null && callAction.Invoke())
                {
                    // ボルトのアウトラインオブジェクト削除
                    Destroy(volt);
                    text.text = "";
                    message = "ひとまず、大丈夫そうだな。\n"+
                        "では、健闘を祈る。";
                    stringAll_Up = message;
                    // コルーチン開始
                    StartCoroutine(RevealText());
                    // 関数解除
                    callAction = null;
                    num++;
                }
                break;
            case 39:
                if (text.text == stringAll_Up)
                {
                    num++;
                    _timer = setT;
                }
                break;
            case 40:
                _timer -= Time.deltaTime;
                if(_timer<=0)
                {
                    num++;
                }
                break;
            case 41:
                fade.FadeIn(1.0f, () => SceneManager.LoadScene("SSS"));
                num++;
                break;
        }

    }

    /// <summary>
    /// 一文字ずつ表示させる処理
    /// </summary>
    /// <returns></returns>
    IEnumerator RevealText()
    {
        // 一文字ずつ表示
        foreach (char c in stringAll_Up)
        {
            text.text += c;
            gMng.OneShotSE_U(SEData.Type.ETC, GameManager.UISe.textmsg);
            yield return new WaitForSecondsRealtime(delay); // 指定時間待機
        }
    }
}
