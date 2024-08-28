using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sensor7: MonoBehaviour
{
    public CameraManager Cam;

    [SerializeField] GameObject Sencor_Image7;

    private void Start()
    {
        Sencor_Image7.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("�G�ɐG��܂���");
        if (Cam.IsSencor[5]) Sencor_Image7.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("�G������܂���");
        Sencor_Image7.SetActive(false);
    }
}