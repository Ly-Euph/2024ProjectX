using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SensorManager : MonoBehaviour
{
    [SerializeField] GameObject[] Sensors;

    [SerializeField] Text[] Sensor_text;

    public BatteryManager Bm;

    public int Sensor_Bt;

    public bool IsSencor = false;

    void Start()
    {
        for(int i = 0; i < Sensor_text.Length; i++)
        {
            Sensor_text[i].text = "OFF";
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.C))
        //{
        //    IsSencor = IsSencor == false ? true : false;
        //    for (int i = 0; i < Sensor_text.Length; i++)
        //    {
        //        Sensor_text[i].text = "ON";
        //    }
        //}
        //if (Bm.Para_Battery <= Sensor_Bt)
        //{
        //    IsSencor = false;
        //}
        //if (IsSencor)
        //{
        //    Bm.Para_Battery -= 0.05f;
        //}
        //else
        //{
        //    for (int i = 0; i < Sensor_text.Length; i++)
        //    {
        //        Sensor_text[i].text = "OFF";
        //    }
        //}
    }
}
