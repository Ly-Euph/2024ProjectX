using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScanManager : MonoBehaviour
{
    bool isScan = false;

    public bool ScanBool
    {
        get 
        {
            return isScan;
        }
        set 
        {
            isScan = value;
        }
    }
}
