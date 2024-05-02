using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundData : MonoBehaviour
{
    int S_MASTER = 10;
    int S_BGM = 10;
    int S_SE = 10;

    // シーン切り替えても破棄
    // されないようにする
    public static SoundData instance;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        CheckInstance();
    }
    void CheckInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // 値の保存
    // Master
    // サウンド調整
    public int Para_Master
    {
        set
        {
            AudioListener.volume = value;
            S_MASTER = value;
        }
        get
        {
            return S_MASTER;
        }
    }
    // SE
    // サウンド調整
    public int Para_Se
    {
        set
        {
            //  aud[0].volume = value;
            S_SE = value;
        }
        get
        {
            return S_SE;
        }
    }

    // BGM
    // サウンド調整
    public int Para_Bgm
    {
        set
        {
            // aud[1].volume = value;
            S_BGM = value;
        }
        get
        {
            return S_BGM;
        }
    }
}
