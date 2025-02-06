using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectManager : MonoBehaviour
{
    // 選択できるRectの参照元
    [SerializeField] RectTransform[] RectPos; 
    // 選択アウトラインの移動
    [SerializeField] RectTransform Rct;
    // データベース
    [SerializeField] StageDataBase SDB;
    // ステージの名前表示
    [SerializeField] Text StageNameText;
    // 難易度とかの記載用
    [SerializeField] Text Info;
    // ステージ遷移に使う
    [SerializeField] Fade fade;                // FadeCanvas
    // ステージのサムネ画像
    [SerializeField] Image StageImage;
    // 効果音再生
    [SerializeField] GameManager gMng;
    // 参照元の座標保存用
    Vector3 pos;
    // 選択番号
    public int Lnum,Cnum,Rnum;
    int UDnum; // 上下
    int LRnum; // 左右
    // 最大値と最小値
    int Max;
    int Min = 0;
    int UDMax = 1;
    // 増減値
    const int point = 1;
    // height
    const int height= 200;
    void Start()
    {
        // 要素数ー１の値を求める
        Max = SDB.STAGE_DATA.Count-point; // 要素数を最大値とする
        Cnum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0) { return; }
        InputKEY();
        //RectPosChange();
        SDB_Set();
    }
    void InputKEY()
    {
        var INPUT_A = Input.GetKeyDown(KeyCode.A)||
            Input.GetKeyDown(KeyCode.LeftArrow);
        var INPUT_D = Input.GetKeyDown(KeyCode.D)||
            Input.GetKeyDown(KeyCode.RightArrow);
        var INPUT_W = Input.GetKeyDown(KeyCode.W)||
            Input.GetKeyDown(KeyCode.UpArrow);
        var INPUT_S = Input.GetKeyDown(KeyCode.S)||
            Input.GetKeyDown(KeyCode.DownArrow);
        // ステージの名前を選択中に左右キーで変更できる
        if (UDnum == 0)
        {
            if (INPUT_A)
            {
                // SE再生
                gMng.OneShotSE_U(SEData.Type.ETC, GameManager.UISe.wasd);
                if (LRnum == 0) { LRnum = Max; }
                else { LRnum -= point; }
            }
            if (INPUT_D)
            {
                gMng.OneShotSE_U(SEData.Type.ETC, GameManager.UISe.wasd);
                if (LRnum == Max) { LRnum = Min; }
                else { LRnum += point; }
            }
        }
        //if(INPUT_W)
        //{
        //    gMng.OneShotSE_U(SEData.Type.ETC, GameManager.UISe.wasd);
        //    if (UDnum == Min) { UDnum = UDMax; }
        //    else { UDnum -= point; }
        //}
        //if (INPUT_S)
        //{
        //    gMng.OneShotSE_U(SEData.Type.ETC, GameManager.UISe.wasd);
        //    if (UDnum == UDMax) { UDnum = Min; }
        //    else { UDnum += point; }
        //}

        // ゲーム開始のボタンとアウトラインが重なってから押したら始められる
        if (Input.GetKeyDown(KeyCode.Return)&&UDnum==1)
        {
            gMng.OneShotSE_U(SEData.Type.ETC, GameManager.UISe.enter);
            fade.FadeIn(0.5f, () => SceneManager.LoadScene(SDB.STAGE_DATA[LRnum].StageSceneName));
        }
    }
    void SDB_Set()
    {
        // 省略用
        var IxSDB = SDB.STAGE_DATA;

        // Centerの値から左右を求める
        Lnum = LRnum-point;
        Rnum = LRnum+point;
        
        // 真ん中のイメージに画像を差し込むときにリストの外にならないように
        if (LRnum == Min) { Lnum = Max; }
        if (LRnum == Max) { Rnum = Min; }

        // データベースを元に表示
        // ここはイメージ
        StageImage.sprite= IxSDB[LRnum].StageImage;
        // ステージの名前
        StageNameText.text = IxSDB[LRnum].StageName;
        // 難易度とカメラ数
        Info.text = IxSDB[LRnum].infomation_Level + "\n"
            + IxSDB[LRnum].infomation_Cam;
    }
    void RectPosChange()
    {
        pos = RectPos[UDnum].anchoredPosition;
        Rct.sizeDelta = new Vector2(RectPos[UDnum].sizeDelta.x,height);
        Rct.anchoredPosition =pos;
    }
}
