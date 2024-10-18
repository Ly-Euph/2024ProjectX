using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sensor1 : MonoBehaviour
{
    [SerializeField] SensorManager SencorMng;
    [SerializeField] int SendNum;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ìGÇ…êGÇÍÇ‹ÇµÇΩ");
        SencorMng.GSSencor = SendNum.ToString();
    }
}
