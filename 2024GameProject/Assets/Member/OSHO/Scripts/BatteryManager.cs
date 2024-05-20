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

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        img.GetComponent<Image>().fillAmount = battery / 100;

        //‚±‚Ìê‡‚Ì‚İ(int)‚ğg—pB
        text.text = (int)battery + "%";
        Debug.Log((int)battery);
    }
    public float Para_Battery
    {
        set { battery = value; }
        get { return battery; }
    }
}
