using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Camera_Data : MonoBehaviour
{
    [Header("���ꂼ���GimmicUI������Ƃ�")]

    public GameObject[] OBJ_gimmicUI;

    [Header("Camera�֘A�������ɓ���Ƃ���")]

    public GameObject[] OBJ_camera;

    [Header("Text�֘A�������ɓ���Ƃ���")]

    public Text TEXT_camera;

    [Header("SonarFx��Script�����Ă�")]
    // �\�i�[�X�N���v�g�擾
    public SonarFx[] SonarFx_sf;

    //Camera�p��Flag
    [Header("�e�J�����p�̃t���O")]

    public bool[] Cam_Flg;

    [Header("Volt��Cooltime�p��Text�����ĂˁB")]

    public Text[] CT_Volt;

    [Header("���ꂼ���Volt�g���b�v�Ŏg��Image�����Ă�")]

    // �{���g�g���b�v�C���[�W
    public Image[] IMAGE_Volt;

    //Volt�g���b�v�̃N�[���^�C��
    private int V_time = 20;

    //Volt�p��Flag
    [Header("�eVolt�p�̃t���O")]

    public bool[] Volt_Flg;

    //Volt��timer�̕ϐ�
    [Header("�e�J������Volt�̃^�C�}�[")]
    public float[] Volt_timers;

    [Header("Volt�̃N�[���^�C��")]
    public int Cool_Volt;


    public void UIActive(int num)
    {
        for (int i = 0; i < OBJ_gimmicUI.Length; i++)
        {
            // ��U�S�Ă�UI�\�����\��
            OBJ_gimmicUI[i].SetActive(false);
            // OBJ_camZoom[i].SetActive(false);
        }
        OBJ_gimmicUI[num].SetActive(true);
        //OBJ_camZoom[num].SetActive(true);
    }
    //�J�����֘A�̐؂�ւ��̏���
    public void SetCamera(int num)
    {
        if (num >= 1 && num <= 9)
        {
            CameraScan();
            for (int i = 0; i < OBJ_camera.Length; i++)
            {
                OBJ_camera[i].SetActive(i == num - 1);
            }
            //num�̐����ɉ�����Text�iCAMERA�����j��\��
            TEXT_camera.text = $"CAMERA{num}";
        }
    }
    public void SonarOff()
    {
        for (int i = 0; i < SonarFx_sf.Length; i++)
        {
            SonarFx_sf[i].enabled = false;
        }
    }
    public void SonarOn()
    {
        for (int i = 0; i < SonarFx_sf.Length; i++)
        {
            SonarFx_sf[i].enabled = true;
        }
    }
    public void CameraScan()
    {
        for (int i = 0; i < OBJ_camera.Length; i++)
        {
            OBJ_camera[i].SetActive(false);
        }
    }
    public void CamFlag()
    {
        for (int i = 0; i < Cam_Flg.Length; i++)
        {
            Cam_Flg[i] = false;
        }
    }
    public void StartVoltTimer(int index)
    {
        CT_Volt[index].text = V_time.ToString();
        IMAGE_Volt[index].fillAmount = 1;
        Volt_Flg[index] = true;
    }
    public void UpdateVoltTimer(int index)
    {
        Volt_timers[index] -= Time.deltaTime;
        CT_Volt[index].text = ((int)Volt_timers[index]).ToString();
        IMAGE_Volt[index].fillAmount -= 1.0f / (float)Cool_Volt * Time.deltaTime;
        if (Volt_timers[index] <= 0)
        {
            Volt_Flg[index] = false;
            CT_Volt[index].text = "OK";
            Volt_timers[index] = Cool_Volt;
        }
    }
}
