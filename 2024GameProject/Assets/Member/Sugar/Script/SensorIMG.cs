using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SensorIMG : MonoBehaviour
{
    #region field
    [Header("�\���ꏊ"), SerializeField] GameObject[] Obj;
    [SerializeField] SensorManager sMng;
    #endregion

    void Update()
    {
        if (sMng.Recieve)
        {
            Spawn();
        }
    }
    void Spawn()
    {
        Obj[sMng.GSSensor - 1].SetActive(true);
    }
}
