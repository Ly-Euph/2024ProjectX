using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jammer : MonoBehaviour
{
    private bool spawnFlag=false;

    private void OnEnable()
    {
        spawnFlag = true;
    }

    // 値渡し
    public bool SendFlag
    {
        set
        {
            spawnFlag = value;
        }
        get
        {
            return spawnFlag;
        }
    }
    void Update()
    {
        if (spawnFlag/* エコーされたらの処理にしろ！*/) {
            spawnFlag = false;
        } 
    }
}
