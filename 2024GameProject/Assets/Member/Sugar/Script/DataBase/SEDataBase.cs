using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// SEをデータベースにまとめておく
[CreateAssetMenu(fileName = "SEDataBase", menuName = "CreateSEDataBase")]
public class SEDataBase : ScriptableObject
{
    [Header("0:OBJ 1:HUMAN 2:ETC")]
    public List<SEData> SEDATA = new List<SEData>();
}

