using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StartFade : MonoBehaviour
{
    [SerializeField] Image img;

    float fadeSpd = 1;

    // Update is called once per frame
    void Update()
    {
        fadeSpd -= 0.02f;
        img.color = new Color(0, 0, 0, fadeSpd);

        if(fadeSpd<=0)
        {
            Destroy(gameObject);
        }
    }
}
