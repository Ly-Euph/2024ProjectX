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

    private float rad = 3.14f / 180;

    [Header("�J�����̔ԍ��ɉ�����Prefab�����ĂˁB")]

    [SerializeField] Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        MaxrotPos = rad * MaxrotPos;
        MinrotPos = rad * MinrotPos;
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log(this.transform.rotation.y);
        if(Input.GetKey(KeyCode.W) && cam.fieldOfView > CamMin)
        {
            cam.fieldOfView -= 0.5f;
        }

        if(Input.GetKey(KeyCode.S) && cam.fieldOfView < CamMax)
        {
            cam.fieldOfView += 0.5f;
        }
        if (Input.GetKey(KeyCode.A) && MinrotPos < transform.rotation.y)
        {
            //transform.Rotate(new Vector3(0, -1, 0));
            transform.rotation *= Quaternion.Euler(0, -1, 0);
            //this.transform.localEulerAngles += new Vector3(0, -1, 0);

        }
        if (Input.GetKey(KeyCode.D) && transform.rotation.y < MaxrotPos)
        {
            //transform.Rotate(new Vector3(0, 1, 0));
            transform.rotation *= Quaternion.Euler(0, 1, 0);
            //this.transform.localEulerAngles += new Vector3(0, 1, 0);
        }
    }
}
