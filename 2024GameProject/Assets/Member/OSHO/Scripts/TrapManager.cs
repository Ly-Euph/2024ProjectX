using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] BatteryManager Bm;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Bm.Para_Battery -= 1;
        }
    }
}
