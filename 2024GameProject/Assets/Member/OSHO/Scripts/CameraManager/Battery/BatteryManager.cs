using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// バッテリーの値や回復、UIに残量によって変化をさせる機能
public class BatteryManager : MonoBehaviour
{
    //batteryのImage画像
    [SerializeField] Image IMAGE_battery;

    //batteryのText
    [SerializeField] Text TEXT_battery;

    // バッテリー残量のUI効果
    [SerializeField] int batteryRed;

    [SerializeField] int batteryYellow;

    //batteryの最大
    private int batteryMax = 100;

    //batteryの値
    [Header("チュートリアルのみここは20で"),SerializeField] float battery = 15f;

    // 回復間隔
    public float batteryCT;

    //batteryが回復する時に使うタイマー変数
    private float timer = 0;

    /// <summary>
    /// バッテリー残量を回復させる
    /// </summary>
    public void HealBattery()
    {
        if (battery != batteryMax) { timer += Time.deltaTime; }

        if (timer >= batteryCT)
        {
            if (battery <= batteryMax)
            {
                battery += 1f;
                timer = 0;
            }
        }
        
    }

    /// <summary>
    /// バッテリーの反映
    /// </summary>
    public void BatteryOut()
    {
        if (battery >= 0)
        {
            IMAGE_battery.GetComponent<Image>().fillAmount = battery / batteryMax;

            TEXT_battery.text = (int)battery + "%";
        }
    }

    /// <summary>
    /// バッテリー残量に伴い色を変えます
    /// </summary>
    public void Battery_Color()
    {
        //バッテリーの色変換

        if (Para_Battery < batteryRed)
        {
            IMAGE_battery.color = Color.red;
        }
        else if (Para_Battery < batteryYellow)
        {
            IMAGE_battery.color = Color.yellow;
        }
        else
        {
            IMAGE_battery.color = Color.white;
        }

    }

    /// <summary>
    /// バッテリーの値をギミックたちに渡して管理
    /// </summary>
    public float Para_Battery
    {
        set { battery = value; }
        get { return battery; }
    }
}
