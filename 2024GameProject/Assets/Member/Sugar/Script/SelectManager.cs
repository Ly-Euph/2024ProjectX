using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectManager : MonoBehaviour
{
    [SerializeField] StageDataBase SDB;
    [SerializeField] Text StageNameText;
    [SerializeField] Text Info;
    [SerializeField] Fade fade;                // FadeCanvas

    // 0(Left) 1(Center) 2(Right)
    [SerializeField] Image[] StageImage;

    // 効果音再生
    [SerializeField] GameManager gMng;

    // 選択番号
    public int Lnum,Cnum,Rnum; 

    // 最大値と最小値
    int Max;
    int Min = 0;
    int point = 1;
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
        SDB_Set();
    }
    void InputKEY()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            gMng.OneShotSE_U(SEData.Type.ETC, GameManager.UISe.wasd);
            if (Cnum == 0) { Cnum = Max; }
            else { Cnum -= point; }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            gMng.OneShotSE_U(SEData.Type.ETC, GameManager.UISe.wasd);
            if (Cnum == Max) { Cnum = Min; }
            else { Cnum += point; }
        }
        if(Input.GetKeyDown(KeyCode.Return))
        {
            gMng.OneShotSE_U(SEData.Type.ETC, GameManager.UISe.enter);
            fade.FadeIn(0.5f, () => SceneManager.LoadScene(SDB.STAGE_DATA[Cnum].StageSceneName));
        }
    }
    void SDB_Set()
    {
        // 省略用
        var IxSDB = SDB.STAGE_DATA;

        // Centerの値から左右を求める
        Lnum = Cnum-point;
        Rnum = Cnum+point;
        
        // 真ん中のイメージに画像を差し込むときにリストの外にならないように
        if (Cnum == Min) { Lnum = Max; }
        if (Cnum == Max) { Rnum = Min; }

        // データベースを元に表示
        StageImage[0].sprite= IxSDB[Lnum].StageImage;
        StageImage[1].sprite= IxSDB[Cnum].StageImage;
        StageImage[2].sprite= IxSDB[Rnum].StageImage;

        StageNameText.text = IxSDB[Cnum].StageName;

        Info.text = IxSDB[Cnum].infomation_Level + "\n"
            + IxSDB[Cnum].infomation_Cam;
    }
}
