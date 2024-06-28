using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EchoManager : MonoBehaviour
{
    [SerializeField] GameObject[] EchoUI;
    [SerializeField] RectTransform[] rct;

    float sclX, sclY,sclZ;

    Vector3 scale;
    void Start()
    {
        sclX = 3.0f;
        sclY = 2.0f;
        sclZ = 5.0f;
        scale = new Vector3(sclX, sclY,sclZ);
    }

    // Update is called once per frame
    void Update()
    {
        if (EchoUI[0].activeSelf)
        {
            if (rct[0].localScale.x >= scale.x)
            {
                EchoUI[1].SetActive(true);
            }
        }
        if (EchoUI[1].activeSelf)
        {
            if (rct[1].localScale.y >= scale.y)
            {
                EchoUI[2].SetActive(true);
            }
        }
    }

    public void EchoMode()
    {
        //LeftShift‚ğ‰Ÿ‚µ‚½‚ç‚Ìˆ—
        if (Input.GetKeyDown(KeyCode.C))
        {
            EchoUI[0].SetActive(true);
        }
        // —¬‚ê
    }
}
