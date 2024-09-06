using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sensor1 : MonoBehaviour
{
    public CameraManager Cam;

    [SerializeField] GameObject Sensor_Image1;

    private bool IsSensor = true;

    private float Sensortimer;

    private void Start()
    {
        Sensor_Image1.SetActive(false);
    }

    private void Update()
    {
        if (!IsSensor)
        {
            Sensortimer += Time.deltaTime;
            if (Sensortimer >= 2)
            {
                Sensor_Image1.SetActive(false);
                Sensortimer = 0;
                IsSensor = true;
            }
        }
        Debug.Log(Sensortimer);
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ìGÇ…êGÇÍÇ‹ÇµÇΩ");
        if (Cam.IsSencor[0]) Sensor_Image1.SetActive(true);
        IsSensor = false;
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("ìGÇ™ó£ÇÍÇ‹ÇµÇΩ");
        Sensor_Image1.SetActive(false);
    }
}
