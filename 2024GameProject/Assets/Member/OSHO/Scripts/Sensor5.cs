using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sensor5 : MonoBehaviour
{
    public CameraManager Cam;

    [SerializeField] GameObject Sencor_Image5;

    private void Start()
    {
        Sencor_Image5.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ìGÇ…êGÇÍÇ‹ÇµÇΩ");
        if (Cam.IsSencor[4]) Sencor_Image5.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("ìGÇ™ó£ÇÍÇ‹ÇµÇΩ");
        Sencor_Image5.SetActive(false);
    }
}
