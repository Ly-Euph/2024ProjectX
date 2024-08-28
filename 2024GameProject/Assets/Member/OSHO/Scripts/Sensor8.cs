using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sensor8 : MonoBehaviour
{
    public CameraManager Cam;

    [SerializeField] GameObject Sencor_Image8;

    private void Start()
    {
        Sencor_Image8.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ìGÇ…êGÇÍÇ‹ÇµÇΩ");
        if (Cam.IsSencor[5]) Sencor_Image8.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("ìGÇ™ó£ÇÍÇ‹ÇµÇΩ");
        Sencor_Image8.SetActive(false);
    }
}