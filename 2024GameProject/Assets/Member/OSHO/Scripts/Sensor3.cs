using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sensor3 : MonoBehaviour
{
    public CameraManager Cam;

    [SerializeField] GameObject Sensor_Image3;

    private bool IsSensor3 = true;

    private float Sensortimer3;

    private void Start()
    {
        Sensor_Image3.SetActive(false);
    }

    private void Update()
    {
        //if (!IsSensor3)
        //{
        //    Sensortimer3 += Time.deltaTime;
        //    if (Sensortimer3 >= 2)
        //    {
        //        Sensor_Image3.SetActive(false);
        //        Sensortimer3 = 0;
        //        IsSensor3 = true;
        //    }
        //}
        //Debug.Log(Sensortimer3);
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ìGÇ…êGÇÍÇ‹ÇµÇΩ");
        if (Cam.IsSencor[2]) Sensor_Image3.SetActive(true);
        IsSensor3 = false;
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("ìGÇ™ó£ÇÍÇ‹ÇµÇΩ");
        Sensor_Image3.SetActive(false);
    }
}