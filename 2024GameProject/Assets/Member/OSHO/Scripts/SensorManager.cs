using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorManager : MonoBehaviour
{
    string SencorNum;

    bool recieve = false;
    // Start is called before the first frame update
    public string GSSencor
    {
        set 
        {
            SencorNum = value;
            recieve = true;
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
