using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Image img;
    [SerializeField] Text text;

    private float battery = 100f;

    private float battery_time = 0;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //バッテリー回復処理
        Debug.Log(battery_time);
        battery_time += Time.deltaTime;

        if(battery_time >= 10)
        {
            if (battery < 100)
            {
                battery += 1f;
                battery_time = 0;
            }
        }
        if (battery >= 0)
        {
            img.GetComponent<Image>().fillAmount = battery / 100;

            //この場合のみ(int)を使用。
            text.text = (int)battery + "%";
        }
    }
    public float Para_Battery
    {
        set { battery = value;}
        get { return battery;}
    }

}
