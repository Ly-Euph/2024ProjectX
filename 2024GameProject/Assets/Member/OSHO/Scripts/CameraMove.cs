using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [Header("�����ŃJ�����̃Y�[���@�\��ݒ肵�Ăق���")]

    [SerializeField] int CamMin = 30;
    [SerializeField] int CamMax = 50;

    //�J�����̉��U��̐�����V���A���C�Y��

    [Header("�����ŃJ�����̐U�蕝��ݒ肵�Ăق���")]

    [SerializeField] float MaxrotPos = 50;
    [SerializeField] float MinrotPos = -50;

    private float rad = 180 / 3.14f;
    Camera cam;


    // Start is called before the first frame update
    void Start()
    {
        cam = gameObject.GetComponent<Camera>();
    }
    int f =0;
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
        if(Input.GetKey(KeyCode.A) && transform.localRotation.y * rad>= MinrotPos)
        {
            transform.Rotate(new Vector3(0, -1, 0));
  
        }
        if(Input.GetKey(KeyCode.D) && transform.localRotation.y * rad <= MaxrotPos)
        {
            transform.Rotate(new Vector3(0, 1, 0));
        }
    }
}
