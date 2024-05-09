using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Hide : MonoBehaviour
{
    SkinnedMeshRenderer skin;

    private bool camScan;

    private float scanTime;

    // Start is called before the first frame update
    void Start()
    {
        skin = GetComponent<SkinnedMeshRenderer>();
        skin.enabled = false;

        camScan = false;

        scanTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            camScan = true;
        }


        if (camScan == true)
        {
            CamScan();
            scanTime += 1 / 60f;
        }
    }

    void CamScan()
    {
        Debug.Log("ƒXƒLƒƒƒ“’†");

        skin.enabled = true;

        if(scanTime>=4)
        {
            scanTime = 0;
            skin.enabled = false;
            camScan = false;
        }
    }
}
