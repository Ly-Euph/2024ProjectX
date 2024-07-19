using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryManager : MonoBehaviour
{
    //batteryのImage画像
    [SerializeField] Image IMAGE_battery;

    //batteryのText
    [SerializeField] Text TEXT_battery;

    //Batteryの初期値
    private int INT_battery = 100;

    //Batteryの値
    private float FLOAT_battery = 100f;

    //batteryが回復する時に使うタイマー変数
    private float FLOAT_time = 0;

    void Update()
    {
        
        if (FLOAT_battery != INT_battery) { FLOAT_time += Time.deltaTime; }

        if (FLOAT_time >= 2)
        {
            if (FLOAT_battery < INT_battery)
            {
                FLOAT_battery += 1f;
                FLOAT_time = 0;
            }
        }
        if (FLOAT_battery >= 0)
        {
            IMAGE_battery.GetComponent<Image>().fillAmount = FLOAT_battery / INT_battery;

            TEXT_battery.text = (int)FLOAT_battery + "%";
        }


        if (Para_Battery < 25)
        {
            IMAGE_battery.color = Color.red;
        }
        else
        {
            IMAGE_battery.color = Color.white;
        }
    }
    public float Para_Battery
    {
        set { FLOAT_battery = value; }
        get { return FLOAT_battery; }
    }
}
