using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorManager : MonoBehaviour
{
    int SencorNum;

    bool recieve = false;
    [Header("ï\é¶èÍèä"), SerializeField] GameObject[] Obj;

    // Start is called before the first frame update
    public int GSSensor
    {
        set 
        {
            SencorNum = value;
            recieve = true;
            Obj[SencorNum - 1].SetActive(true);
        }

        get 
        {
            recieve = false;
            return SencorNum;
        }

    }
    public bool Recieve
    {
        get
        {
            return recieve;
        }
    }
}
