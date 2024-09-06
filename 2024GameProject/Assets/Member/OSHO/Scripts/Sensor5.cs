using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sensor5 : MonoBehaviour
{
    public CameraManager Cam;

    [SerializeField] GameObject Sensor_Image5;

    private bool IsSensor5 = true;

    private float Sensortimer5;

    private void Start()
    {
        Sensor_Image5.SetActive(false);
    }

    private void Update()
    {
        if (!IsSensor5)
        {
            Sensortimer5 += Time.deltaTime;
            if (Sensortimer5 >= 2)
            {
                Sensor_Image5.SetActive(false);
                Sensortimer5 = 0;
                IsSensor5 = true;
            }
        }
        Debug.Log(Sensortimer5);
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ìGÇ…êGÇÍÇ‹ÇµÇΩ");
        if (Cam.IsSencor[0]) Sensor_Image5.SetActive(true);
        IsSensor5 = false;
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("ìGÇ™ó£ÇÍÇ‹ÇµÇΩ");
        Sensor_Image5.SetActive(false);
    }
}