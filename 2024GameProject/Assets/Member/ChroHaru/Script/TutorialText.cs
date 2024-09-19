using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TutorialText : MonoBehaviour
{
    
    // 音再生につかう
    [SerializeField] GameManager gMng;
    [SerializeField] Text text;
    [SerializeField] string message;
    [SerializeField] float delay = 0.3f;
    int num = 0;
    string stringAll_Up;
    [SerializeField] GameObject Img1;
    [SerializeField] GameObject Img2;
    [SerializeField] GameObject Img3;
    [SerializeField] GameObject Img4;
    [SerializeField] GameObject Img5;
    [SerializeField] GameObject Canvas;
    [SerializeField] GameObject enterText;
    [SerializeField] GameObject TimeText;
    [SerializeField] GameObject CameraText;

    TimeScaleM timescaleM;
    GameObject obj;
    private void Start()
    {
        obj = GameObject.Find("TimeScale");//タイムスケールを管理するスクリプトの変数を取得
        timescaleM = obj.GetComponent<TimeScaleM>();
        timescaleM.timescale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        switch (num)
        {
            case 0:
                // 文字削除
                text.text = "";
                // 文字セット
                message = "施設内に侵入者が確認された";
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
                    // 文字削除
                    text.text = "";
                    message = "助けが来るまで侵入者を管理室に \n" +
                         "侵入させないでくれ";
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
                    enterText.SetActive(false);
                    text.text = "";
                    message = "これは施設の地図だ\n" +
                         "これを見れば敵の侵入経路を\n" +
                         "予測しやすくなる";
                    stringAll_Up = message;

                    Img1.SetActive(true);
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
                    enterText.SetActive(false);
                    Img1.SetActive(false);
                    text.text = "";
                    message = "そしてこれが施設の残りのバッテリー量だ\n" +
                        "これは施設の設備を使うと消費されていくが\n" +
                        "一定時間経過すると残量が回復するぞ";
                    stringAll_Up = message;
                    Img2.SetActive(true);
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
                    enterText.SetActive(false);
                    Img2.SetActive(false);
                    text.text = "";
                    message = "そしてこれは助けが来るまでの時間だ\n" +
                         "この時間耐えてくれ";
                    stringAll_Up = message;

                    TimeText.SetActive(true);
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
                    enterText.SetActive(false);
                    TimeText.SetActive(false);
                    text.text = "";
                    message = "これは今見ているカメラの番号だ\n"+
                        "数字キーでカメラを切り替えて\n"+
                        "他のカメラを見ることができる";
                    stringAll_Up = message;

                    CameraText.SetActive(true);
                    // コルーチン開始
                    StartCoroutine(RevealText());
                    num++;
                }

                break;
            case 11:
                enterText.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    enterText.SetActive(false);
                    CameraText.SetActive(false);
                    text.text = "";
                    message = "次に施設にある設備の説明だ\n"+
                        "１つ目の設備はソナーだ\n"+
                        "見えない敵がいるかスキャンできるぞ";
                    stringAll_Up = message;
                    Img3.SetActive(true);
                    // コルーチン開始
                    StartCoroutine(RevealText());
                    num++;
                }

                break;
            case 12:

                if (text.text == stringAll_Up)
                {
                    num++;
                }
                break;
            case 13:
                enterText.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    enterText.SetActive(false);
                    Img3.SetActive(false);
                    text.text = "";
                    message ="2つ目の設備はスキャンだ\n" +
                        "監視していないエリアに敵がいるか\n"+
                        "スキャンができる";
                    stringAll_Up = message;
                    Img4.SetActive(true);
                    // コルーチン開始
                    StartCoroutine(RevealText());
                    num++;
                }

                break;
            case 14:

                if (text.text == stringAll_Up)
                {
                    num++;
                }
                break;
            case 15:
                enterText.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    enterText.SetActive(false);
                    Img4.SetActive(false);
                    text.text = "";
                    message = "3つ目の設備は電気ショックだ\n" +
                        "使用することで敵を排除することができる";
                    stringAll_Up = message;
                    Img5.SetActive(true);
                    // コルーチン開始
                    StartCoroutine(RevealText());
                    num++;
                }

                break;
            case 16:

                if (text.text == stringAll_Up)
                {
                    num++;
                }
                break;
            case 17:
                enterText.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    enterText.SetActive(false);
                    Img5.SetActive(false);
                    text.text = "";
                    message = "では健闘を祈る";
                    stringAll_Up = message;
                    // コルーチン開始
                    StartCoroutine(RevealText());
                    num++;
                }

                break;
            case 18:

                if (text.text == stringAll_Up)
                {
                    num++;
                }
                break;
            case 19:
                enterText.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    timescaleM.timescale= 1;//
                    enterText.SetActive(false);
                    Canvas.SetActive(false);
                }
                break;
        }

    }
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
