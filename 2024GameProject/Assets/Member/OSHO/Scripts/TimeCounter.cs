using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeCounter : MonoBehaviour
{
    [Header("ここで時間制限の操作を行ってね。")]

    [SerializeField] int TimeMinute = 15;

    private float TimeSecond;
    private bool TimeLimit = false;
    private Text TimeText;

    // シーン遷移に使う
    [SerializeField] Fade fade;



    // Start is called before the first frame update
    void Start()
    {
        TimeText = GetComponent<Text>();
        TimeSecond = TimeMinute * 60;
    }

    // Update is called once per frame
    void Update()
    {
        if (!TimeLimit)
        {
            //timeScaleでゲーム内時間を弄りました。

            TimeSecond -= Time.deltaTime;
            
            //TimeSpanとmm\:ssで時間制限を簡単に制御できるように。
            //変数TimeSecondの値を参照。

            var span = new TimeSpan(0, 0, (int)TimeSecond);　
            TimeText.text = span.ToString(@"mm\:ss");
        }
        if (TimeSecond < 0&&!TimeLimit)
        {
            Debug.Log("クリア！！");
            TimeLimit = true;

            //シーン移行の処理
            fade.FadeIn(0.5f, () => SceneManager.LoadScene("ClearScene"));
            //現状はクリアしたステージはClearSceneに移行する予定です。
        }
    }
}
