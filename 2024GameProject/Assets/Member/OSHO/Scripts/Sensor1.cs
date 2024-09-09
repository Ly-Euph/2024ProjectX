using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sensor1 : MonoBehaviour
{
    [SerializeField] SensorManager SencorMng;
    [SerializeField] string SendTex;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ìGÇ…êGÇÍÇ‹ÇµÇΩ");
        SencorMng.GSSencor = SendTex.ToString();
    }
}
