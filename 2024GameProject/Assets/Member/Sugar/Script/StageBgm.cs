using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageBgm : MonoBehaviour
{
    [SerializeField] GameManager gMng;

    float timer = 0.0f;
    float interval = 5.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >=interval) {
            timer = 0;
            gMng.OneShotSE_C(SEData.Type.OBJ, GameManager.ClipSe.stage);
        }
    }
}
