using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sensor1 : MonoBehaviour
{
    [SerializeField] SencorManager SencorMng;
    [SerializeField] string SendTex;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("�G�ɐG��܂���");
        SencorMng.GSSencor = SendTex.ToString();
    }
}
