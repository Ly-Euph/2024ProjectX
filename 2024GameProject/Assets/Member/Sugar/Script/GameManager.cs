using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 特定のオブジェクトが表示されたら時間停止
    [SerializeField] GameObject[] Target;
    [SerializeField] bool B_Title=false;

    [SerializeField] AudioSource[] aud;


    int width = 1920;
    int height = 1080;
    void Start()
    {
        // FPS60を維持するように
        Application.targetFrameRate = 60;

        // カーソル非表示
        Cursor.visible = false;

        // 画面解像度固定
        Screen.SetResolution(width, height, FullScreenMode.FullScreenWindow, 60);

    }

    void Update()
    {
        timeManager();
        InputKEY();
    }
    void timeManager()
    {
        if (Target[0].activeSelf == true || Target[1].activeSelf == true) { Time.timeScale = 0; }
        else if (Target[0].activeSelf == false || Target[1].activeSelf == false) { Time.timeScale = 1; }

    }
    void InputKEY()
    {
        if (B_Title) { return; }
        if (Input.GetKeyDown(KeyCode.Escape)&&!Target[1].activeSelf) {
            if (Target[0].activeSelf == false) 
            {
                Target[0].SetActive(true);
                OneShotSE_U(SEData.Type.ETC, UISe.esc);
            }
            else { Target[0].SetActive(false); }
        }
    }

    // 仮で必要になりそうなものを準備。
    // 追加で必要ならここに用意　

    // オブジェクトとかいろいろ
    public enum ClipSe
    {
       stage,
    }
    // キャラクター関連の音
    public enum HUMANClipSe
    {
        Move1,
        Move2,
        Jump1,
        Jump2,
        Atk1,
        Atk2,
        Hit1,
        Hit2,
        Skill1,
        Skill2,
        Death,
        num,
    }
    // UI関連の音はこっち
    public enum UISe
    {
        wasd,    // UIの移動音
        enter,   // 決定音
        esc,     // UIウィンドウ
        textmsg, // テキスト送り音
        tab,     // 戻る音（キャンセル音）
        Eff1,    // エフェクト
        Eff2,
        Eff3,
        Eff4,
        Eff5,
        num,
    }

    [SerializeField] SEDataBase dataBase;

    /// <summary>
    /// Mng_Sound.ClipSe.xxxで必要なSEを再生
    /// </summary>
    /// <param name="clipse"></param>
    public void OneShotSE_C(SEData.Type type, ClipSe se)
    {
        if (type == SEData.Type.OBJ)
        {
            aud[1].PlayOneShot(dataBase.SEDATA[(int)SEData.Type.OBJ].SE[(int)se]);
        }
        else if (type == SEData.Type.HUMAN)
        {
            aud[0].PlayOneShot(dataBase.SEDATA[(int)SEData.Type.HUMAN].SE[(int)se]);
        }
    }
    public void OneShotSE_U(SEData.Type type, UISe se)
    {
        aud[0].PlayOneShot(dataBase.SEDATA[(int)SEData.Type.ETC].SE[(int)se]);
    }

    public void StopSE()
    {
        aud[0].Stop();
    }
}
