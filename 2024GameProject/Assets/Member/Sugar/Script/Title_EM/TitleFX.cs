using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleFX : MonoBehaviour
{
    [SerializeField] GlitchFx Glfx;
    float timer = 0f;
    float FirstSet = 10f;
    float SecondSet = 20f;

    float GLSet = 0.01f;
    float GlEmset = 0.1f;
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
            if(timer>=FirstSet)
            {
                Glfx.intensity = GLSet;
            }
            if (timer >= SecondSet) {
                Glfx.intensity = GlEmset;
                if (timer >= SecondSet)
                { 
                    Glfx.intensity = GLSet;
                    timer = 0;// ‰Šú‰»
                }
            }
        }

    }
}
