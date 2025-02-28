using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
[CreateAssetMenu(fileName = "SE", menuName = "CreateSE")]
public class SEData : ScriptableObject
{
    public enum Type // À‘•‚·‚éSE‚Ìí—Ş
    {
        OBJ,HUMAN,ETC,
    }

    public Type type; // í—Ş

    // ‰¹ºƒf[ƒ^
    public AudioClip[] SE;
    public SEData(SEData sedata)
    {
        this.type = sedata.type;
        this.SE = sedata.SE;
    }
}

