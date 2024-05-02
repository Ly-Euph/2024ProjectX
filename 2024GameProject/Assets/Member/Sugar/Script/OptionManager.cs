using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OptionManager : MonoBehaviour
{
    // UIの座標
    [SerializeField] RectTransform ImageOutLine;   // 動かすアウトライン
    [SerializeField] RectTransform[] SetPos;       // 目標のUI座標

    // 現在の音量値の表示
    [SerializeField] Text[] Text_VolNum;

    // 音量バーの表示
    [SerializeField] Image[] Master_VolImage;
    [SerializeField] Image[] BGM_VolImage;
    [SerializeField] Image[] SE_VolImage;

    // 入力情報保存
    int num=0;

    // 各音量
    int M_num;
    int B_num;
    int S_num;

    // 毎シーンでオブジェクトを探す
    SoundData Sdata;
    
    void Start()
    {
        // 音量の値を保存しているスクリプト
        Sdata = GameObject.Find("OptionData").GetComponent<SoundData>();

        // FPS60を維持するように
        Application.targetFrameRate = 60;

        // 値を受け取る
        M_num = Sdata.Para_Master;
        B_num = Sdata.Para_Bgm;
        S_num = Sdata.Para_Se;
    }

    void Update()
    {
        InputKEY();
        RectPos();
    }

    // 入力
    private void InputKEY()
    {
        // 選択
        if(Input.GetKeyDown(KeyCode.W)|| Input.GetKeyDown(KeyCode.UpArrow))
        {
            // 上の項目がない場合に一番下の項目にする
            if (num == 0) { num = SetPos.Length-1; }
            else { num--; }
        }
        else if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            // 上の項目がない場合に一番下の項目にする
            if (num == SetPos.Length-1) { num = 0; }
            else { num++; }
        }

        // 音量調整
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            
        }
    }
    
    // WidthとHeightと座標の変更
    void RectPos()
    {
        ImageOutLine.anchoredPosition = SetPos[num].anchoredPosition;
        ImageOutLine.sizeDelta = SetPos[num].sizeDelta;
    }

    // 音量調整に関する
    void Vol(int List_num)
    {
        switch (List_num)
        {
            case 0:

                break;
            case 1:

                break;
            case 2:

                break;
        }

    }
}
