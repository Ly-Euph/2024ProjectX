using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sensor1 : MonoBehaviour
{
    public CameraManager Cam;

    [SerializeField] GameObject Sensor_Image1;

    private void Start()
    {
        Sensor_Image1.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ìGÇ…êGÇÍÇ‹ÇµÇΩ");
        if (Cam.IsSencor[0]) Sensor_Image1.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("ìGÇ™ó£ÇÍÇ‹ÇµÇΩ");
        Sensor_Image1.SetActive(false);
    }
}
