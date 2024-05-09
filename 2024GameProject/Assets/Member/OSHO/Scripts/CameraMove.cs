using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    Camera cam;

    public int CamMin = 30;
    public int CamMax = 50;

    [SerializeField] float MaxrotPos = -50;
    [SerializeField] float MinrotPos = -50;
    // Start is called before the first frame update
    void Start()
    {
        cam = gameObject.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W) && cam.fieldOfView > CamMin)
        {
            cam.fieldOfView -= 0.5f;
        }

        if(Input.GetKey(KeyCode.S) && cam.fieldOfView < CamMax)
        {
            cam.fieldOfView += 0.5f;
        }
        if(Input.GetKey(KeyCode.A) && transform.position.y <= MinrotPos)
        {
            transform.Rotate(new Vector3(0, -50, 0));
        }
        if(Input.GetKey(KeyCode.D) && transform.position.y <= MaxrotPos)
        {
            transform.Rotate(new Vector3(0, 50, 0));
        }
    }
}
