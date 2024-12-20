using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
[CreateAssetMenu(fileName = "SE", menuName = "CreateSE")]
public class SEData : ScriptableObject
{
    public enum Type // 実装するSEの種類
    {
        OBJ,HUMAN,ETC,
    }

    public Type type; // 種類
    public string infomation; // 情報

    // 音声データ
    public AudioClip[] SE;
    public SEData(SEData sedata)
    {
        this.type = sedata.type;
        this.infomation = sedata.infomation;
        this.SE = sedata.SE;
    }
}

