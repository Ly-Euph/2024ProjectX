using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    Camera cam;

    public int CamMin = 30;
    public int CamMax = 50;

    //カメラの横振りの制御をシリアライズ化
    [SerializeField] float MaxrotPos = 50;
    [SerializeField] float MinrotPos = -50;

    // Start is called before the first frame update
    void Start()
    {
        cam = gameObject.GetComponent<Camera>();
    }
    int f =0;
    // Update is called once per frame
    void Update()
    {
        Debug.Log(transform.localRotation.y);
        if(Input.GetKey(KeyCode.W) && cam.fieldOfView > CamMin)
        {
            cam.fieldOfView -= 0.5f;
        }

        if(Input.GetKey(KeyCode.S) && cam.fieldOfView < CamMax)
        {
            cam.fieldOfView += 0.5f;
        }
        if(Input.GetKey(KeyCode.A) && transform.localRotation.y * 180 / 3.14>= MinrotPos)
        {
            transform.Rotate(new Vector3(0, -1, 0));
  
        }
        if(Input.GetKey(KeyCode.D) && transform.localRotation.y * 180 / 3.14 <= MaxrotPos)
        {
            transform.Rotate(new Vector3(0, 1, 0));
        }
    }
}
