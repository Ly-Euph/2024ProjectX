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
        Debug.Log("�G�ɐG��܂���");
<<<<<<< HEAD
        SencorMng.GSSencor = SendNum;
=======
        SencorMng.GSSensor = SendNum;
>>>>>>> main
    }
}
