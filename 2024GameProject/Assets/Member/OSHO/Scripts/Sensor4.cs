using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sensor4 : MonoBehaviour
{
    public CameraManager Cam;

    [SerializeField] GameObject Sencor_Image4;

    private void Start()
    {
        Sencor_Image4.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("�G�ɐG��܂���");
        if (Cam.IsSencor[1]) Sencor_Image4.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("�G������܂���");
        Sencor_Image4.SetActive(false);
    }
}
