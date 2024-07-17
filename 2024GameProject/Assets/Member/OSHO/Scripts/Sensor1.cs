using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sensor1 : MonoBehaviour
{
    public CameraManager Cam;

    [SerializeField] GameObject Sencor_Image1;

    private void Start()
    {
        Sencor_Image1.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("�G�ɐG��܂���");
        if (Cam.IsSencor[0]) Sencor_Image1.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("�G������܂���");
        Sencor_Image1.SetActive(false);
    }
}
