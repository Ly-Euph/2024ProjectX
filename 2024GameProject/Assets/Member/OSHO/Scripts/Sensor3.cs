using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sensor3 : MonoBehaviour
{
    public CameraManager Cam;

    [SerializeField] GameObject Sencor_Image3;

    private void Start()
    {
        Sencor_Image3.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ìGÇ…êGÇÍÇ‹ÇµÇΩ");
        if (Cam.IsSencor[1]) Sencor_Image3.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("ìGÇ™ó£ÇÍÇ‹ÇµÇΩ");
        Sencor_Image3.SetActive(false);
    }
}
