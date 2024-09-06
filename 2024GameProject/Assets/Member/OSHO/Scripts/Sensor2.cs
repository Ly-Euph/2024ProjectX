using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sensor2 : MonoBehaviour
{
    public CameraManager Cam;

    [SerializeField] GameObject Sensor_Image2;

    private bool IsSensor2 = true;

    private float Sensortimer2;

    private void Start()
    {
        Sensor_Image2.SetActive(false);
    }

    private void Update()
    {
        //if (!IsSensor2)
        //{
        //    Sensortimer2 += Time.deltaTime;
        //    if (Sensortimer2 >= 2)
        //    {
        //        Sensor_Image2.SetActive(false);
        //        Sensortimer2 = 0;
        //        IsSensor2 = true;
        //    }
        //}
        //Debug.Log(Sensortimer2);
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ƒJƒƒ‰2”½‰‚ ‚è");
        if (Cam.IsSencor[1]) Sensor_Image2.SetActive(true);
        IsSensor2 = false;
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("“G‚ª—£‚ê‚Ü‚µ‚½");
        Sensor_Image2.SetActive(false);
    }
}