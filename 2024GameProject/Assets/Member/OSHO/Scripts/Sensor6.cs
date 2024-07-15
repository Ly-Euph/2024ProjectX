using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sensor6 : MonoBehaviour
{
    public CameraManager Cam;

    [SerializeField] GameObject Sencor_Image6;

    private void Start()
    {
        Sencor_Image6.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ìGÇ…êGÇÍÇ‹ÇµÇΩ");
        if (Cam.IsSencor[1]) Sencor_Image6.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("ìGÇ™ó£ÇÍÇ‹ÇµÇΩ");
        Sencor_Image6.SetActive(false);
    }
}
