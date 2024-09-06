using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sensor6 : MonoBehaviour
{
    public CameraManager Cam;

    [SerializeField] GameObject Sensor_Image6;

    private bool IsSensor6 = true;

    private float Sensortimer6;

    private void Start()
    {
        Sensor_Image6.SetActive(false);
    }

    private void Update()
    {
        if (!IsSensor6)
        {
            Sensortimer6 += Time.deltaTime;
            if (Sensortimer6 >= 2)
            {
                Sensor_Image6.SetActive(false);
                Sensortimer6 = 0;
                IsSensor6 = true;
            }
        }
        Debug.Log(Sensortimer6);
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ìGÇ…êGÇÍÇ‹ÇµÇΩ");
        if (Cam.IsSencor[0]) Sensor_Image6.SetActive(true);
        IsSensor6 = false;
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("ìGÇ™ó£ÇÍÇ‹ÇµÇΩ");
        Sensor_Image6.SetActive(false);
    }
}