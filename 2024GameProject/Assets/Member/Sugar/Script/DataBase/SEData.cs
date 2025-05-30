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

    // 音声データ
    public AudioClip[] SE;
    public SEData(SEData sedata)
    {
        this.type = sedata.type;
        this.SE = sedata.SE;
    }
}

