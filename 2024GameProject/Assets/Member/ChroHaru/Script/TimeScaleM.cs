using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScaleM : MonoBehaviour
{
    public int timescale=1;//�O������̕ύX�ŃQ�[���̃^�C���X�P�[������v������
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timescale==1)
        {
            Time.timeScale = 1;
        }
        else if(timescale==2)
        {
            Time.timeScale = 2;
        }
        else if (timescale == 0)
        {
            Time.timeScale = 0;
        }
    }
}
