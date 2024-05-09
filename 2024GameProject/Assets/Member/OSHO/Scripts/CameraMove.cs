using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    Camera cam;

    public int camMin = 30;
    public int camMax = 50;
    // Start is called before the first frame update
    void Start()
    {
        cam = gameObject.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W) && cam.fieldOfView > camMin)
        {
            cam.fieldOfView -= 0.5f;
        }

        if(Input.GetKey(KeyCode.S) && cam.fieldOfView < camMax)
        {
            cam.fieldOfView += 0.5f;
        }
    }
}
