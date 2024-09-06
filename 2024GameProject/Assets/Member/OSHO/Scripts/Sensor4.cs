using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sensor4 : MonoBehaviour
{
    public CameraManager Cam;

    [SerializeField] GameObject Sensor_Image4;

    private bool IsSensor4 = true;

    private float Sensortimer4;

    private void Start()
    {
        Sensor_Image4.SetActive(false);
    }

    private void Update()
    {
        //if (!IsSensor4)
        //{
        //    Sensortimer4 += Time.deltaTime;
        //    if (Sensortimer4 >= 2)
        //    {
        //        Sensor_Image4.SetActive(false);
        //        Sensortimer4 = 0;
        //        IsSensor4 = true;
        //    }
        //}
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ìGÇ…êGÇÍÇ‹ÇµÇΩ");
        if (Cam.IsSencor[3]) Sensor_Image4.SetActive(true);
        IsSensor4 = false;
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("ìGÇ™ó£ÇÍÇ‹ÇµÇΩ");
        Sensor_Image4.SetActive(false);
    }
}