using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject cam1;
    private GameObject cam2;
    private GameObject cam3;
    private GameObject cam4;

    public bool camZoomFlag;
    public bool camHack;

    private int camNum;

    void Start()
    {
        cam1 = GameObject.Find("Camera1");
        cam2 = GameObject.Find("Camera2");
        cam3 = GameObject.Find("Camera3");
        cam4 = GameObject.Find("Camera4");

        cam1.SetActive(true);
        cam2.SetActive(false);
        cam3.SetActive(false);
        cam4.SetActive(false);

        camZoomFlag = true;
        camHack = false;

        camNum = 1;
    }

    // Update is called once per frame
    void Update()
    {
        CameraMove();
        CameraSelect();
        CameraZoom();

        if(camHack==true)
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                camHack = false;
            }
        }

    }

    void CameraMove()
    {
        switch(camNum)
        {
            case 1:
                if(Input.GetKey(KeyCode.A))
                {
                    cam1.transform.Rotate(0, -0.15f, 0);
                }
                else if(Input.GetKey(KeyCode.D))
                {
                    cam1.transform.Rotate(0, 0.15f, 0);
                }break;

            case 2:
                if (Input.GetKey(KeyCode.A))
                {
                    cam2.transform.Rotate(0, -0.15f, 0);
                }
                else if (Input.GetKey(KeyCode.D))
                {
                    cam2.transform.Rotate(0, 0.15f, 0);
                }break;

            case 3:
                if (Input.GetKey(KeyCode.A))
                {
                    cam3.transform.Rotate(0, -0.15f, 0);
                }
                else if (Input.GetKey(KeyCode.D))
                {
                    cam3.transform.Rotate(0, 0.15f, 0);
                }break;

            case 4:
                if (Input.GetKey(KeyCode.A))
                {
                    cam4.transform.Rotate(0, -0.15f, 0);
                }
                else if (Input.GetKey(KeyCode.D))
                {
                    cam4.transform.Rotate(0, 0.15f, 0);
                }break;
        }
    }

    void CameraSelect()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            cam1.SetActive(true);
            cam2.SetActive(false);
            cam3.SetActive(false);
            cam4.SetActive(false);
            camNum = 1;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            cam1.SetActive(false);
            cam2.SetActive(true);
            cam3.SetActive(false);
            cam4.SetActive(false);
            camNum = 2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            cam1.SetActive(false);
            cam2.SetActive(false);
            cam3.SetActive(true);
            cam4.SetActive(false);
            camNum = 3;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            cam1.SetActive(false);
            cam2.SetActive(false);
            cam3.SetActive(false);
            cam4.SetActive(true);
            camNum = 4;
        }
    }

    void CameraZoom()
    {
        switch(camNum)
        {
            case 1:
                if (Input.GetKey(KeyCode.W))
                {
                    cam1.GetComponent<Camera>().fieldOfView -= 0.1f;
                }
                else if (Input.GetKey(KeyCode.S))
                {
                    cam1.GetComponent<Camera>().fieldOfView += 0.1f;
                }break;

            case 2:
                if (Input.GetKey(KeyCode.W))
                {
                    cam2.GetComponent<Camera>().fieldOfView -= 0.1f;
                }
                else if (Input.GetKey(KeyCode.S))
                {
                    cam2.GetComponent<Camera>().fieldOfView += 0.1f;
                }break;

            case 3:
                if (Input.GetKey(KeyCode.W))
                {
                    cam3.GetComponent<Camera>().fieldOfView -= 0.1f;
                }
                else if (Input.GetKey(KeyCode.S))
                {
                    cam3.GetComponent<Camera>().fieldOfView += 0.1f;
                }break;

            case 4:
                if (Input.GetKey(KeyCode.W))
                {
                    cam4.GetComponent<Camera>().fieldOfView -= 0.1f;
                }
                else if (Input.GetKey(KeyCode.S))
                {
                    cam4.GetComponent<Camera>().fieldOfView += 0.1f;
                }break;
        }

        
    }

}
