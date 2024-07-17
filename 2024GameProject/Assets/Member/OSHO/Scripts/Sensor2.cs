using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sensor2 : MonoBehaviour
{
    public CameraManager Cam;

    [SerializeField] GameObject Sencor_Image2;

    private void Start()
    {
        Sencor_Image2.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ìGÇ…êGÇÍÇ‹ÇµÇΩ");
        if (Cam.IsSencor[1]) Sencor_Image2.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("ìGÇ™ó£ÇÍÇ‹ÇµÇΩ");
        Sencor_Image2.SetActive(false);
    }
}
