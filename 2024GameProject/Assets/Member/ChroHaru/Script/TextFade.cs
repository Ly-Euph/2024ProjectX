using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextFade : MonoBehaviour
{
    [SerializeField] Text entertext;
    float colUnder = 1.0f;
    [SerializeField]float fadeSpd = 0.05f;
    int num = 0;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        switch (num)
        {
            case 0:
                colUnder -= fadeSpd;
                if (colUnder <= 0)
                {
                    num++;
                }
                entertext.color = new Color(1, 1, 1, colUnder);
                break;
            case 1:
                colUnder += fadeSpd;
                if (colUnder >= 1)
                {
                    num=0;
                }
                entertext.color = new Color(1, 1, 1, colUnder);
                break;
        }
    }
}
