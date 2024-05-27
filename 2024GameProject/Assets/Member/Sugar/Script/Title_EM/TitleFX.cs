using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleFX : MonoBehaviour
{
    [SerializeField] GlitchFx Glfx;
    [SerializeField]GameObject EMObj;
    float timer = 0f;
    float FirstSet = 10f;
    float SecondSet = 20f;
    float EmsetTime = 2.0f;

    float GLSet = 0.01f;
    float GlEmset = 1.0f;
    void Start()
    {
        Glfx.intensity = GLSet;
    }
   
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer>=FirstSet)
        {
            Glfx.intensity = GlEmset;
            EMObj.SetActive(true);
            if(timer>=FirstSet+EmsetTime)
            {
                Glfx.intensity = GLSet;
            }
            if (timer >= SecondSet) {
                Glfx.intensity = GlEmset;
                EMObj.SetActive(false);
                if (timer >= SecondSet + EmsetTime)
                { 
                    Glfx.intensity = GLSet;
                    timer = 0;// ‰Šú‰»
                }
            }
        }

    }
}
