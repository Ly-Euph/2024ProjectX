using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SencorManager : MonoBehaviour
{
    string SencorNum;
    // Start is called before the first frame update
    public string GSSencor
    {
        set { SencorNum = value;}

        get { return SencorNum; }

    }

}
