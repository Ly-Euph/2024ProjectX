using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraManager : MonoBehaviour
{
    [SerializeField] GameObject Camera1;
    [SerializeField] GameObject Camera2;
    [SerializeField] GameObject Camera3;
    [SerializeField] GameObject Camera4;

    public Rect newviewport;

    void Start()
    {
       
    }

    void Update()
    { 
        //番号１
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
           
        }
        //番号２
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
           
        }
        //番号３
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
           
        }
        //番号４
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
           
        }
    }
}