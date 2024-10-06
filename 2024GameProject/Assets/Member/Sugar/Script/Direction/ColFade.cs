using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ColFade : MonoBehaviour
{
    [SerializeField] Image img;

    float fadeSpd=1;
    int num = 0;
    void Start()
    {
        img.color = new Color(1, 0, 0, fadeSpd);
        
    }

    // Update is called once per frame
    void Update()
    {
        switch(num)
        {
            case 0:
                fadeSpd -= 0.02f;
                img.color = new Color(1, 0, 0, fadeSpd);
                if(fadeSpd<=0)
                {
                    num++;
                }
                break;
            case 1:
                fadeSpd += 0.02f;
                img.color = new Color(1, 0, 0, fadeSpd);
                if (fadeSpd >= 1)
                {
                    num=0;
                }
                break;
        }
    }
}
