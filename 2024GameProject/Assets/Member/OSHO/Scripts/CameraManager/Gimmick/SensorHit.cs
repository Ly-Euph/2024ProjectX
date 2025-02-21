using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SensorHit : MonoBehaviour
{
    // センサー番号をMngに送り管理
    [SerializeField] SensorManager SensorMng;
    // このセンサーの番号
    [SerializeField] int SendNum;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("敵に触れました");
        SensorMng.GSSensor = SendNum;
    }
}
