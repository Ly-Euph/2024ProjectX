using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1Test : MonoBehaviour
{
    public GameObject Stage1;
    public GameObject Stage2;
    public GameObject Stage3;
    public GameObject Stage4;
    public GameObject Stage5;
    public GameObject Stage6;
    float SetActivetimer = 0f;
    bool TimerCheck = false;

    void Update()
    {
        TimerCheck = true;
        if (TimerCheck == true)
        {
            SetActivetimer += Time.deltaTime;
        }
        if (SetActivetimer > 5.0f)
        {
            GameOjectAcitve();
        }
    }
    void GameOjectAcitve()
    {
        Stage1.SetActive(true);
    }

}
