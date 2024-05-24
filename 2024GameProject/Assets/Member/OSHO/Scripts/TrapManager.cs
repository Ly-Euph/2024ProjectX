using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapManager : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField] BatteryManager Bm;

    [Header("Trapを設置するObject")]

    [SerializeField] GameObject[] Trap_Obj = new GameObject[4];

    [Header("様々なTrapを入れてね")]

    [SerializeField] GameObject[] Trap_GK = new GameObject[4];

    [Header("お好きなようにクールタイムを変えてね")]

    [SerializeField] float Cool_Time = 20;

    private float time;

    private bool TimeFlg = true;

    
    void Start() 
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && TimeFlg)
        {
            Vector3 ObjPos = Trap_Obj[0].transform.position;
            Instantiate(Trap_GK[0], ObjPos, Quaternion.identity);
            TimeFlg = false;
            time = 0;
            if (Bm.Para_Battery >= 0)
            {
                Bm.Para_Battery -= 1;
            }
        }
        if(!TimeFlg)
        {
            time += Time.deltaTime;
            Debug.Log(time);
            //Eキーのクールタイム
            if(time >= Cool_Time)
            {
                TimeFlg = true;
                
            }
        }
    }
}
