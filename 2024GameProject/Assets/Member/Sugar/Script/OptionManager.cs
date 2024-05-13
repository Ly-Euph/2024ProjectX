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
    [SerializeField] GameObject[] Master_VolImage;
    [SerializeField] GameObject[] BGM_VolImage;
    [SerializeField] GameObject[] SE_VolImage;

    // 再生コンポーネントの値
    [SerializeField] AudioSource B_Audio;
    [SerializeField] AudioSource S_Audio;

    int MaxVol = 10;
    int MinVol = 0;

    // 入力情報保存
    int num=0;

    // 各音量
    int M_num;
    int B_num;
    int S_num;

    // 毎シーンでオブジェクトを探す
    SoundData Sdata;

    private void OnEnable()
    {
        if (Sdata == null) { return; }

        // 値を受け取る
        M_num = Sdata.Para_Master;
        B_num = Sdata.Para_Bgm;
        S_num = Sdata.Para_Se;

        // カーソル位置
        num = 0;

        // 値を元に色々セット
        setVol();
    }
    void Start()
    {
        this.gameObject.GetComponent<Canvas>().enabled = false;
        // 音量の値を保存しているスクリプト
        Sdata = GameObject.Find("OptionData").GetComponent<SoundData>();

        // 値を受け取る
        M_num = Sdata.Para_Master;
        B_num = Sdata.Para_Bgm;
        S_num = Sdata.Para_Se;

        setVol();

        // 毎シーン最初に初期化するため
        // 変更後に一回表示をけす
        this.gameObject.GetComponent<Canvas>().enabled = true;
        this.gameObject.SetActive(false);
    }

    void Update()
    {
        if(this.gameObject.GetComponent<Canvas>().enabled == false) { return; }

        InputKEY();
        RectPos();
    }
    
    private void setVol()
    {
        // コンポーネントの値変更
        Vol_Audio();
        // テキストとバー変更
        Vol_Text();
        Vol_Bar();
    }

    // 入力
    private void InputKEY()
    {
        // 閉じる
       // if (Input.GetKeyDown(KeyCode.Escape)) { this.gameObject.SetActive(false); }

        // 選択
        if (Input.GetKeyDown(KeyCode.W)|| Input.GetKeyDown(KeyCode.UpArrow))
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
            Vol(num,"A");
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            Vol(num,"D");
        }

        // 決定
        if (Input.GetKeyDown(KeyCode.Return) && num== SetPos.Length - 1)
        {
            // 最後に値を保存させる
            Sdata.Para_Master = M_num;
            Sdata.Para_Bgm = B_num;
            Sdata.Para_Se = S_num;

            this.gameObject.SetActive(false);
        }
    }
    
    // WidthとHeightと座標の変更
    void RectPos()
    {
        ImageOutLine.anchoredPosition = SetPos[num].anchoredPosition;
        ImageOutLine.sizeDelta = SetPos[num].sizeDelta;
    }

    // 音量調整の値の変更
    void Vol(int List_num,string mark)
    {
        // mark変数はAorDで値を増加するのか減少させるかの判別
        if (mark == "A")
        {
            switch (List_num)
            {
                case 0:
                    if (M_num == MinVol) { return; }
                    else {
                        --M_num;
                        
                    }
                    break;
                case 1:
                    if (B_num == MinVol) { return; }
                    else { 
                        --B_num; 
                    }
                    break;
                case 2:
                    if (S_num == MinVol) { return; }
                    else { 
                        --S_num;
                    }
                    break;
            }
        }
        else if (mark == "D")
        {
            switch (List_num)
            {
                case 0:
                    if (M_num == MaxVol) { return; }
                    else { ++M_num; }
                    break;
                case 1:
                    if (B_num == MaxVol) { return; }
                    else { ++B_num; }
                    break;
                case 2:
                    if (S_num == MaxVol) { return; }
                    else { ++S_num; }
                    break;
            }
        }
        // テキストとバー変更
        setVol();
    }

    private void Vol_Text()
    {
        Text_VolNum[0].text = M_num.ToString();
        Text_VolNum[1].text = B_num.ToString();
        Text_VolNum[2].text = S_num.ToString();
    }

    private void Vol_Bar()
    {
        // 一旦全ての非表示に
        for (int i = 0; i <= MaxVol; i++)
        {
            if (i > 0)
            {
                Master_VolImage[i - 1].SetActive(false);
                BGM_VolImage[i - 1].SetActive(false);
                SE_VolImage[i - 1].SetActive(false);
            }
        }

        // マスターボリュームのバー変更
        for (int i=0;i<=M_num;i++)
        {
            if (i > 0) {
                Master_VolImage[i-1].SetActive(true);
            }       
        }
        // BGMボリュームのバー変更
        for (int i = 0; i <= B_num; i++)
        {
            if (i > 0)
            {
                BGM_VolImage[i - 1].SetActive(true);
            }
        }
        // SEボリュームのバー変更
        for (int i = 0; i <= S_num; i++)
        {
            if (i > 0)
            {
                SE_VolImage[i - 1].SetActive(true);
            }
        }
    }

    private void Vol_Audio()
    {
        // マスターボリューム
        AudioListener.volume = M_num*0.1f;
        // BGM
        B_Audio.volume = B_num*0.1f;
        // SE
        S_Audio.volume = S_num*0.1f;
    }
}
