using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Image img;
    [SerializeField] Text text;
    int battery = 100;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        img.GetComponent<Image>().fillAmount = battery / 100;
        text.text = battery.ToString() + "%";

        
    }
    public int Para_Battery
    {
        set { battery = value; }
        get { return battery; }
    }
}
