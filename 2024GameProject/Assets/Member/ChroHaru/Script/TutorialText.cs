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
                // 文字削除
                text.text = "";
                message = "助けが来るまで侵入者を管理室に \n"+
                          "侵入させないでくれ";
                stringAll_Up = message;
                // コルーチン開始
                StartCoroutine(RevealText());
                num++;
                break;
            case 3:
                if (text.text == stringAll_Up)
                {
                    num++;
                }
                break;

            case 4:
                // 文字削除
                text.text = "";
                message = "これは施設の地図だ\n"+
                          "これを見れば敵の侵入経路を\n"+
                          "予測しやすくなる";
                stringAll_Up = message;
                // コルーチン開始
                StartCoroutine(RevealText());
                num++;
                break;
            case 5:
                if (text.text == stringAll_Up)
                {
                    num++;
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
