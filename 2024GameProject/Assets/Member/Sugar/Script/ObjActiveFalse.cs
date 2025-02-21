using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjActiveFalse : MonoBehaviour
{
    float _timer = 0;
    const float setT = 3.0f;
    // スキャンエフェクトに使うUIの座標
    [SerializeField] RectTransform[] rct;
    [SerializeField] Vector3[] v3;

    private void OnEnable()
    {
        _timer = setT;

        for(int i=0;i<rct.Length;i++)
        {
            rct[i].anchoredPosition = v3[i];
        }
    }

    private void Update()
    {
        _timer -= Time.deltaTime;
        if(_timer<=0)
        {
            this.gameObject.SetActive(false);
        }
    }
}
