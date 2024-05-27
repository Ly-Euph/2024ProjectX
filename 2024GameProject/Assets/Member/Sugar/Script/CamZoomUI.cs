using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamZoomUI : MonoBehaviour
{
    [Header("ここでカメラのズーム倍率設定")]
    [SerializeField] int camMax;
    [SerializeField] int camMin;
    [SerializeField] RectTransform rct;
    [SerializeField] Camera cam;
    float copyView;
    float dist = 0;
    float Ypos = 0;
    float YposMax = 300;
    Vector3 pos;
    void Start()
    {
        copyView = camMax;

        dist = camMax - camMin;

        Ypos = YposMax / dist ;

        // 初期位置
        rct.anchoredPosition = new Vector3(-800,0,0);
        pos = rct.anchoredPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (copyView == cam.fieldOfView) { return; }
        else if (copyView >= cam.fieldOfView&&cam.fieldOfView%1==0) {
            copyView = cam.fieldOfView;
            pos += new Vector3(0,Ypos,0);
        }
        else if (copyView <= cam.fieldOfView && cam.fieldOfView % 1 == 0) {
            copyView = cam.fieldOfView;
            pos -= new Vector3(0, Ypos, 0);
        }
        rct.anchoredPosition = pos;
    }
}
