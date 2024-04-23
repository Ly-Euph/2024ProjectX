using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraManager : MonoBehaviour
{
    public GameObject Camera1;
    public GameObject Camera2;
    public GameObject Camera3;
    public GameObject Camera4;

    public Text CameraNumber1;
    public Text CameraNumber2;
    public Text CameraNumber3;
    public Text CameraNumber4;

    int countTimer = 0;
    void Start()
    {
        // �e�J�����I�u�W�F�N�g���擾
        Camera1 = GameObject.Find("Camera1");
        Camera2 = GameObject.Find("Camera2");
        Camera3 = GameObject.Find("Camera3");
        Camera4 = GameObject.Find("Camera4");

        // �T�u�J�����̓f�t�H���g�Ŗ����ɂ��Ă���
        Camera2.SetActive(false);
        Camera3.SetActive(false);
        Camera4.SetActive(false);

        //�e�L�X�g�֘A
        CameraNumber2.enabled = false;
        CameraNumber3.enabled = false;
        CameraNumber4.enabled = false;
    }

    void Update()
    { 
        //�ԍ��P
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            // �e�J�����I�u�W�F�N�g�̗L���t���O���t�](true��false,false��true)������
            Camera1.SetActive(true);
            Camera2.SetActive(false);
            Camera3.SetActive(false);
            Camera4.SetActive(false);

            //�e�e�L�X�g�̗L���t���O���t�](true��false,false��true)������
            CameraNumber1.enabled = true;
            CameraNumber2.enabled = false;
            CameraNumber3.enabled = false;
            CameraNumber4.enabled = false;
        }
        //�ԍ��Q
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Camera2.SetActive(true);
            Camera1.SetActive(false);
            Camera3.SetActive(false);
            Camera4.SetActive(false);

            CameraNumber2.enabled = true;
            CameraNumber1.enabled = false;
            CameraNumber3.enabled = false;
            CameraNumber4.enabled = false;
        }
        //�ԍ��R
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Camera3.SetActive(true);
            Camera1.SetActive(false);
            Camera2.SetActive(false);
            Camera4.SetActive(false);

            CameraNumber3.enabled = true;
            CameraNumber1.enabled = false;
            CameraNumber2.enabled = false;
            CameraNumber4.enabled = false;
        }
        //�ԍ��S
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Camera4.SetActive(true);
            Camera1.SetActive(false);
            Camera2.SetActive(false);
            Camera3.SetActive(false);

            CameraNumber4.enabled = true;
            CameraNumber1.enabled = false;
            CameraNumber2.enabled = false;
            CameraNumber3.enabled = false;
        }
    }
}