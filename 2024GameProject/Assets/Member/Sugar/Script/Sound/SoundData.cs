using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundData : MonoBehaviour
{
    int S_MASTER = 6;
    int S_BGM = 5;
    int S_SE = 3;

    // �V�[���؂�ւ��Ă��j��
    // ����Ȃ��悤�ɂ���
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
    // �l�̕ۑ�
    // Master
    // �T�E���h����
    public int Para_Master
    {
        set
        {
            S_MASTER = value;
            AudioListener.volume = value;
        }
        get
        {
            return S_MASTER;
        }
    }
    // SE
    // �T�E���h����
    public int Para_Se
    {
        set
        {
            S_SE = value;
        }
        get
        {
            return S_SE;
        }
    }

    // BGM
    // �T�E���h����
    public int Para_Bgm
    {
        set
        {
            S_BGM = value;
        }
        get
        {
            return S_BGM;
        }
    }
}
